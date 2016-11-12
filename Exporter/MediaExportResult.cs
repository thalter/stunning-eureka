namespace ImageExtrator.Exporter
{
    public class MediaExportResult
    {
        public int TotalImagesProcessed { get; set; }
        public int ExportedImages { get; set; }
        public int PreviousVersionsSkipped { get; set; }

        public int MissingFiles { get; set; }
    }
}