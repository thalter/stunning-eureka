using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ImageExtrator.Model
{
    [Table("metadata_integer_table")]
    public class MetadataInteger
    {
        [Key]
        public int id { get; set; }

        public int description_id { get; set; }

        public int value { get; set; }

        public override string ToString()
        {
            return $"id:{id} value:{value}";
        }
    }
}