using System;
using System.Collections.Generic;
using System.Linq;
using ZebraPuzzle.Models;

class Program
{
    static void Main(string[] args)
    {
        int n_population = 100;
        int liveness = 20;
        int mutants = 4;
        double fail_score = 0.5;
        int punish_score = 1;
        int liveness_probability = 70;
        var population = new Population(10000);
        for(var i = 0; i < 1200; i++)
        {
            population.Start();
            Console.WriteLine(population);
            Console.WriteLine(population.GetBestFitted().fitness);
            if(population.GetBestFitted().fitness>=100)
            {
                Console.WriteLine("done");
                break;
            }
        }
        Console.WriteLine("done");
        Console.WriteLine(population);
    }


    //class Table
    //{
    //    public string[][] valueTable = new string[5][] { new string[] { "", "", "", "", "" },
    //         new string[] { "", "", "", "", "" },
    //        new string[] { "", "", "", "", "" },
    //         new string[] { "", "", "", "", ""},
    //        new string[] { "", "", "", "", "" } };
    //    public double score = 20;
    //    public int approve = 0;
    //    public int punish_score = 1;
    //    double fail_score = 0.5;


    //    string[] colors = new string[] { "red", "blue", "green", "white", "yellow" };
    //    string[] nationality = new string[] { "Englishman", "Swede", "Norwegian", "German", "Dane" };
    //    string[] ciagerette = new string[] { "Pall Mall", "Blue Masters", "Prince", "Dunhills", "Blend" };
    //    string[] animal = new string[] { "dogs", "birds", "cats", "horse", "fish" };
    //    string[] drink = new string[] { "tea", "coffee", "milk", "bier", "water" };

    //    string[][] tableProto = new string[5][] { new string[] { "red", "blue", "green", "white", "yellow" },
    //         new string[] { "Englishman", "Swede", "Norwegian", "German", "Dane" },
    //        new string[] { "Pall Mall", "Blue Masters", "Prince", "Dunhills", "Blend" },
    //         new string[] { "dogs", "birds", "cats", "horse", "fish" },
    //        new string[] { "tea", "coffee", "milk", "bier", "water" } };

    //    public Table()
    //    {
    //    }

    //    public double GetScore()
    //    { return score; }

    //    public string  Get(int x, int y)
    //    {
    //        return this.valueTable[x][y];
    //    }
    //    public void RandFill()
    //    {
    //        Random rnd = new Random();
    //        for (int i = 0; i < 5; i++)
    //        {
               
    //            for (int j = 0; j < 5; j++)
    //            {
    //               valueTable[i][j] = tableProto[i][rnd.Next(5)];
    //            }
    //        }
    //    }

    //    public void Mutate()
    //    {
    //        Random rnd = new Random();
    //        int x = rnd.Next(5);
    //        int y = rnd.Next(5);
    //        var temp = valueTable[x][y];
    //        valueTable[x][y] = valueTable[x][(y + 1) % 5];
    //        valueTable[x][(y + 1) % 5] = temp;
    //        valueTable[x] = valueTable[x].OrderBy(z => rnd.Next()).ToArray();
    //    }

    //    public void Test()
    //    {

    //        // Check consistency
    //        for (int x = 0; x < 5; x++)
    //        {
    //            if (valueTable[x].Count() != this.valueTable[x].Distinct().Count())
    //            {
    //                this.score -= 2 * punish_score;
    //            }
    //        }
    //        try
    //        {

    //            int i = GetIndex(valueTable,"Englishman", 1);
    //            if (valueTable[0][i] == "red")
    //            {
    //                //Console.WriteLine("The Englishman lives in the red house.");
    //                score++;
    //                approve++;
    //            }
    //            else
    //            {
    //                score -= fail_score;
    //            }
    //        }
    //        catch (Exception e)
    //        {
    //            score -= punish_score;
    //        }

    //        //The Swede keeps dogs.
    //        try
    //        {
    //            int i = GetIndex(valueTable, "Swede", 1);
    //            if (valueTable[3][i] == "dogs")
    //            {
    //                //Console.WriteLine("The Swede keeps dogs");
    //                score++;
    //                approve++;
    //            }
    //            else
    //            {
    //                score -= fail_score;
    //            }
    //        }
    //        catch (Exception e)
    //        {
    //            score -= punish_score;
    //        }

    //        //The Dane drinks tea.
    //        try
    //        {
    //            int i = GetIndex(valueTable, "Dane", 1);
    //            if (valueTable[4][i] == "tea")
    //            {
    //                //Console.WriteLine("The Dane drinks tea");
    //                score++;
    //                approve++;
    //            }
    //            else
    //            {
    //                score -= fail_score;
    //            }
    //        }
    //        catch (Exception e)
    //        {
    //            score -= punish_score;
    //        }

    //        //The green house is just to the left of the white one.
    //        try
    //        {
    //            int i = GetIndex(valueTable, "green", 0);
    //            if (valueTable[0][i + 1] == "white")
    //            {
    //                //Console.WriteLine("The green house is just to the left of the white one.");
    //                score++;
    //                approve++;
    //            }
    //            else
    //            {
    //                score -= fail_score;
    //            }
    //        }
    //        catch (Exception e)
    //        {
    //            score -= punish_score;
    //        }

    //        //The owner of the green house drinks coffee.
    //        try
    //        {
    //            int i = GetIndex(valueTable, "green", 0);
    //            if (valueTable[4][i] == "coffee")
    //            {
    //                //Console.WriteLine("The owner of the green house drinks coffee.");
    //                score++;
    //                approve++;
    //            }
    //            else
    //            {
    //                score -= fail_score;
    //            }
    //        }
    //        catch (Exception e)
    //        {
    //            score -= punish_score;
    //        }

    //        //The Pall Mall smoker keeps birds.
    //        try
    //        {
    //            int i = GetIndex(valueTable, "Pall Mall", 2);;
    //            if (valueTable[3][i] == "birds")
    //            {
    //                //Console.WriteLine("The Pall Mall smoker keeps birds.");
    //                score++;
    //                approve++;
    //            }
    //            else
    //            {
    //                score -= fail_score;
    //            }
    //        }
    //        catch (Exception e)
    //        {
    //            score -= punish_score;
    //        }

    //        //The owner of the yellow house smokes Dunhills.
    //        try
    //        {
    //            int i = GetIndex(valueTable, "yellow", 0);
    //            if (valueTable[2][i] == "Dunhills")
    //            {
    //                //Console.WriteLine("The owner of the yellow house smokes Dunhills.");
    //                score++;
    //                approve++;
    //            }
    //            else
    //            {
    //                score -= fail_score;
    //            }
    //        }
    //        catch (Exception e)
    //        {
    //            score -= punish_score;
    //        }

    //        //The man in the center house drinks milk.
    //        try
    //        {
    //            if (valueTable[4][2] == "milk")
    //            {
    //                //Console.WriteLine("The man in the center house drinks milk.");
    //                score++;
    //                approve++;
    //            }
    //            else
    //            {
    //                score -= fail_score;
    //            }
    //        }
    //        catch (Exception e)
    //        {
    //            score -= punish_score;
    //        }

    //        //The Norwegian lives in the first house.
    //        try
    //        {
    //            if (valueTable[1][0] == "Norwegian")
    //            {
    //                //Console.WriteLine("The Norwegian lives in the first house.");
    //                score++;
    //                approve++;
    //            }
    //            else
    //            {
    //                score -= fail_score;
    //            }
    //        }
    //        catch (Exception e)
    //        {
    //            score -= punish_score;
    //        }
    //        try
    //        {
    //            int i = Array.IndexOf(valueTable[2], "Blend");
    //            if (i == 0)
    //            {
    //                if (valueTable[3][i + 1] == "cats")
    //                {
    //                    //Console.WriteLine("The Blend smoker has a neighbor who keeps cats.");
    //                    score++;
    //                    approve++;
    //                }
    //                else
    //                {
    //                    score -= fail_score;
    //                }
    //            }
    //            else if (i == 4)
    //            {
    //                if (valueTable[3][i - 1] == "cats")
    //                {
    //                    //Console.WriteLine("The Blend smoker has a neighbor who keeps cats.");
    //                    score++;
    //                    approve++;
    //                }
    //                else
    //                {
    //                    score -= fail_score;
    //                }
    //            }
    //            else
    //            {
    //                if (valueTable[3][i + 1] == "cats" || valueTable[3][i - 1] == "cats")
    //                {
    //                    //Console.WriteLine("The Blend smoker has a neighbor who keeps cats.");
    //                    score++;
    //                    approve++;
    //                }
    //                else
    //                {
    //                    score -= fail_score;
    //                }
    //            }
    //        }
    //        catch (Exception e)
    //        {
    //            score -= punish_score;
    //        }

    //        // The man who smokes Blue Masters drinks bier.
    //        try
    //        {
    //            int i = Array.IndexOf(valueTable[2], "Blue Masters");
    //            if (valueTable[4][i] == "bier")
    //            {
    //                //Console.WriteLine("The man who smokes Blue Masters drinks bier.");
    //                score++;
    //                approve++;
    //            }
    //            else
    //            {
    //                score -= fail_score;
    //            }
    //        }
    //        catch (Exception e)
    //        {
    //            score -= punish_score;
    //        }

    //        // The man who keeps horses lives next to the Dunhill smoker.
    //        try
    //        {
    //            int i = Array.IndexOf(valueTable[3], "horse");
    //            if (valueTable[2][i - 1] == "Dunhills")
    //            {
    //                //Console.WriteLine("The man who keeps horses lives next to the Dunhill smoker.");
    //                score++;
    //                approve++;
    //            }
    //            else
    //            {
    //                score -= fail_score;
    //            }
    //        }
    //        catch (Exception e)
    //        {
    //            score -= punish_score;
    //        }

    //        // The German smokes Prince.
    //        try
    //        {
    //            int i = Array.IndexOf(valueTable[1], "German");
    //            if (valueTable[2][i] == "Prince")
    //            {
    //                //Console.WriteLine("The German smokes Prince.");
    //                score++;
    //                approve++;
    //            }
    //            else
    //            {
    //                score -= fail_score;
    //            }
    //        }
    //        catch (Exception e)
    //        {
    //            score -= punish_score;
    //        }

    //        // The Norwegian lives next to the blue house.
    //        try
    //        {
    //            int i = Array.IndexOf(valueTable[1], "Norwegian");
    //            if (valueTable[0][i + 1] == "blue")
    //            {
    //                //Console.WriteLine("The Norwegian lives next to the blue house.");
    //                score++;
    //                approve++;
    //            }
    //            else
    //            {
    //                score -= fail_score;
    //            }
    //        }
    //        catch (Exception e)
    //        {
    //            score -= punish_score;
    //        }
    //    }


    //    private int GetIndex(string[][] valueTable, string search, int row)
    //    {
            
    //            for (int y = 0; y < 5; ++y)
    //                if (valueTable[row][y].Equals(search))
    //                    return y;
    //        return -1;
    //    }
    //}

    //public class Puzzle
    //{
    //    private List<Table> population;
    //    int liveness_probability;

    //    public Puzzle()
    //    {
    //        population = new List<Table>();
    //    }

    //    public void Solve(int n_population, int liveness, int mutants, int liveness_probability)
    //    {
    //        this.liveness_probability = liveness_probability;
    //        Generate(n_population);
    //        int x = 0;

    //        while (true)
    //        {
    //            x++;
    //            Console.WriteLine("Iteration {0}", x);
    //            Test();
    //            int approve = population[0].approve;
    //            CrossOver(liveness, n_population);
    //            Mutate(mutants);

    //            if (approve >= 14)
    //            {
    //                break;
    //            }
    //        }

    //        Test();
    //        Console.WriteLine(population[0].valueTable);
    //        Console.WriteLine(population[0].approve);
    //    }

    //    private void Mutate(int mutants)
    //    {
    //        Random random = new Random();
    //        for (int x = 0; x < mutants; x++)
    //        {
    //            int y = random.Next(0, population.Count-1);
    //            population[y].Mutate();
    //        }
    //    }

    //    private void Generate(int i)
    //    {
    //        for (int x = 0; x < i; x++)
    //        {
    //            Table newborn = new Table();
    //            newborn.RandFill();
    //            population.Add(newborn);
    //        }
    //    }

    //    private void CrossOver(int liveness, int limit)
    //    {
    //        List<Table> goodPopulation = new List<Table>();
    //        int i = 0;
    //        while (goodPopulation.Count < liveness)
    //        {
    //            if (new Random().Next(0, 100) < liveness_probability)
    //            {
    //                goodPopulation.Add(population[i]);
    //            }
    //            i++;
    //            i %= population.Count;
    //        }

    //        List<Table> newGeneration = new List<Table>();
    //        while (newGeneration.Count <= limit)
    //        {
    //            Table first = goodPopulation[new Random().Next(0, goodPopulation.Count-1)];
    //            Table second = goodPopulation[new Random().Next(0, goodPopulation.Count-1)];
    //            Table third = goodPopulation[new Random().Next(0, goodPopulation.Count-1)];
    //            Table newborn = Cross(first, second, third);
    //            newGeneration.Add(newborn);
    //        }

    //        population = newGeneration;
    //    }

    //    private Table Cross(Table first, Table second, Table third)
    //    {
    //        Table newborn = new Table();
    //        //newborn.RandFill();
    //        for (int x = 0; x < 5; x++)
    //        {
    //            for (int y = 0; y < 5; y++)
    //            {
    //                int i = new Random().Next(0, 3);
    //                if (i == 0)
    //                {
    //                    newborn.valueTable[x][y] = first.Get(x, y);
    //                }
    //                else if (i == 1)
    //                {
    //                    newborn.valueTable[x][y] = second.Get(x, y);
    //                }
    //                else
    //                {
    //                    newborn.valueTable[x][y] = third.Get(x, y);
    //                }
    //            }
    //        }

    //        return newborn;
    //    }

    //    private void Test()
    //    {
    //        foreach (Table t in population)
    //        {
    //            t.Test();
    //        }

    //        population.Sort((x, y) => y.GetScore().CompareTo(x.GetScore()));
    //        for (int x = 0; x < 1; x++)
    //        {
    //            Console.WriteLine(population[x].approve);
    //        }
    //    }
    //}

 


}