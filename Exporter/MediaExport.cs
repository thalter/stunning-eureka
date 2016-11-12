using System;
using System.Collections.Generic;

namespace ImageExtrator.Exporter
{
    public class MediaExport
    {
        public string FullPath { get; set; }

        public string Location { get; set; }

        public DateTime DateTime { get; set; }

        public HashSet<string> Keywords { get; set; } = new HashSet<string>();

        public HashSet<string> Events { get; set; } = new HashSet<string>();

        public HashSet<string> People { get; set; } = new HashSet<string>();

        public HashSet<string> Places { get; set; } = new HashSet<string>();
    }
}