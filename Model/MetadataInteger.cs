using System.ComponentModel.DataAnnotations.Schema;

namespace ImageExtrator.Model
{
    [Table("metadata_integer_table")]
    public class MetadataInteger : AbstractMetadata
    {
        public int value { get; set; }

        public override string ToString()
        {
            return $"id:{id} value:{value}";
        }

    public override object ToValue(){
            return value;
        }
    }
}