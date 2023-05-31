using ZebraPuzzle.Models;

class Program
{
    static void Main(string[] args)
    {
        var ga = new GeneticAlgorithm(10000,1000,1000);
        ga.Start();
        Console.WriteLine("done");
        Console.WriteLine(ga);
    }

}