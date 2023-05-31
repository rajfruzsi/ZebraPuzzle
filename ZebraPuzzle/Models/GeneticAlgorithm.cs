
namespace ZebraPuzzle.Models
{
    public class GeneticAlgorithm
    {
        public int populationSize;
        public List<Member> newPopulation;
        public const int MUTATION_PROBABILITY = 20; // %
        public List<Member> oldPopulation;
        public int liveness;
        public int generation;
        public int generationSize;
        private static string[] key = new string[] { "nation", "color", "drink", "smoke", "pet" };

        public GeneticAlgorithm(int populationsize, int generationsize, int livenessSize)
        {
            populationSize = populationsize;
            generationSize = generationsize;
            newPopulation = new List<Member>();
            oldPopulation = new List<Member>();
            liveness = livenessSize;
            generation = 0;
            InitPopulation();
        }

        public override string ToString()
        {
            return $"Generation:{generation}, best fitness:{newPopulation[0]}average fitness:{GetAverageFitness()}";
        }

        public void Start()
        {
            for (int gen = 0; gen < generationSize; gen++)
            {
                var tempPopulation = new List<Member>();
                for (int i = 0; i < populationSize; i++)
                {
                    var parents = ChooseParents();
                    var crossOver = Crossover(parents.Item1, parents.Item2, newPopulation[i]);
                    var mutated = Mutate(crossOver);
                    mutated.GetFitness();
                    tempPopulation.Add(mutated);
                }
                SurvivorSelection(tempPopulation);
                Console.WriteLine(this);
                Console.WriteLine(newPopulation[0].fitness);
                generation = gen;
                if (newPopulation[0].fitness == 100) break;
            }
            Console.WriteLine("done");
        }

        private void InitPopulation()
        {
            for (int i = 0; i < populationSize; i++)
            {
                newPopulation.Add(new Member());
            }
        }
        private Tuple<Member, Member> ChooseParents()
        {
            var a = GetTournamentBestMember();
            var b = GetTournamentBestMember();
            while (a == b)
            {
                b = GetTournamentBestMember();
            }
            return Tuple.Create(a, b);
        }

        private Member GetTournamentBestMember()
        {
            var bestMemberList = new List<Member>();
            for (var i = 0; i < 5; i++)
            {
                Random rnd = new Random();
                bestMemberList.Add(newPopulation[rnd.Next(newPopulation.Count)]);
            }
            return bestMemberList.OrderByDescending(x => x.GetFitness()).FirstOrDefault();
        }

        private Member Crossover(Member partnerA, Member partnerB, Member temp)
        {
            foreach (string i in key)
            {
                Random rnd = new Random();

                int pivot = rnd.Next(0, 100);
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
                    temp.solution[j][i] = tempSolution[j][i];
                }
            }
            return temp;
        }
        public Member Mutate(Member temp)
        {
            Random rnd = new Random();
            if (rnd.Next(0, 100) <= MUTATION_PROBABILITY)
            {
                int tempValueIndex = rnd.Next(0, 5);
                int newIndex = rnd.Next(0, 5);
                while (tempValueIndex == newIndex)
                {
                    newIndex = rnd.Next(0, 5);
                }
                if (newIndex != tempValueIndex)
                {
                    string keyToMutate = key[rnd.Next(0, 5)];
                    string tempValue = temp.solution[tempValueIndex][keyToMutate];
                    temp.solution[tempValueIndex][keyToMutate] = temp.solution[newIndex][keyToMutate];
                    temp.solution[newIndex][keyToMutate] = tempValue;
                }
            }
            return temp;
        }

        private void SurvivorSelection(List<Member> tempPopulation)
        {
            tempPopulation = tempPopulation.OrderByDescending(x => x.fitness).ToList();
            for (int j = 0; j < liveness; j++)
            {
                newPopulation[j] = tempPopulation[j];
            }
        }

        private double GetAverageFitness()
        {
            double sumFitnes = 0.0;
            foreach (Member solution in newPopulation)
            {
                sumFitnes += (double)solution.fitness;
            }
            return Math.Round(sumFitnes / populationSize, 2);
        }
    }
}