
namespace ZebraPuzzle.Models
{
    public class Member
    {
        public List<Dictionary<string, string>> solution;
        public double fitness;

        private static string[] key = new string[] { "nation", "color", "drink", "smoke", "pet" };

        public Member()
        {
            solution = Utilities.GenerateRandomSolution();
            fitness = 0.0;
        }

        public override string ToString()
        {
            string s = $"Fitness:{GetFitness()}\n";
            foreach (var row in solution)
            {
                s += $"{string.Join(", ", row)}\n";
            }
            return s;
        }

        public double GetFitness()
        {
            TestRules();
            return fitness;
        }

        public void TestRules()
        {
            int sum = 0;
            if (CheckSingleHouseRule("nation", "Englishman", "color", "Red"))
            {
                sum += 1;
            }
            else
            {
                sum -= 1;
            }

            if (CheckSingleHouseRule("nation", "Spaniard", "pet", "Dog"))
            {
                sum += 1;
            }
            else
            {
                sum -= 1;
            }

            if (CheckSingleHouseRule("drink", "Coffe", "color", "Green"))
            {
                sum += 1;
            }
            else
            {
                sum -= 1;
            }

            if (CheckSingleHouseRule("nation", "Ukrainian", "drink", "Tea"))
            {
                sum += 1;
            }
            else
            {
                sum -= 1;
            }

            if (CheckNeighborhoodRules("color", "Ivory", "color", "Green"))
            {
                sum += 1;
            }
            else
            {
                sum -= 1;
            }

            if (CheckSingleHouseRule("smoke", "Old Gold", "pet", "Snails"))
            {
                sum += 1;
            }
            else
            {
                sum -= 1;
            }

            if (CheckSingleHouseRule("smoke", "Kools", "color", "Yellow"))
            {
                sum += 1;
            }
            else
            {
                sum -= 1;
            }

            if (CheckRuleForExactHouse(2, "drink", "Milk"))
            {
                sum += 1;
            }
            else
            {
                sum -= 1;
            }

            if (CheckRuleForExactHouse(0, "nation", "Norwegian"))
            {
                sum += 1;
            }
            else
            {
                sum -= 1;
            }

            if (CheckNeighborhoodRules("pet", "Fox", "smoke", "Chesterfield"))
            {
                sum += 1;
            }
            else
            {
                sum -= 1;
            }

            if (CheckNeighborhoodRules("smoke", "Kools", "pet", "Horse"))
            {
                sum += 1;
            }
            else
            {
                sum -= 1;
            }

            if (CheckSingleHouseRule("smoke", "Lucky Strike", "drink", "Orange juice"))
            {
                sum += 1;
            }
            else
            {
                sum -= 1;
            }

            if (CheckSingleHouseRule("nation", "Japanese", "smoke", "Parliaments"))
            {
                sum += 1;
            }
            else
            {
                sum -= 1;
            }

            if (CheckNeighborhoodRules("nation", "Norwegian", "color", "Blue"))
            {
                sum += 1;
            }
            else
            {
                sum -= 1;
            }
            if(CheckForDuplicates(solution))
            {
                sum--;
            }
            this.fitness = (double)Math.Round((sum / (decimal)14) * 100, 3); 
        }

        public bool CheckSingleHouseRule(string key1, string value1, string key2, string value2)
        {
            foreach (var row in solution)
            {
                if (row[key1] == value1 && row[key2] == value2)
                {
                    return true;
                }
            }
            return false;
        }

        public bool CheckNeighborhoodRules(string House1_key, string House1_value, string House2_key, string House2_value)
        {
            for (int i = 0; i < 5; i++)
            {
                if (solution[i][House1_key] == House1_value)
                {
                    if ((i + 1) % 5 != 0)
                    {
                        if (solution[(i + 1)][House2_key] == House2_value)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public bool CheckRuleForExactHouse(int house, string key, string value)
        {
            if (solution[house][key] == value)
                return true;
            return false;
        }
        public static bool CheckForDuplicates(List<Dictionary<string, string>> list)
        {
            HashSet<string> set = new HashSet<string>();
            var key1List = new List<string>();
            var key2List = new List<string>();
            var key3List = new List<string>();
            var key4List = new List<string>();
            var key5List = new List<string>();

            for (int i = 0; i < list.Count(); i++)
            {
                foreach (var elem in key)
                {
                    if (elem == "nation") key1List.Add(list[i][elem]);
                    if (elem == "drink") key2List.Add(list[i][elem]);
                    if (elem == "pet") key3List.Add(list[i][elem]);
                    if (elem == "smoke") key4List.Add(list[i][elem]);
                    if (elem == "color") key5List.Add(list[i][elem]);
                }
            }

            if (key1List.Distinct().Count() != key1List.Count() ||
                key2List.Distinct().Count() != key2List.Count()
                || key3List.Distinct().Count() != key3List.Count()
                || key4List.Distinct().Count() != key4List.Count()
                || key5List.Distinct().Count() != key5List.Count())
            {
                return true;
            }
            return false;
        }
    }
}

   
    