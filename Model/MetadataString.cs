using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ImageExtrator.Model
{
    [Table("metadata_string_table")]
    public class MetadataString
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