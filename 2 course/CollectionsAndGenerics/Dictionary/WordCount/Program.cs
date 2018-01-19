using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            // A dictionary that will store the number of occurences of each word in a sentence
            Dictionary<string, int> wordCount = new Dictionary<string, int>();

            string sentence = "The rain in Spain stays mainly in the plain";

            string[] words = sentence.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            
            foreach(var word in words)
            {
                var wordLow = word.ToLower();
                if (wordCount.ContainsKey(wordLow))
                    wordCount[wordLow]++;
                else
                    wordCount[wordLow] = 1; //эта ветка - если нет такого слова-ключа, то создаем новую пару
            }

            foreach(var item in wordCount)
            {
                Console.WriteLine("{0}: {1} time(s)", item.Key, item.Value);
            }
            wordCount.Remove("in");
            Console.ReadKey(); // удаление происходит по ключу, автоматически удаляется весь item
        }
    }
}
