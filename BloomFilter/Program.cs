using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloomFilter
{
    interface a
    {
        int MyProperty { get; set; }
    }

    interface b:a
    {
    }


    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Read Words
                string[] words = File.ReadAllLines(@"E:\Learning\Bloom Filter\C#\BloomFilter\AllWords2.txt");

                string wordtoFind = "Zweig";
                bool status = false;

                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                // Search without Bloom Filter. 
                for (int i = 0; i < words.Length; i++)
                {
                    if (wordtoFind.Equals(words[i]))
                    {
                        status = true;
                        break;
                    }
                }
                stopwatch.Stop();
                Console.Error.WriteLine("Usual Filter: {0} {1}", stopwatch.ElapsedMilliseconds, status);

                // Sreach using Bloom Filter.
                MyBloomFilter filter = new MyBloomFilter(words.Length); ;
                foreach (string item in words)
                {
                    filter.Add(item);
                }

                stopwatch.Restart();
                status = false;
                status = filter.Contains(wordtoFind);
                stopwatch.Stop();
                Console.Error.WriteLine("Bloom Filter: {0} {1}", stopwatch.ElapsedMilliseconds, status);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
