using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LinkUp
{
    internal readonly struct Globals
    {
        public Globals() { ROOT_DIRECTORY = FileSystem.Current.AppDataDirectory; }
        public readonly string ROOT_DIRECTORY;
		// directories must have leading slash
		public const string GROUP_DIRECTORY = @"/Groups/";
        public const string USER_DIRECTORY = @"/Users/";
        public const string CURRENT_USER_FILE_NAME = @"/Current_User";

        public const int GROUP_UID_LENGTH = 8;
        public const int USER_UID_LENGTH = 5;
        public const int CALEVENT_UID_LENGTH = 5;

        public static JsonSerializerOptions JSON_SERIALIZER_OPTIONS = new()
        {
            ReadCommentHandling = JsonCommentHandling.Skip,
            AllowTrailingCommas = true,
			WriteIndented = true,
		};
        //public static JsonSerializerOptions { WriteIndented = true };

	}
}
