using System;

namespace Randomize
{
    class Program
    {
        static void Main(string[] args)
        {
            while(true)
            {
                Console.WriteLine("1. Range");
                Console.WriteLine("2. Select");
                Console.WriteLine("0. Exit");
                int opt = GetAnswer("Choose one: ");
                switch(opt)
                {
                    case 1: FuncRange();
                        break;
                    case 2: FuncSelect();
                        break;
                    case 0:
                        Environment.Exit(0);
                        break;
                }
                Console.WriteLine("==========================");
            }
            
        }

        static void FuncRange()
        {
            int least = GetAnswer("The least number: ");
            int greatest = GetAnswer("The greatest number: ");
            int count = GetAnswer("Count: ");
            Random r = new Random();
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(r.Next(least, greatest));
            }
        }

        static void FuncSelect()
        {
            retry:
            Console.Write("Your options: ");
            string s = Console.ReadLine();
            s.Replace(" ", "");
            string[] ss = s.Split(",");
            if(ss == null || ss.Length == 0)
            {
                goto retry;
            }
            Random r = new Random();
            foreach(string item in ss)
            {
                int i = 0;
                if(int.TryParse(item, out i))
                {
                    if(r.NextDouble() > 0.5)
                    {
                        Console.WriteLine(i);
                        return;
                    }
                }
            }
            Console.WriteLine(ss[ss.Length - 1]);
        }

        static int GetAnswer(String question)
        {
            Console.Write(question);
            string s = Console.ReadLine();
            int i = 0;
            while (!int.TryParse(s, out i))
            {
                Console.WriteLine(question);
                s = Console.ReadLine();
            }
            return i;
        }
    }
}
