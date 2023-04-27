using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using U = Gene_Test.Utilities;

namespace Gene_Test
{
    using U = Utilities;


    internal class TestObject
    {
        public enum EPreference
        {
            Meat,
            Vegetable
        }

        string name = "";
        Color color = Color.white;
        double size;
        double speed;
        double preference;
        private Gene gene;
        private static readonly Random random = new();

        public Color Color { get { return color; } set { color = value; } }

        public double Size { get => size; set => size = value; }
        public double Speed { get => speed; set => speed = value; }
        internal double Preference { get => preference; set => preference = value; }
        public string Name { get => name; set => name = value; }
        internal Gene Gene { get => gene; set => gene = value; }

        public TestObject(string name, Color color, double size, double speed, double preference)
        {
            Name = name;
            Color = color;
            Size = size;
            Speed = speed;
            Preference = preference;
            Gene = new(this);
        }
        public TestObject(string name, Gene gene)
        {
            Gene = gene;
            Name = name;
            Color = gene.Color;
            Size = gene.Size;
            Speed = gene.Speed;
            Preference = gene.Preference;
        }


        public static TestObject Mating(TestObject a, TestObject b)
        {
            Gene mutantGeneA;
            Gene mutantGeneB;
            if (random.RandomPassing(0.5))
            {
                //mutantGeneA = a.Gene.GeneMutation(0.95, 0.7);
                mutantGeneA = a.Gene.GeneMutation(0.5);
                U.PrintColorFont($"||{a.Name}提供发生变异的基因。||\n变异后的基因与原基因的余弦相似度为：{Gene.CosineSimilarity(a.Gene, mutantGeneA)}\n变异后的基因:\n---\n{mutantGeneA}\n---\n", ConsoleColor.DarkGray);
            }
            else { mutantGeneA = new Gene(a);}
            if (random.RandomPassing(0.5))
            {
                //mutantGeneB = b.Gene.GeneMutation(0.95, 0.7);
                mutantGeneB = b.Gene.GeneMutation(0.5);
                U.PrintColorFont($"||{b.Name}提供发生变异的基因。||\n变异后的基因与原基因的余弦相似度为：{Gene.CosineSimilarity(b.Gene, mutantGeneB)}\n变异后的基因:\n---\n{mutantGeneB}\n---\n", ConsoleColor.DarkGray);
                
            }
            else { mutantGeneB = new Gene(b);}

            Gene newGene = Gene.GeneExchange(mutantGeneA, mutantGeneB);
            TestObject testObject = new(a.Name+b.Name, newGene);
            return testObject;
        }

        public override string ToString()
        {
            return $"{Name}:\n颜色：{Color}\n尺寸：{Size}\n速度：{Speed}\n偏好：{Preference}";
        }

        public void Print()
        {
            Console.WriteLine($"------{Name}--------");

            Console.Write("颜色：");
            Color.PrintColor();
            Console.Write("尺寸：");
            Console.WriteLine(Size);
            Console.Write("速度：");
            Console.WriteLine(Speed);
            Console.Write("偏好：");
            Console.WriteLine(Preference);


            Console.WriteLine($"-----------------\n");
            Console.ResetColor();
        }
        public void Print(ConsoleColor printColor)
        {
            Console.ForegroundColor = printColor;
            Console.WriteLine($"------{Name}--------");

            Console.Write("颜色：");
            Color.PrintColor();
            Console.ForegroundColor = printColor;
            Console.Write("尺寸：");
            Console.WriteLine(Size);
            Console.Write("速度：");
            Console.WriteLine(Speed);
            Console.Write("偏好：");
            Console.WriteLine(Preference);


            Console.WriteLine($"-----------------\n");
            Console.ResetColor();
        }
    }
}
