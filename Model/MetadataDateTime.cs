using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ImageExtrator.Model
{
    [Table("metadata_date_time_table")]
    public class MetadataDateTime
    {
        [Key]
        public int id { get; set; }

        public int description_id { get; set; }

        public string value { get; set; }

        public override string ToString()
        {
            return $"id:{id} value:{value}";
        }
    }
}