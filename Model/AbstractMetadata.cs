using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ImageExtrator.Model
{
    public abstract class AbstractMetadata
    {
        [Key]
         public int id { get; set; }

         public int description_id { get; set; }

        [ForeignKeyAttribute("description_id")]
         public MetadataDescription Description { get;set; }

        /// <summary>
        /// Returns value as a native data type (will need to cast from Object)
        /// </summary>
        /// <returns></returns>
        public abstract object ToValue();
    }
}