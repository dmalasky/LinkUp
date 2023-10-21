using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LinkUp
{
    internal class GroupList : List<Group>
    {
        

        public bool LoadGroupFromUID(string loadUID)
        {
            loadUID = loadUID.ToLower();
            string[] jsonFiles = Directory.GetFiles(Globals.GROUP_DIRECTORY, loadUID + "*.json");

            if (jsonFiles.Length == 0)
            {
                Console.WriteLine("Unable to find json manifest for group " + loadUID);
                return false;
            }
            if (jsonFiles.Length < 1)
            {
                Console.WriteLine("Found multiple instances of group manifest " + loadUID);
                return false;
            }

            string jsonContents = File.ReadAllText(jsonFiles[0]);

            if (jsonContents.Length <= 1)
            {
                Console.WriteLine("Manifest file for group " + loadUID + " is empty");
                return false;
            }

            var options = new JsonSerializerOptions
            {
                ReadCommentHandling = JsonCommentHandling.Skip,
                AllowTrailingCommas = true,
            };

            Group g = JsonSerializer.Deserialize<Group>(jsonContents, options);
            Add(g);

            return true;
        }
    }
}
