// Trapping Rainwater Problem states that given an array of n non-negative integers arr[] representing an elevation map where the width of each bar is 1, compute how much water it can trap after rain.
//   Input: arr[] = [3, 0, 1, 0, 4, 0, 2]
// Output: 10
// Explanation: The expected rainwater to be trapped is shown in the above image.


// Input: arr[] = [3, 0, 2, 0, 4]
// Output: 7
// Explanation: We trap 0 + 3 + 1 + 3 + 0 = 7 units.


// Input: arr[] = [1, 2, 3, 4]
// Output: 0
// Explanation: We cannot trap water as there is no height bound on both sides


// Input: arr[] = [2, 1, 5, 3, 1, 0, 4]
// Output: 9
// Explanation : We trap 0 + 1 + 0 + 1 + 3 + 4 + 0 = 9 units of water.  

using System;
using System.Collections.Generic;
using System.Linq;
					
public class Program
{
	public static void Main()
	{		
		int[] a = {0, 1, 2, 3, 4, 1, 2, 3, 4, 9};
		int[,] matrix = new int[a.Length,a.Max()];
		
		int water=0, remain=0 , highestSize = a.Max() , finalSum = 0;
		bool start = false;
		List<int> data=new();
		
		for(int i=0;i<a.Length;i++){
			for(int j=0;j<a[i];j++){
				matrix[i,j]=1;
				}
			remain = highestSize-a[i];
			for(int k=a[i];k<highestSize;k++){
				matrix[i,k]=0;
				}		
		}
		
	
	for(int x=highestSize-1;x>=0;x--){
		
			for(int y=0;y<a.Length;y++){
				Console.Write(matrix[y,x]);
				if(matrix[y,x]==1)
					start = true;
				if(start == true && matrix[y,x]==0)
					water++;
				if(start == true && matrix[y,x]==1){ 
					finalSum += water;
					water = 0;
				}
					 
				}
		start = false;
		water = 0;
		Console.WriteLine("");
		
	}
		
	Console.WriteLine("\n\n Trapped Water = "+finalSum);
	
	}
}
