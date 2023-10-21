using System;

//namespace LinkedUp
//{
//	partial class Program
//	{
//	}
//}

public class CalendarEvent
{
	string name = "";
	long uid; // C# lists are already hashed - maybe this isn't needed?
	DateTime dStart, dEnd;
	string repeat = "";
}