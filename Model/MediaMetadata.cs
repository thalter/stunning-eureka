using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ImageExtrator.Model
{
    [Table("media_to_metadata_table")]
    public class MediaMetadata
    {
        public virtual int media_id { get; set; }

        /// <summary>
        /// Foreign key to <see cref="AbstractMetadata"/>. 
        /// </summary>
        /// <remarks>
        /// The data model gets kind of dicey here. metadata_id is actually a foreign key to one of five different tables and types: 
        /// <see cref="MetadataDateTime"/>, <see cref="MetadataString"/>, <see cref="MetadataInteger/>, <see cref="MetadataDecimal/>, or metadata_blob (not implemented).
        /// Entity Framework tends to barf with these kind of keys, so use the <see cref="GetMetadata"/> helper method below to get the correct metadata object.
        /// </remarks>
        /// <returns></returns>
        public virtual int metadata_id { get; set; }

        /// <summary>
        /// <see cref="Media"/> associated with this Metadata.
        /// </summary>
        /// <returns></returns>
        [ForeignKey("media_id")]
        public virtual Media Media { get; set; }

        public override string ToString()
        {
            return $"media_id:{media_id} metadata_id:{metadata_id}";
        }

        public AbstractMetadata GetMetadata(PseContext db)
        {
            AbstractMetadata returnValue = db.MetadataIntegers.Include(x=>x.Description).FirstOrDefault(x => x.id == metadata_id);

            if (returnValue == null)
                returnValue = db.MetadataStrings.Include(x=>x.Description).FirstOrDefault(x => x.id == metadata_id);

            if (returnValue == null)
                returnValue = db.MetadataDecimals.Include(x=>x.Description).FirstOrDefault(x => x.id == metadata_id);
 
            if (returnValue == null)
                returnValue = db.MetadataDateTime.Include(x=>x.Description).FirstOrDefault(x => x.id == metadata_id);

            return returnValue;
        }
    }
}