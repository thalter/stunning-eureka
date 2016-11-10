using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ImageExtrator.Model
{
    [Table("metadata_decimal_table")]
    public class MetadataDecimal
    {
        [Key]
        public int id { get; set; }

        public int description_id { get; set; }

        public decimal value { get; set; }

        public override string ToString()
        {
            return $"id:{id} value:{value}";
        }
    }
}