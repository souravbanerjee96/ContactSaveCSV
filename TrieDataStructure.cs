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

public class TrieNode
{
    public Dictionary<char, TrieNode> children = [];
    public bool isEndofWord = false;
}
public class Trie
{
    public TrieNode root;
    public Trie()
    {
        root = new TrieNode();
    }

    public void Insert(string data)
    {
        TrieNode node = root;
        foreach(char ch in data)
        {
            if (!node.children.ContainsKey(ch))
                node.children[ch] = new TrieNode();
            node = node.children[ch];
        }
        node.isEndofWord = true;
    }

    public bool Search(string data)
    {
        TrieNode node = root;
        foreach (char ch in data)
        {
            if (!node.children.ContainsKey(ch))
                return false;
            node = node.children[ch];
        }
        return node.isEndofWord;
    }

    public List<string> StartsWith(string data)
    {
        TrieNode node = root;
        List<string> results = [];
        foreach (char ch in data)
        {
            if (!node.children.ContainsKey(ch))
                return results;
            node = node.children[ch];
        }
        DFS(node, data, results);
        return results;
    }

    private void DFS(TrieNode node, string prefix, List<string> results)
    {
        if (node.isEndofWord == true) results.Add(prefix);

        foreach (var child in node.children)
            DFS(child.Value,prefix + child.Key, results);

    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Trie tree = new();
        tree.Insert("hello");
        tree.Insert("hepatitis");
        tree.Insert("house");
        tree.Insert("honey");
        tree.Insert("hobby");

        //Console.WriteLine(tree.Search("bye"));
        Console.WriteLine(string.Join(",",tree.StartsWith("ho")));
    }
}
