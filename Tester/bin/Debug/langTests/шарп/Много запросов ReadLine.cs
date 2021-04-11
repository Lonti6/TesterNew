using System;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
			int sum = 0;
            for(int i = 0; i < 3; i++){
                var str = Console.ReadLine();
				sum += int.Parse(str);
			}
			Console.WriteLine(sum);
        }
    }
}
