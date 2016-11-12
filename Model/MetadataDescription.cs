using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ImageExtrator.Model
{
    [Table("metadata_description_table")]
    public class MetadataDescription
    {
        [Key]
        public int id { get; set; }

        public string identifier { get; set; }

        public string data_type { get; set; }

        public string association_type { get; set; }

        public int can_have_multiple_items { get; set; }

        public override string ToString()
        {
            return $"id:{id} identfier:{identifier} data_type:{data_type}";
        }
    }
}
