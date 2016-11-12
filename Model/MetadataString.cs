using System.ComponentModel.DataAnnotations.Schema;

namespace ImageExtrator.Model
{
    [Table("metadata_string_table")]
    public class MetadataString : AbstractMetadata
    {
        public string value { get; set; }

        public override string ToString()
        {
            return $"id:{id} value:{value}";
        }

        public override object ToValue(){
            return value;
        }
    }
}