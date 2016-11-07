using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ImageExtrator.Model
{
    [Table("tag_table")]
    public class Tag
    {
        [Key]
        public int id { get; set; }

        public int change_id { get; set; }

        public string name { get; set; }

        public int parent_id { get; set; }

        public int sibling_index { get; set; }

        public string type_name { get; set; }

        public int media_is_ordered { get; set; }

        public int can_tag_media { get; set; }

        public int can_have_children { get; set; }

        public int applies_to_all_in_media_stack { get; set; }

        public int applies_to_all_in_version_stack { get; set; }

    }
}