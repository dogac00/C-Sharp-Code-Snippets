using System;

namespace ConsoleApp1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Action<IAnimal> animalConsumer = Console.WriteLine;
            Action<IDog> dogConsumer = Console.WriteLine;

            dogConsumer = animalConsumer;
        }
    }

    interface IAnimal
    {
        
    }

    interface IDog : IAnimal
    {
        
    }
}
