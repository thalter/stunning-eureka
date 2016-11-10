using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ImageExtrator.Model
{
    /// <summary>
    /// Media (images, movies, etc.)
    /// </summary>
    [Table("media_table")]
    public class Media
    {
        [Key]
        public int id { get; set; }

        public int change_id { get; set; }

        /// <summary>
        /// Full path (including name) of this <see cref="Media"/> file.
        /// </summary>
        /// <returns></returns>
        [Column("full_filepath")]
        public string FullName { get; set; }

        [Column("filepath_search_index")]
        public string FilePath { get; set; }

        [Column("filename_search_index")]
        public string FileName { get; set; }

        public string mime_type { get; set; }

        public int volume_id { get; set; }

        public string search_date_begin { get; set; }

        public string search_date_end { get; set; }

        public int rendition_description_id { get; set; }

        /// <summary>
        /// Collection of Tags
        /// </summary>
        /// <returns></returns>
        public virtual ICollection<MediaTag> MediaTags { get; set; } = new HashSet<MediaTag>();

        /// <summary>
        /// Collection of Metadata
        /// </summary>
        /// <returns></returns>
        public virtual ICollection<MediaMetadata> MediaMetadata { get; set; } = new HashSet<MediaMetadata>();
    }
}