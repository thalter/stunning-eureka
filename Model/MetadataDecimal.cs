using System.ComponentModel.DataAnnotations.Schema;

namespace ImageExtrator.Model
{
    [Table("metadata_decimal_table")]
    public class MetadataDecimal : AbstractMetadata
    {
        public decimal value { get; set; }

        public override string ToString()
        {
            return $"id:{id} value:{value}";
        }

        public override object ToValue()
        {
            return value;
        }
    }
}