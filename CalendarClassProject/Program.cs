// See https://aka.ms/new-console-template for more information
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.RegularExpressions;


//namespace LinkedUp
//{
//	partial class Program
//	{
//		static void Main()
//		{
//	}
//}


Console.WriteLine("Hello, World!");

var rand = new Random();
var randStr = new RandomString(8);

string[] directories = Directory.GetDirectories(@"C:\Users\Ben\Desktop\Projects\Dynamic Keyboard\Precompiler\KeySets\");
foreach (string d in directories)
{
	string[] jsonFiles = Directory.GetFiles(d, "*.json");

	foreach (string f in jsonFiles)
	{
		string name = Path.GetFileNameWithoutExtension(f);
		Console.WriteLine(f + " > " + name);
		Console.WriteLine(rand.NextInt64().ToString("X"));
		Console.WriteLine(randStr.getNew());
	}
}
Console.WriteLine("\n\n");


GroupCalendar gcal = new GroupCalendar();

gcal.addUser();
		

//}

		/*
	int loadGroupFromUID(string uid)
	{
		uid = uid.ToLower();
		string[] jsonFiles = Directory.GetFiles(Globals.JSON_DIRECTORY, uid + ".json");

		if (jsonFiles.Length == 0)
		{
			Console.WriteLine("Unable to find json manifest for group " + uid);
			return 0;
		}
		if (jsonFiles.Length < 1)
		{
			Console.WriteLine("Found multiple instances of group manifest " + uid);
			return 0;
		}

		string jsonContents = File.ReadAllText(jsonFiles[0]);

		if (jsonContents.Length <= 1)
		{
			Console.WriteLine("Manifest file for group " + uid + " is empty");
			return 0;
		}

		var options = new JsonSerializerOptions
		{
			ReadCommentHandling = JsonCommentHandling.Skip,
			AllowTrailingCommas = true,
		};
		GroupCalendar g = JsonSerializer.Deserialize<GroupCalendar>(jsonContents, options);

		return g;
	}
//}*/