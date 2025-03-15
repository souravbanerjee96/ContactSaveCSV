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
    public void Name() { Console.WriteLine("Dog"); }
    public void Sound() { Console.WriteLine("Dog Barks"); }

}

public class Cow : IAnimal
{
    public void Name() { Console.WriteLine("Cow"); }
    public void Sound() { Console.WriteLine("Cow Moos"); }

}

public interface IAnimalFactory
{
    public IAnimal CreateAnimal();
}

public class Dogfactory : IAnimalFactory
{
    public IAnimal CreateAnimal()
    {
        return new Dog();
    }
}

public class Cowfactory : IAnimalFactory
{
    public IAnimal CreateAnimal()
    {
        return new Cow();
    }
}

public class Program
    {
        public static void Main(string[] args)
        {
            IAnimalFactory DogFactory = new Dogfactory();
            IAnimalFactory CowFactory = new Cowfactory();
            IAnimal dog = DogFactory.CreateAnimal();
            IAnimal cow = CowFactory.CreateAnimal();  
            dog.Name();
            cow.Sound();
            Console.WriteLine();
        }
    }
