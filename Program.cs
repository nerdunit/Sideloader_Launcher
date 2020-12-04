using System.IO;
using System;


namespace Sideloader_Launcher
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] files = Directory.GetFiles(Environment.CurrentDirectory);
            foreach (string file in files)
            {
                string fileName = file;
                while (fileName.Contains("\\"))
                {
                    fileName = fileName.Substring(fileName.IndexOf("\\") + 1);
                }
                if (fileName.StartsWith("Android") && fileName.EndsWith(".exe") && !fileName.Contains("Launcher"))
                {
                    System.Diagnostics.Process.Start(file);
                }
            }
        }
    }
}
