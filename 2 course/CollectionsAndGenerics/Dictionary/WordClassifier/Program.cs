using System;
using System.Collections.Generic;
using System.IO;

namespace WordClassifier
{
	class Program
	{
		static void Main(string[] args)
		{
            // Write a program that reads words from the "words.txt" file, 
            // saves them to a list and then forms the following dictionary:
            // lower case letter> - <list of words, starting with the letter>
            string[] str = File.ReadAllLines("../../words.txt");
            List<string> list = new List<string>(str); //можно так создать List<> на основе массива!!
            Dictionary<char, List <string>> dictionary = new Dictionary<char, List<string>>();
            List<char> chars = new List<char>();
            
        }
	}
}
