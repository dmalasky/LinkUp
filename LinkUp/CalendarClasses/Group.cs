using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LinkUp
{
    internal class Group : UniqueItem
    {
        public string name { get; }
        public List<GroupMember> members { get; set; }


        [JsonConstructor]
        public Group(string name, string uid, List<GroupMember> members) : base(Globals.GROUP_UID_LENGTH)
        {
            this.name = name;
            this.uid = uid;
            this.members = members;
        }

        public Group(string newName) : base(Globals.GROUP_UID_LENGTH)
        {
            string[] jsonFiles = Directory.GetFiles(new Globals().ROOT_DIRECTORY + Globals.GROUP_DIRECTORY, "*");
            for (int i = 0; i < jsonFiles.Length; i++)
            {
                jsonFiles[i] = Path.GetFileNameWithoutExtension(jsonFiles[i]);
            }

            name = newName;
            uid = getUniqueUID(jsonFiles);
            members = new List<GroupMember>();
        }


        public void addMember(GroupMember newMember)
        {
            newMember.uid = getUniqueUID(members.ConvertAll(x => (UniqueItem)x));
            members.Add(newMember);
        }

    }
}
