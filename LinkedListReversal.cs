using System;
using System.Collections.Generic;
using System.Linq;
					
public class Program
{
	public static void Main()
	{	LinkedList<int> data = new();
		int[] bigNumbers = { 101, 202, 303, 404, 505, 606, 707, 808, 909, 1001 };

		foreach (var num in bigNumbers)
    		data.AddLast(num);
	 
	 Console.WriteLine("=========Before========\n");
	  foreach(var d in data)
		 Console.WriteLine(d); 
	 Console.WriteLine("=========After========\n");
	 
	LinkedListNode<int> first = data.First;
	 
	for(int i = 0; i< data.Count()-1 ; i++){
		var valueholdingLast = data.Last;
		data.Remove(data.Last);
		data.AddBefore(first,valueholdingLast);
		first = valueholdingLast.Next;
	}
	 
	 foreach(var d in data)
		 Console.WriteLine(d);
	 
		
	}
	

}
