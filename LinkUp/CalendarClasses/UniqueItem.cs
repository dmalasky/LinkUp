using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkUp
{
    public class UniqueItem
    {
        public string uid { get; set; }
        private readonly int uidLength;

        Random rand = new Random();
        const string chars = "abcdefghijklmnopqrstuvwxyz0123456789";

        protected UniqueItem(int Length)
        {
            uidLength = Length;
            uid = getNewUID();
        }

        protected string getNewUID()
        {
            return new string(Enumerable.Repeat(chars, uidLength).Select(s => s[rand.Next(s.Length)]).ToArray());
        }

        protected string getUniqueUID(List<UniqueItem> excludeList)
        {
            List<string> strList = excludeList.Select(o => o.uid).ToList();
            return getUniqueUID(strList);
        }

        protected string getUniqueUID(List<String> excludeList)
        {
            return getUniqueUID(excludeList.ToArray());
        }

        protected string getUniqueUID(String[] excludeList)
        {
            string newString;

            do
            {
                newString = getNewUID();
            }
            while (excludeList.Contains(newString));

            return newString;
        }
    }
}
