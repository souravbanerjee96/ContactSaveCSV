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
using System.Collections.Concurrent;
using System.Runtime.CompilerServices;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Diagnostics.Metrics;
using System.Text;


public static class Program

{
    public static string AdvancedHashFunction(this string str)
    {
        string salt = "c2FsdGVk";
        string hash = string.Empty;
        string modifiedVal = string.Empty;
        str = salt + str + salt;
        string tempString = str;
        int Counter = 0, maxIteration = 3;
        int decrementReduceString = 10;
        int hashOutputSize = 64;
        while(hash.Length < hashOutputSize || Counter < maxIteration) 
        {
        for (int i = 0; i < tempString.Length; i++)
        {
            modifiedVal += (tempString[i] ^ (tempString[i] << (i + tempString[i]))).ToString();
            modifiedVal = modifiedVal.Replace("-", "");
        }
            hash = modifiedVal[(modifiedVal.Length / decrementReduceString--)..modifiedVal.Length];
            tempString = hash;
            Counter++;
            decrementReduceString = decrementReduceString < 2 ? 10 : decrementReduceString;
        }

        string finalHash = hash[(hash.Length- hashOutputSize)..hash.Length];
        return finalHash;
    }
    public static void Main(string[] args)
    {
        while (true)
        {
            var data = Console.ReadLine();
            Console.WriteLine(data?.AdvancedHashFunction());
        }
    }

}
    
