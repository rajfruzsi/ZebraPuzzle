using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZebraPuzzle.Models
{
    public static class Constants
    {
        public const int MUTATION_PROBABILITY = 19; // %
        public const int NUMBER_OF_RULES = 14;
        public const int NUMBER_OF_HOUSES = 5;
        public const int MAX_MUTATION_PROBABILITY = 100;
    }

    public class Solution : IComparable<Solution>
    {
        public List<Dictionary<string, string>> solution;
        public double fitness;
        private bool hasTestYet;

        private static string[] key = new string[] { "nation", "color", "drink", "smoke", "pet" };
        private static Random rand = new Random();

        public Solution()
        {
            solution = HelperFunctions.GenerateRandomSolution();
            fitness = 0.0;
            hasTestYet = false;
        }

        public int CompareTo(Solution other)
        {
            return other.GetFitness().CompareTo(GetFitness());
        }

        public static implicit operator int(Solution s)
        {
            return (int)s.GetFitness();
        }

        public static implicit operator float(Solution s)
        {
            return (float)s.GetFitness();
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



        public void Call(Solution partnerA, Solution partnerB)
        {
            foreach (string i in key)
            {
                int pivot = rand.Next(0, 100);
                for (int j = 0; j < 5; j++)
                {
                    List<Dictionary<string, string>> tempSolution;
                    if (pivot < 50)
                    {
                        tempSolution = partnerA.solution;
                    }
                    else
                    {
                        tempSolution = partnerB.solution;
                    }
                    solution[j][i] = tempSolution[j][i];
                }
            }

            if (IsMutationPossible())
            {
                Mutate();
            }
            Test();
        }

        private bool IsMutationPossible()
        {
            return rand.Next(0, Constants.MAX_MUTATION_PROBABILITY) <= Constants.MUTATION_PROBABILITY;
        }

        public void Mutate()
        {
            int tempValueIndex = HelperFunctions.RandomInt(0, HelperFunctions.LastIndex(key));
            int newIndex = HelperFunctions.RandomInt(0, HelperFunctions.LastIndex(key));
            while (tempValueIndex == newIndex)
            {
                newIndex = HelperFunctions.RandomInt(0, HelperFunctions.LastIndex(key));
            }
            if (newIndex != tempValueIndex)
            {
                string keyToMutate = key[HelperFunctions.RandomInt(0, HelperFunctions.LastIndex(key))];
                string tempValue = this.solution[tempValueIndex][keyToMutate];
                this.solution[tempValueIndex][keyToMutate] = this.solution[newIndex][keyToMutate];
                this.solution[newIndex][keyToMutate] = tempValue;
            }
        }



        public double GetFitness()
        {
            if (!hasTestYet)
            {
                Test();
            }
            return fitness;
        }

        public void Test()
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
            var e = (double)14 / 14;
            if(sum>6)
            {
                var itt = 1;
            }
            var tt = (decimal)((decimal)8 / (decimal)14);
            var t = Math.Round((double)(8 / 14) * 100, 3);
            var t2 = Math.Round((decimal)(8 / 14) * 100, 3);
            this.fitness = (double)Math.Round((sum / (decimal)14) * 100, 3); 
            this.hasTestYet = true;
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

    }
}
        //public void Test()
        //{
        //    int sum = 0;

//        int i = Array.IndexOf(solution[1], "Englishman");

//        if (i>=0 && solution[0][i] == "red")
//        {
//            //Console.WriteLine("The Englishman lives in the red house.");
//            sum++;
//        }
//        else if(i==-1)
//        {
//            sum--;
//        }



//    //The Swede keeps dogs.

//        i = Array.IndexOf(solution[1], "Swede");
//    if (i >= 0 && solution[3][i] == "dogs")
//        {
//        //Console.WriteLine("The Swede keeps dogs");
//        //Console.WriteLine("The Englishman lives in the red house.");
//        sum++;
//    }
//     else if(i==-1)
//    {
//        sum--;
//    }
//    //The Dane drinks tea.

//        i = Array.IndexOf(solution[1], "Dane");
//         if (i>=0 && solution[4][i] == "tea")
//    {
//        //Console.WriteLine("The Englishman lives in the red house.");
//        sum++;
//    }
//     else if(i==-1)
//    {
//        sum--;
//    }


//    //The green house is just to the left of the white one.

//        i = Array.IndexOf(solution[0], "green");
//         if (i>=0 && solution[0][i + 1] == "white")
//    {
//        //Console.WriteLine("The green house is just to the left of the white one.");
//        //Console.WriteLine("The Englishman lives in the red house.");
//        sum++;
//    }
//     else if(i==-1)
//    {
//        sum--;
//    }


//    //The owner of the green house drinks coffee.

//        i = Array.IndexOf(solution[0], "green");
//     if (i>=0 && solution[4][i] == "coffee")
//        {
//            //Console.WriteLine("The owner of the green house drinks coffee.");
//            sum++;

//        }
//         else if(i==-1)
//        {
//        sum--;
//        }


//    //The Pall Mall smoker keeps birds.
//        i = Array.IndexOf(solution[2], "Pall Mall");
//         if (i>=0 && solution[3][i] == "birds")
//    {
//            //Console.WriteLine("The Pall Mall smoker keeps birds.");
//            sum++;

//        }
//         else if(i==-1)
//        {
//        sum--;
//        }


//    //The owner of the yellow house smokes Dunhills.

//        i = Array.IndexOf(solution[0], "yellow");
//         if (i>=0 && solution[2][i] == "Dunhills")
//    {
//            //Console.WriteLine("The owner of the yellow house smokes Dunhills.");
//            sum++;

//        }
//         else if(i==-1)
//        {
//        sum--;
//        }

//    //The man in the center house drinks milk.

//         if (i>=0 && solution[4][2] == "milk")
//        {
//            //Console.WriteLine("The man in the center house drinks milk.");
//            sum++;

//        }
//         else if(i==-1)
//        {
//        sum--;
//        }


//    //The Norwegian lives in the first house.
//       if (i>=0 && solution[1][0] == "Norwegian")
//        {
//            //Console.WriteLine("The Norwegian lives in the first house.");
//            sum++;

//        }
//         else if(i==-1)
//        {
//        sum--;
//        }
//     i = Array.IndexOf(solution[2], "Blend");
//    if (i >= 0)
//    {


//        if (i >= 0 && i == 0)
//        {
//            if (i >= 0 && solution[3][i + 1] == "cats")
//            {
//                //Console.WriteLine("The Blend smoker has a neighbor who keeps cats.");
//                sum++;

//            }
//            else if (i == -1)
//            {
//                sum--;
//            }
//        }
//        else if (i >= 0 && i == 4)
//        {
//            if (i >= 0 && solution[3][i - 1] == "cats")
//            {
//                //Console.WriteLine("The Blend smoker has a neighbor who keeps cats.");
//                sum++;

//            }
//            else if (i == -1)
//            {
//                sum--;
//            }
//        }
//        else
//        {
//            if (i >= 0 && solution[3][i + 1] == "cats" || solution[3][i - 1] == "cats")
//            {
//                //Console.WriteLine("The Blend smoker has a neighbor who keeps cats.");
//                sum++;

//            }
//            else if (i == -1)
//            {
//                sum--;
//            }
//        }
//    }


//    // The man who smokes Blue Masters drinks bier.

//       i = Array.IndexOf(solution[2], "Blue Masters");
//     if (i>=0 && solution[4][i] == "bier")
//    {
//        //Console.WriteLine("The man who smokes Blue Masters drinks bier.");
//        sum++;

//    }
//     else if(i==-1)
//    {
//        sum--;
//    }

//    // The man who keeps horses lives next to the Dunhill smoker.
//        i = Array.IndexOf(solution[3], "horse");
//         if (i>=0 && solution[2][i - 1] == "Dunhills")
//        {
//            //Console.WriteLine("The man who keeps horses lives next to the Dunhill smoker.");
//            sum++;

//        }
//         else if(i==-1)
//        {
//            sum--;
//        }


//    // The German smokes Prince.

//         i = Array.IndexOf(solution[1], "German");
//         if (i>=0 && solution[2][i] == "Prince")
//        {
//            //Console.WriteLine("The German smokes Prince.");
//            sum++;

//        }
//         else if(i==-1)
//        {
//            sum--;
//        }


//    // The Norwegian lives next to the blue house.

//        i = Array.IndexOf(solution[1], "Norwegian");
//         if (i>=0 && solution[0][i + 1] == "blue")
//        {
//            //Console.WriteLine("The Norwegian lives next to the blue house.");
//            sum++;

//        }
//         else if(i==-1)
//        {
//        sum--;
//        }
//    this.fitness = Math.Round((double)(sum / 14) * 100, 3);
//    this.hasTestYet = true;
//}

//        public bool CheckSingleHouseRule(string key1, string value1, string key2, string value2)
//        {
//            for(var i=0; i < 5; i++)
//            {
//                for(var j=0; j < 5; j++)
//                {
//                    if (solution[i][j] == value1 && solution[i][j] == value2)
//                        return true;
//                }


//                if (solution[i][i] == value1 && solution[i][i] == value2)
//                {
//                    return true;
//                }
//            }
//            foreach (var house in solution)
//            {
//                if (house[Array.IndexOf(key, key1)] == value1 && house[Array.IndexOf(key, key2)] == value2)
//                {
//                    return true;
//                }
//            }
//            return false;
//        }

//        public bool CheckNeighborhoodRules(string House1_key, string House1_value, string House2_key, string House2_value)
//        {
//            for (int i = 0; i < 5; i++)
//            {
//                if (solution[i][Array.IndexOf(key, House1_key)] == House1_value)
//                {
//                    if ((i + 1) % 5 != 0)
//                    {
//                        if (solution[(i + 1)][Array.IndexOf(key, House2_key)] == House2_value)
//                        {
//                            return true;
//                        }
//                    }
//                }
//            }
//            return false;
//        }

//        public bool CheckRuleForExactHouse(int house, string key0, string value)
//        {
//            return solution[house][Array.IndexOf(key, key0)] == value;
//        }


//    }
//}



//    string[] colors = new string[] { "red", "blue", "green", "white", "yellow" };
//    string[] nationality = new string[] { "Englishman", "Swede", "Norwegian", "German", "Dane" };
//    string[] ciagerette = new string[] { "Pall Mall", "Blue Masters", "Prince", "Dunhills", "Blend" };
//    string[] animal = new string[] { "dogs", "birds", "cats", "horse", "fish" };
//    string[] drink = new string[] { "tea", "coffee", "milk", "bier", "water" };