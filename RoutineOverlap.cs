using System;
using System.Collections.Generic;
using System.Linq;
					
public class Program
{
	public static void Main()
	{		
		
		List<List<int>> a = new()
	{
		new() {1, 5}, new() {3, 7}, new() {8, 10}, new() {2, 6}, new() {15, 18},
		new() {17, 20}, new() {25, 30}, new() {28, 35}, new() {40, 50}, new() {45, 55},
		new() {60, 70}, new() {66, 72}, new() {5, 6}, new() {9, 12}, new() {14, 16},
		new() {11, 13}, new() {100, 200}, new() {150, 170}, new() {180, 190}
	};

		List<List<int>> data = new();
		List<int> temp = new();
		
		a = a.OrderBy(x=>x[0]).ToList();

	int flag = 1 , right = a.Count;
		for(int i=0;i<right;i++){
			flag=1;
			for(int j=0;j<data.Count;j++){
			if(data[j][1]>=a[i][0]){
				if(data[j][1] <= a[i][1])
				data[j][1] = a[i][1];
				
				flag=0;
			}			
				
		}
			if(flag==1)
					data.Add(new() {a[i][0],a[i][1]});
		}
		
		
		Console.WriteLine();
		
		foreach(var d in data)
		Console.WriteLine(d[0]+","+d[1]);
	}
	

}
