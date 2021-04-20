using System;
using System.Collections.Generic;

namespace forTests
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = Console.ReadLine();
            string sym = "";
            List<int> l = new List<int> { };
            Dictionary<string, int> sl = new Dictionary<string, int> { };
            for (int x = 0; x<a.Length; x++) 
            {
                if (a[x] != ' ' && a[x] != '0')
                {
                    sym += a[x].ToString();
                }
                else
                {
                    if (sl.ContainsKey(sym)) sl[sym]++;
                    else sl.Add(sym, 1);
                    sym = "";
                }
            }
            sym = "";
            foreach (var q in sl) 
            {
                if (q.Value >= 2)
                {
                    sl.Remove(q.Key);
                }
                else l.Add(int.Parse(q.Key));
            }
            l.Sort();
            Console.WriteLine("a");
        }
    }
}