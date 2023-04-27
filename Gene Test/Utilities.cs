using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Gene_Test
{
    internal static class Utilities
    {
        public static int[] ToArray(this Color color)
        {
            return color.Value.ToArray();
        }
        public static bool RandomPassing(this Random random, double rate)
        {
            if (random.NextDouble() < rate)
                return true;
            else return false;
        }
        public delegate void Pre_function();
        public delegate void Callback();
        public static void PrintColorFont(string str, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(str);
            Console.ResetColor();
        }

        public static void PrintColorFont(string str, ConsoleColor color, Pre_function? pre_Function = null, Callback? callback = null)
        {
            pre_Function?.Invoke();

            Console.ForegroundColor = color;
            Console.WriteLine(str);
            Console.ResetColor();

            callback?.Invoke();
        }
    }
}
