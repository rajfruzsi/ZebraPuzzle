using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZebraPuzzle.Models
{
    internal class HelperFunctions
    {
      
   
      

        public static List<Dictionary<string, string>> GenerateRandomSolution()
        {
                Random random = new Random();
            List<string> nation = new List<string> { "Norwegian", "Ukrainian", "Englishman", "Spaniard", "Japanese" };
            List<string> color = new List<string> { "Red", "Blue", "Yellow", "Ivory", "Green" };
            List<string> drink = new List<string> { "Tea", "Milk", "Coffe", "Orange juice", "Water" };
            List<string> smoke = new List<string> { "Lucky Strike", "Old Gold", "Kools", "Chesterfield", "Parliaments" };
            List<string> pet = new List<string> { "Zebra", "Fox", "Horse", "Snails", "Dog" };
            nation = nation.OrderBy(x => random.Next()).ToList();
            color = color.OrderBy(x => random.Next()).ToList();
            drink = drink.OrderBy(x => random.Next()).ToList();
            smoke = smoke.OrderBy(x => random.Next()).ToList();
            pet = pet.OrderBy(x => random.Next()).ToList();

            List<Dictionary<string, string>> solution = new List<Dictionary<string, string>>();
            for (int i = 0; i < 5; i++)
            {
                Dictionary<string, string> sample = new Dictionary<string, string>()
            {
                { "nation", nation[i] },
                { "color", color[i] },
                { "drink", drink[i] },
                { "smoke", smoke[i] },
                { "pet", pet[i] }
            };
                solution.Add(sample);
            }
            return solution;
        }
    


    public static int RandomInt(int min, int max)
        {
            var rnd = new Random();
            return rnd.Next(min, max + 1);
        }

        public static int LastIndex<T>(T[] array)
        {
            return array.Length - 1;
        }


    }
}
