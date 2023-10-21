using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.RegularExpressions;

//namespace LinkedUp
//{
//	partial class Program
//	{
//	}
//}

class GroupCalendar
{
	string name?;
	string uid?;

	public List<GroupMember> members;

    GroupCalendar loadGroupFromUID(string loadUID)
	{
		loadUID = loadUID.ToLower();
		string[] jsonFiles = Directory.GetFiles(Globals.JSON_DIRECTORY, loadUID + ".json");

		if (jsonFiles.Length == 0)
		{
			Console.WriteLine("Unable to find json manifest for group " + loadUID);
			return -1;
		}
		if (jsonFiles.Length < 1)
		{
			Console.WriteLine("Found multiple instances of group manifest " + loadUID);
			return -1;
		}

		string jsonContents = File.ReadAllText(jsonFiles[0]);

		if (jsonContents.Length <= 1)
		{
			Console.WriteLine("Manifest file for group " + loadUID + " is empty");
			return -1;
		}

		var options = new JsonSerializerOptions
		{
			ReadCommentHandling = JsonCommentHandling.Skip,
			AllowTrailingCommas = true,
		};
		
		GroupCalendar g = JsonSerializer.Deserialize<GroupCalendar>(jsonContents, options);
		return g;
	}

	public string createNewGroup(string GroupName)
	{
		string[] jsonFiles = Directory.GetFiles(Globals.JSON_DIRECTORY, ".json");
		for (int i = 0; i < jsonFiles.Length; i++)
		{
			jsonFiles[i] = Path.GetFileNameWithoutExtension(jsonFiles[i]);
		}

		var rand = new RandomString(Globals.GROUP_UID_LENGTH);

		name = GroupName;
		uid = rand.getUnique(jsonFiles);

		return uid;
	}
}