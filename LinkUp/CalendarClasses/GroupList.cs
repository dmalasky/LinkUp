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
        public GroupList()
        {
            string userID = FileIO.Read(Globals.CURRENT_USER_FILE_NAME);
            if (string.IsNullOrEmpty(userID)) return;

            userID = userID.Trim();

            List<string> userGroupIDs = FileIO.ReadLines(Globals.USER_DIRECTORY + userID);
            if (!userGroupIDs.Any()) return;

            foreach (string guid in userGroupIDs)
            {
                LoadGroupFromUID(guid);
            }
        }

        public bool LoadGroupFromUID(string GUID)
        {
            GUID = GUID.ToLower();
            /*
            string[] jsonFiles = Directory.GetFiles(Globals.GROUP_DIRECTORY, GUID + "*.json");

            if (jsonFiles.Length == 0)
            {
                Console.WriteLine("Unable to find json manifest for group " + GUID);
                return false;
            }
            if (jsonFiles.Length < 1)
            {
                Console.WriteLine("Found multiple instances of group manifest " + GUID);
                return false;
            }

            string jsonContents = File.ReadAllText(jsonFiles[0]);
            /*/
            string jsonContents = FileIO.Read(Globals.GROUP_DIRECTORY + GUID);
            //*/

            if (jsonContents.Length <= 1)
            {
                Console.WriteLine("Manifest file for group " + GUID + " is empty");
                return false;
            }

            Group g = JsonSerializer.Deserialize<Group>(jsonContents, Globals.JSON_SERIALIZER_OPTIONS);
            Add(g);

            return true;
        }


		public void SaveAll()
		{
            foreach(Group g in this)
            {
                string jsonString = JsonSerializer.Serialize(g, Globals.JSON_SERIALIZER_OPTIONS);
                FileIO.Wirte(jsonString, Globals.GROUP_DIRECTORY + g.uid);
            }
		}
	}
}
