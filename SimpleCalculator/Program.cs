using System;

namespace SimpleCalculator
{
    class Program
    {
        public static void Main(string[] args)
        {
            string str = Console.ReadLine();
            while (str != null && str.Length > 0)
            {
                try
                {
                    var ast = Parser.Parse(str);
                    Console.WriteLine($"={ast.Value}");
                }
                catch (SyntaxException e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    str = Console.ReadLine();
                }
            }
        }
    }
}
