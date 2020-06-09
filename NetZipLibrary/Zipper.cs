using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NetZipLibrary
{
    public class Zipper
    {
        public void ZipFolder(string sourcePath, string targetPath)
        {
            sourcePath = Path.GetFullPath(sourcePath);
            targetPath = Path.GetFullPath(targetPath);
        }
    }
}
