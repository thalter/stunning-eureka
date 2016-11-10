using System.ComponentModel.DataAnnotations.Schema;

namespace ImageExtrator.Model
{
    [Table("media_to_metadata_table")]
    public class MediaMetadata
    {
        public virtual int media_id { get; set; }
        public virtual int metadata_id { get; set; }

        [ForeignKey("media_id")]
        public virtual Media Media { get; set; }

        public override string ToString()
        {
            return $"media_id:{media_id}";
        }
    }
}