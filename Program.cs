using System;
using System.IO;
using ImageExtrator.Model;

namespace ImageExtrator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            FileInfo fi = new FileInfo("/Users/TomHalter/Documents/catalog.pse14db");
            if(!fi.Exists){
                Console.WriteLine("File not found");
            }

            PseContext db = new PseContext($"Filename={fi.FullName}");

            foreach (Media m in db.Medias)
            {
                Console.WriteLine(m.full_filepath);
            }
        }
    }
}