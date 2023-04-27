using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gene_Test
{
    internal class Color
    {
        public static readonly Color white = new(255, 255, 255);
        public static readonly Color black = new(0, 0, 0);
        public static readonly Color red = new(255, 0, 0);
        public static readonly Color green = new(0, 255, 0);
        public static readonly Color blue = new(0, 0, 255);

        int[] _value = new int[3];
        public Color(double r, double g, double b)
        {
            Value[0] = (int)r; Value[1] = (int)g; Value[2] = (int)b;
        }
        public int[] Value { get => _value; set => _value = value; }
        public Color(int[] value) { Value = value; }
        public int R { get => Value[0]; }
        public int G { get => Value[1]; }
        public int B { get => Value[2]; }


        public override string ToString()
        {
            return $"[R:{R} G:{G} B:{B}]";
        }
        public void PrintColor()
        {
            //Console.WriteLine();
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"R:{R} ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"G:{G} ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write($"B:{B}");
            Console.ResetColor();
            Console.WriteLine($"]");
        }
        public override bool Equals(object? obj)
        {
            return obj is Color color &&
                   EqualityComparer<int[]>.Default.Equals(_value, color._value);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_value);
        }
    }
}
