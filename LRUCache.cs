using System;
using System.Collections.Generic;
using System.Linq;
					
public class Program
{
	public static int cacheSize = 2, priorityFlag = 0;
	public static Dictionary<int,int> cache = new();
	public static Dictionary<int,int> priority = new();
	public static void Put(int x,int y) {
		if(cache.Count()>=cacheSize)
		{
			var least = priority.Min(x=>x.Value);
			var  keyToRemove = priority.Where(x=>x.Value==least).Select(x=> new{ key = x.Key }).FirstOrDefault();
			//Console.WriteLine("keyToRemove = "+ keyToRemove.key);
			cache.Remove(keyToRemove.key);
			priority.Remove(keyToRemove.key);
		}
		cache.Add(x,y);
		priority.Add(x,priorityFlag++);
    	//GetPriority();
	}
	public static void Get(int z) {
		int x = 0;
		if(cache.TryGetValue(z,out x)){
			//priority[priorityFlag] = 0;
			priority[z]=priorityFlag++;
			Console.WriteLine("Found = "+x);
			//GetPriority();
		}	
		else
			Console.WriteLine("Not Found = "+ -1);
		//priority.Add(x,priorityFlag++);
	}
	public static void GetPriority() {
		foreach(var d in priority)
			Console.WriteLine(d);
		
			Console.WriteLine("==============");
	}
	public static void Main()
	{		
		Put(1, 100);
		Put(2, 200);
		Get(1);
		Put(3, 300);
		Get(2);
		Put(4, 400);
		Get(3);
		Get(4);
	}
	

}
