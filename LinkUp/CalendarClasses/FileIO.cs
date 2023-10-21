using System;
using System.Collections.Generic;
using System.Linq;

namespace LinkUp
{
    internal static class FileIO
    {
        public static void Wirte(string text, string targetFileName)
        {
			//string targetFile = System.IO.Path.Combine(new Globals().ROOT_DIRECTORY, targetFileName);
			string targetFile = new Globals().ROOT_DIRECTORY + targetFileName;
			using FileStream outputStream = System.IO.File.OpenWrite(targetFile);
            using StreamWriter streamWriter = new StreamWriter(outputStream);
            streamWriter.WriteAsync(text);
        }
        /*
        public async static Task<string> Read(string targetFileName)
        {
            string targetFile = System.IO.Path.Combine(FileSystem.Current.AppDataDirectory, targetFileName);
            if (!File.Exists(targetFile)) { return null; }

            using FileStream InputStream = System.IO.File.OpenRead(targetFile);
            using StreamReader reader = new StreamReader(InputStream);
            return await reader.ReadToEndAsync();
        }
        /*/
        public static string Read(string targetFileName)
        {
            //string targetFile = System.IO.Path.Combine(new Globals().ROOT_DIRECTORY, targetFileName);
			string targetFile = new Globals().ROOT_DIRECTORY + targetFileName;
            if (!File.Exists(targetFile)) { return null; }

			using FileStream InputStream = System.IO.File.OpenRead(targetFile);
            using StreamReader reader = new StreamReader(InputStream);
            return reader.ReadToEndAsync().ToString();
        }
        //*/
        public static List<string> ReadLines(string targetFileName)
        {
            //string targetFile = System.IO.Path.Combine(new Globals().ROOT_DIRECTORY, targetFileName);
			string targetFile = new Globals().ROOT_DIRECTORY + targetFileName;
            if (!File.Exists(targetFile)) { return null; }

			using FileStream InputStream = System.IO.File.OpenRead(targetFile);
            using StreamReader reader = new StreamReader(InputStream);

            List<string> output = new();
            string line;

            while ((line = reader.ReadLine()) != null)
                output.Add(line.Trim());
            
            return output;
        }




    }
}
