using System.IO;
using System;
using System.Linq;


namespace Sideloader_Launcher
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] files = Directory.GetFiles(Environment.CurrentDirectory);
            string latestVersionFile = "";
            int currMaxVersion = 0;
            foreach (string file in files)
            {
                string fileName = file;
                while (fileName.Contains("\\"))
                {
                    fileName = fileName.Substring(fileName.IndexOf("\\") + 1);
                }
                if (fileName.StartsWith("Android") && fileName.EndsWith(".exe") && !fileName.Contains("Launcher"))
                {
                    int thisVersion = int.Parse(new String(fileName.Where(Char.IsDigit).ToArray()));
                    if (thisVersion > currMaxVersion)
                    {
                        currMaxVersion = thisVersion;
                        latestVersionFile = fileName;
                    }
                }
            }
            if  (!(latestVersionFile == ""))
            {
                System.Diagnostics.Process.Start(latestVersionFile);
            }
        }
    }
}
