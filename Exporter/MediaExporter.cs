
using ImageExtrator.Model;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.IO;

namespace ImageExtrator.Exporter
{
    public class MediaExporter
    {
        const string UNKNOWN_PERSON_NAME = "zzABC@11#";
        private ILogger logger { get; set; } = Program.LoggerFactory.CreateLogger<MediaExporter>();

        /// <summary>
        /// Simulates export only
        /// </summary>
        /// <returns></returns>
        public bool Simulate { get; set; }

        public PseContext Context { get; set; }

        public MediaExportResult Export()
        {
            MediaExportResult result = new MediaExportResult();

            //Iterate through media objects
            foreach (Media m in Context.Medias.Include(media => media.MediaMetadata).Include(media => media.MediaTags).ThenInclude(mediaTag => mediaTag.Tag))
            {
                logger.LogInformation($"Processing {m.FullName} media_id:{m.id}");

                //Check to see if file exists
                if (!File.Exists(m.FullName))
                {
                    result.MissingFiles++;
                    logger.LogError($"File {m.FullName} does not exist, skipping");
                    continue;
                }

                //Check to see if this is a part of a version set first.
                if (Context.MediaVersions.Any(x => x.parent_id == m.id))
                {
                    result.PreviousVersionsSkipped++;
                    logger.LogInformation($"Skipping older file version.");
                    continue;
                }

                MediaExport mediaExport = new MediaExport();
                mediaExport.FullPath = m.FullName;

                //Export Tags
                foreach (MediaTag t in m.MediaTags)
                {
                    logger.LogDebug(t.ToString());
                    switch (t.Tag.type_name)
                    {
                        case "user_person":
                            //Skip unknown people
                            if (t.Tag.name == UNKNOWN_PERSON_NAME)
                                continue;
                            logger.LogInformation($"Adding person {t.Tag.name}");
                            mediaExport.People.Add(t.Tag.name);
                            break;
                        case "user_event":
                            logger.LogInformation($"Adding event {t.Tag.name}");
                            mediaExport.Events.Add(t.Tag.name);
                            break;
                        case "user_place":
                            logger.LogInformation($"Adding place {t.Tag.name}");
                            mediaExport.Places.Add(t.Tag.name);
                            break;
                        case "user_custom":
                            logger.LogInformation($"Adding keyword {t.Tag.name}");
                            mediaExport.Keywords.Add(t.Tag.name);
                            break;
                        default:
                            //do nothing by default
                            break;
                    }
                }

                //Export Metadata
                foreach (MediaMetadata mm in m.MediaMetadata)
                {
                    logger.LogDebug($"{mm}");
                    AbstractMetadata am = mm.GetMetadata(Context);
                    logger.LogDebug($"{am.Description.ToString()} value:{am.ToValue().ToString()}");
                }
            }



            return result;
        }
    }
}