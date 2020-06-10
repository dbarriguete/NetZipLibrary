using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using NetZipLibrary;


namespace NetZipper
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("#####################################");
            Console.WriteLine("Welcome to NetZip");
            Console.WriteLine("#####################################");
            Console.WriteLine("Ways to use: ");
            Console.WriteLine("-d sourceDirectory targetDirectory");
            Console.WriteLine("-f zipPath, zipName, sourcePath, sourceFileName");
            Console.WriteLine("#####################################");
            Console.WriteLine("#####################################");

            switch (args[0].ToLower())
            {
                case "-d":
                    Zipper.ZipFolder(args[1], args[2]);
                    break;
                case "-f":
                    Zipper.AddBinaryFilesToZip(args[1], args[2], args[3], args[4]);
                    break;
                default:
                    Console.WriteLine("Nothing do, you didn't use any correct argument.");
                    break;
            }
        }
    }
}
