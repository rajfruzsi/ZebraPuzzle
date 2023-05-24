using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZebraPuzzle.Models
{
    public class Population
    {
        public int populationSize;
        public List<Solution> newPopulation;
        public List<Solution> oldPopulation;
        public int livenes;
        public int genration;

        public Population(int size)
        {
            populationSize = size;
            newPopulation = new List<Solution>();
            oldPopulation = new List<Solution>();
            livenes = 1000;
            genration = 0;
            InitPopulation();
        }

        public int Count => populationSize;

        public override string ToString()
        {
            return $"Generation:{genration}, best fitness:{newPopulation[0]}, average fitness:{GetAverageFitness()}";
        }

        private void InitPopulation()
        {
            for (int i = 0; i < populationSize; i++)
            {
                newPopulation.Add(new Solution());
            }
        }

        public void Start()
        {
            List<int> bestFited = new List<int>();
            oldPopulation = new List<Solution>();
            newPopulation = newPopulation.OrderByDescending(x => x.fitness).ToList();
            for (int i = 0; i < livenes; i++)
            {
                oldPopulation.Add(newPopulation[i]);
            }
            newPopulation.Clear();

            for (int i = 0; i < livenes; i++)
            {
                for (int j = 0; j < oldPopulation.Count(); j++)
                {
                    bestFited.Add(i);
                }
            }

            for (int i = 0; i < populationSize; i++)
            {
                int indexA = BestFitedRandomInt(bestFited);
                int indexB = BestFitedRandomInt(bestFited);
                while (indexA == indexB)
                {
                    indexB = BestFitedRandomInt(bestFited);
                }
                Solution s = new Solution();
                s.Call(oldPopulation[indexA], oldPopulation[indexB]);
                newPopulation.Add(s);
            }
            genration += 1;
        }

        public Solution GetBestFitted()
        {
            return newPopulation[0];
        }

        private double GetAverageFitness()
        {
            double sumFitnes = 0.0;
            foreach (Solution solution in newPopulation)
            {
                sumFitnes += (double)solution.fitness;
            }
            return Math.Round(sumFitnes / populationSize, 2);
        }

        private int BestFitedRandomInt(List<int> bestFited)
        {
            Random rnd = new Random();
            int index = rnd.Next(bestFited.Count);
            return bestFited[index];
        }

        private Solution HeapqHeappop(List<Solution> heap)
        {
            int last = heap.Count - 1;
            Solution popValue = heap[0];
            heap[0] = heap[last];
            heap.RemoveAt(last);
            int currentIndex = 0;
            while (true)
            {
                int leftChildIndex = currentIndex * 2 + 1;
                int rightChildIndex = currentIndex * 2 + 2;

                if (leftChildIndex >= last)
                {
                    break;
                }

                int minIndex = leftChildIndex;
                if (rightChildIndex < last && heap[rightChildIndex].fitness < heap[leftChildIndex].fitness)
                {
                    minIndex = rightChildIndex;
                }

                if (heap[minIndex].fitness > heap[currentIndex].fitness)
                {
                    break;
                }

                Solution temp = heap[minIndex];
                heap[minIndex] = heap[currentIndex];
                heap[currentIndex] = temp;
                currentIndex = minIndex;
            }

            return popValue;
        }


    }
}