using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace GenerateUniqueAcronyms
{
    internal static class SayNoToMinimalApi
    {
        private static Random random = new Random();
        public static void GenerateAcronyms()
        {
            Dictionary<string,string> acronyms = new Dictionary<string,string>();
            string[] users = { "Michiel Stienaers", "Michiel Staessen", "Stan Mine", "Manuel Van Wesemael", "Maxim Van Mechelen", "Maarten Van Lier", "Michael De Voecht", "Maxime Delacour", "Mathias Tierens", "Jan Vermeulen", "Johan Verhaert","Benjamin Van den Broeck","Bert Van den Brande" };
            foreach(var user in users)
            {
                var basicAcronym= GetBasicAcronym(user);
                var acronym = FinalizeAcronym(user,basicAcronym, acronyms);
                acronyms[acronym] = user;
            }

            foreach(var acronym in acronyms)
            {
                Console.WriteLine(acronym.Value + " "+ acronym.Key);
            }
        }

        private static string GetBasicAcronym(string user)
        {
            var parts = user.Split(" ");
            var basicAcronym = "";
            if(parts.Length > 2)
            {
                var oldParts = parts;
                parts = new string[2];
                parts[0] = oldParts[0];
                parts[1] = oldParts.TakeLast(1).ToArray()[0];
            }
            foreach(var part in parts)
            {
                basicAcronym+=part.ToUpper()[0];
            }
            return basicAcronym;
        }

        private static string FinalizeAcronym(string userName, string basicAcronym, Dictionary<string, string> acronyms)
        {
            var lengthOfUniquePart = 4 - basicAcronym.Length;
            var acronym = basicAcronym + GenerateUniquePart(lengthOfUniquePart,userName );
            while (acronyms.ContainsKey(acronym))
            {
                acronym = GenerateUniquePart(lengthOfUniquePart,userName);
            }
            return acronym;
        }

        private static string GenerateUniquePart(int length, string userName)
        {
            var removedWhitespace = userName.Replace(" ", "");
            var cappedUsers = removedWhitespace.ToUpper();
            var chars = cappedUsers + "0123456789";
            return new string(Enumerable.Repeat(cappedUsers, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
