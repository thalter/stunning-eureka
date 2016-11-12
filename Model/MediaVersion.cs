using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ImageExtrator.Model
{
    /// <summary>
    /// Media Version Entry
    /// </summary> 
    /// <remarks> 
    /// Version sets in PSE are stored as linked lists - the parent_id referring to the previous version of this media.
    /// A <see cref="parent_id"/> of zero means that this version is the latest version. 
    /// </remarks>
    [Table("version_stack_to_media_table")]
    public class MediaVersion
    {
        [Key]
        public int stack_tag_id { get; set; }

        /// <summary>
        /// ID of the Media associated with this MediaVersion.
        /// </summary>
        /// <returns></returns>
        public int media_id { get; set; }

        /// <summary>
        /// Version number of this MediaVersion. Zero indicates the initial version. 
        /// </summary>
        /// <returns></returns>
        public int media_index { get; set; }

        /// <summary>
        /// ID of the previous version in this version set.
        /// </summary>
        /// <returns></returns>
        public int parent_id { get; set; }
    }
}