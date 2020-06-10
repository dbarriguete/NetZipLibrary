using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.IO.Compression;

namespace NetZipLibrary
{
    public abstract class Zipper
    {
        public static void ZipFolder(string sourcePath, string zipPath)
        {
            sourcePath = Path.GetFullPath(sourcePath);
            zipPath = Path.GetFullPath(zipPath);

            ZipFile.CreateFromDirectory(sourcePath, zipPath);
        }

        public static void UnzipFolder(string zipPath, string targetPath)
        {
            zipPath = Path.GetFullPath(zipPath);
            targetPath = Path.GetFullPath(targetPath);

            ZipFile.ExtractToDirectory(zipPath, targetPath);
        }

        public static void AddTextFilesToZip(string zipPath, string zipName, string sourcePath, string fileName)
        {
            using (FileStream zipToOpen = new FileStream( Path.GetFullPath(zipPath + "\\" + zipName) , FileMode.Open))
            {
                using (ZipArchive archive = new ZipArchive(zipToOpen, ZipArchiveMode.Update))
                {
                    ZipArchiveEntry readmeEntry = archive.CreateEntry("Readme.txt");
                    using (StreamWriter writer = new StreamWriter(readmeEntry.Open()))
                    {
                        writer.WriteLine("Information about this package.");
                        writer.WriteLine("========================");
                    }
                }
            }
        }

        public static void AddBinaryFilesToZip(string zipPath, string zipName, string sourcePath, string fileName)
        {
            using (FileStream zipToOpen = new FileStream(Path.GetFullPath(zipPath + "\\" + zipName), FileMode.Open))
            {
                using (ZipArchive archive = new ZipArchive(zipToOpen, ZipArchiveMode.Update))
                {
                    ZipArchiveEntry readmeEntry = archive.CreateEntry(fileName);

                    BinaryWriter s = new BinaryWriter(readmeEntry.Open());
                    using (FileStream fs = System.IO.File.OpenRead(fileName))
                    {
                        byte[] buffer = new byte[fs.Length];
                        fs.Read(buffer, 0, (int)fs.Length);
                        s.Write(buffer, 0, buffer.Length);
                    }
                }
            }
        }
    }
}
