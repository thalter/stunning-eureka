using System.IO;
using ImageExtrator.Exporter;
using Microsoft.Extensions.Logging;

namespace ImageExtrator
{
    public class Program
    {
        public static ILoggerFactory LoggerFactory { get; } = new LoggerFactory();

        public static int Main(string[] args)
        {
            LoggerFactory.AddFile("Logs/myapp-{Date}.log");
            LoggerFactory.AddConsole();

            ILogger Logger = LoggerFactory.CreateLogger<Program>();
            Logger.LogInformation("Starting Image Extractor");

            FileInfo fi = new FileInfo("/Users/TomHalter/Documents/catalog.pse14db");
            if (!fi.Exists)
            {
                Logger.LogCritical("File not found");
                return 1;
            }

            PseContext db = new PseContext($"Filename={fi.FullName}");

            MediaExporter exporter = new MediaExporter
            {
                Context = db,
                Simulate = true
            };

            MediaExportResult mer = exporter.Export();

            return 0;
        }
    }
}