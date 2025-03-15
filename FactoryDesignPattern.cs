using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Caching;
using Microsoft.AspNetCore.Builder;
using System.Runtime.InteropServices;
using Microsoft.Extensions.Primitives;

public interface IAnimal
{
    public void Sound();
    public void Name();
}

public class Dog : IAnimal
{
    public Dog() { }
    public void Name() { Console.WriteLine("Dog"); }
    public void Sound() { Console.WriteLine("Dog Barks"); }

}

public class Cow : IAnimal
{
    public Cow() { }
    public void Name() { Console.WriteLine("Cow"); }
    public void Sound() { Console.WriteLine("Cow Moos"); }

}

public class AnimalFactory()
{
    public IAnimal Animal(string type)
    {
        switch (type.ToLower())
        {
            case "dog":
                return new Dog();
            case "cow":
                return new Cow();
            default:
                throw new NotImplementedException("Class not implemented");
        }
    }
}

    public class Program
    {
        public static void Main(string[] args)
        {
            AnimalFactory animalFactory = new();
            IAnimal dog = animalFactory.Animal("Dog");
            IAnimal cow = animalFactory.Animal("Cow");  
            dog.Name();
            cow.Sound();
            Console.WriteLine();
        }
    }
