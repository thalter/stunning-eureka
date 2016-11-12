using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace ImageExtrator.Model
{
    [Table("metadata_date_time_table")]
    public class MetadataDateTime : AbstractMetadata
    {
         static CultureInfo provider = CultureInfo.InvariantCulture;
         
        public string value { get; set; }

        public override string ToString()
        {
            DateTime td = (DateTime)ToValue();
            return $"id:{id} value:{td}";
        }

        public override object ToValue()
        {
            DateTime returnValue;

            //Insert hyphens to make RFC compliant
            string toParse = value.Insert(6, "-").Insert(4, "-");

            DateTime.TryParseExact(value, "s", provider, DateTimeStyles.AssumeLocal, out returnValue);

            return returnValue;
        }
    }
}