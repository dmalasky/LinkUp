using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

//namespace LinkedUp
//{
//	partial class Program
//	{
//	}
//}

public class RandomString
{
	Random rand = new Random();
	int length;
	const string chars = "abcdefghijklmnopqrstuvwxyz0123456789";

	public RandomString(int Length)
	{
		length = Length;
	}

	public string getNew()
	{
		return new string(Enumerable.Repeat(chars, length).Select(s => s[rand.Next(s.Length)]).ToArray());
	}

	public string getUnique(List<String> excludeList)
	{
		return getUnique(excludeList.ToArray());
	}

	public string getUnique(String[] excludeList)
	{
		string newString;

		do
		{
			newString = getNew();
		}
		while (excludeList.Contains(newString));

		return newString;
	}
}