using System;
using System.Collections.Generic;
using System.Linq;

namespace Cloudfront_Caching
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr = new string[] { "1 2", "1 3", "2 4", "3 5", "7 8"};
            Console.WriteLine(Cloudfront_Caching(arr, 10));
        }

        static int Cloudfront_Caching(string[] edges, int nodes)
        {
            List<HashSet<string>> Li = new List<HashSet<string>>();
            List<List<string>> split = new List<List<string>>();

            for (int i = 0; i < edges.Length; i++)
            {
                var temp =  edges[i].Split(" ").ToList();
                split.Add( temp );
            }

            for (int i = 0; i < split.Count; i++)
            {
                HashSet<string> HS = new HashSet<string>();
                HS.Add(split[i][0]);
                HS.Add(split[i][1]);
                for (int j = i+1; j < split.Count; j++)
                {
                    if(HS.Contains(split[j][0]) || HS.Contains(split[j][0]))
                    {
                        HS.Add(split[j][0]);
                        HS.Add(split[j][1]);
                        split.RemoveAt(j);
                        j--;
                    }
                }
                Li.Add(HS);
            }

            int effi = 0;
            int NodeCounts = 0;
            for (int i = 0; i < Li.Count; i++)
            {
                int CN = Li[i].Count;
                NodeCounts += CN;
                int PW = (int)Math.Ceiling( Math.Pow(CN, .5));
                effi += PW; 
            }

            return effi + (nodes - NodeCounts);
        }

    }
}
