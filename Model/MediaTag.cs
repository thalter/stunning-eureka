using System.ComponentModel.DataAnnotations.Schema;

namespace ImageExtrator.Model
{

    [Table("tag_to_media_table")]
    public class MediaTag
    {
        public virtual int media_index { get; set; }

        public virtual int media_id { get; set; }
        public virtual int tag_id { get; set; }

        [ForeignKey("media_id")]
        public virtual Media Media { get; set; }

        [ForeignKey("tag_id")]
        public virtual Tag Tag { get; set; }

        public override string ToString()
        {
            return $"media_id:{media_id} tag_id:{tag_id} {Tag?.name}";
        }
    }
}