// Copyright (c) 2016 Tom Overton
// Class for mapping from a given name file to a user-friendly list of names.

using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace FE12GuideNameTool
{
    public class NameFileMapper
    {
        private static Dictionary<string, List<string>> fileToNameList;

        public static void InitializeNameFileMapper()
        {
            fileToNameList = new Dictionary<string, List<string>>();
            ReadNameFileContents();
        }

        public static List<string> GetNamesForFile(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                return null;
            }

            string[] fileSegments = filePath.Split(Path.DirectorySeparatorChar);
            string fileName = fileSegments[fileSegments.Length - 1];
            List<string> result = null;
            fileToNameList.TryGetValue(fileName.ToLowerInvariant(), out result);
            return result;
        }

        private static void ReadNameFileContents()
        {
            StreamReader reader = new StreamReader(Assembly.GetExecutingAssembly().GetManifestResourceStream("FE12GuideNameTool.Resources.NameFileContents.txt"));
            string currentName = null;
            List<string> currentList = new List<string>();
            bool keepReading = true;
            string line;
            while (keepReading)
            {
                keepReading = ((line = reader.ReadLine()) != null);
                if (!keepReading || string.IsNullOrWhiteSpace(line))
                {
                    fileToNameList.Add(currentName.ToLowerInvariant(), currentList);
                    currentName = null;
                    currentList = new List<string>();
                }
                else if (currentName == null)
                {
                    currentName = line;
                }
                else
                {
                    currentList.Add(line);
                }
            }
        }
    }
}
