using System;
using System.IO;
using System.Linq;
using ImageExtrator.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ImageExtrator
{
    public class Program
    {
        public static ILoggerFactory LoggerFactory { get; } = new LoggerFactory();

        public static void Main(string[] args)
        {
            //LoggerFactory.AddFile("Logs/myapp-{Date}.txt");
            LoggerFactory.AddConsole();

            ILogger Logger = LoggerFactory.CreateLogger<Program>();
            Logger.LogInformation("Starting Image Extractor");

            FileInfo fi = new FileInfo("/Users/TomHalter/Documents/catalog.pse14db");
            if (!fi.Exists)
            {
                Logger.LogCritical("File not found");
            }

            PseContext db = new PseContext($"Filename={fi.FullName}");

            foreach (Media m in db.Medias.Include(media => media.MediaMetadata).Include(media => media.MediaTags).ThenInclude(mediaTag => mediaTag.Tag))
            {
                Logger.LogInformation($"media_id:{m.id} {m.FullName}");

                foreach (MediaTag t in m.MediaTags)
                {
                    Logger.LogInformation(t.ToString());
                }

                foreach (MediaMetadata mm in m.MediaMetadata)
                {
                    Logger.LogInformation($"{mm}");
                    AbstractMetadata am = mm.GetMetadata(db);
                    Logger.LogInformation($"{am.Description.ToString()} value:{am.ToValue().ToString()}");
                }
            }
        }
    }
}