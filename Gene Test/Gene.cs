using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Gene_Test
{
    internal class Gene
    {
        readonly double[] value = new double[6];



        readonly double magnitude;

        public double Magnitude => magnitude;

        public Color Color => new(value[0], value[1], value[2]);
        public double Size => value[3];
        public double Speed => value[4];
        public double Preference => value[5];
        public Gene(TestObject obj)
        {
            value[0] = obj.Color.R;
            value[1] = obj.Color.G;
            value[2] = obj.Color.B;
            value[3] = obj.Size;
            value[4] = obj.Speed;
            value[5] = obj.Preference;
            magnitude = GetMagnitude();
        }
        public Gene(double[] value)
        {
            this.value = value;
        }
        public Gene()
        {
        }

        private static readonly Random random = new();
        /// <summary>
        /// 基因变异。
        /// </summary>
        /// <param name="maxDistance">最大变异量</param>
        /// <returns></returns>
        public Gene GeneMutation(double maxDistance)
        {

            // 生成一个新的Gene对象
            Gene newGene = new(new double[6]);

            // 设置随机数生成器
            Random random = new();

            double offsetMagnitude = 0;
            for (int i = 0; i < value.Length; i++)
            {
                double randomValue = random.NextDouble() * 2 - 1; // 生成范围为[-1, 1)的随机值
                newGene.value[i] = randomValue;
                offsetMagnitude += randomValue * randomValue;
            }

            // 计算随机点到原点的距离
            offsetMagnitude = Math.Sqrt(offsetMagnitude);

            // 生成一个0到maxDistance之间的随机距离
            double randomDistance = Math.Pow(random.NextDouble(), 1.0 / value.Length) * maxDistance;

            // 计算缩放因子
            double scaleFactor = randomDistance / offsetMagnitude;

            // 将随机偏移量添加到原始向量上，得到新的向量
            for (int i = 0; i < value.Length; i++)
            {
                newGene.value[i] = value[i] + newGene.value[i] * scaleFactor;
            }

            return newGene;
        }



        /// <summary>
        /// 基因交换
        /// </summary>
        /// <param name="geneA"></param>
        /// <param name="GeneB"></param>
        /// <returns></returns>
        public static Gene GeneExchange(Gene geneA, Gene GeneB)
        {

            int n = geneA.value.Length;
            double[] newVector = new double[n];

            for (int i = 0; i < n; i++)
            {
                // 在0和1之间生成一个随机数
                double t = random.NextDouble();

                // 对每个元素进行线性插值
                newVector[i] = geneA.value[i] * (1 - t) + GeneB.value[i] * t;
            }
            Gene newGene = new(newVector);

            return newGene;
        }

        /// <summary>
        /// 计算两个Gene实例之间的余弦相似度
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public static double CosineSimilarity(Gene now,Gene other)
        {
            double dotProduct = now * other;
            double magnitudes = now.Magnitude * other.Magnitude;

            return dotProduct / magnitudes;
        }
        /// <summary>
        /// 计算它们之间的欧式距离
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public static double EuclideanDistance(Gene now, Gene other)

        {
            double sum = 0;

            for (int i = 0; i < now.value.Length; i++)
            {
                double diff = now.value[i] - other.value[i];
                sum += diff * diff;
            }

            return Math.Sqrt(sum);
        }


        /// <summary>
        /// 计算基因模长
        /// </summary>
        /// <returns></returns>
        private double GetMagnitude()
        {
            double sum = 0;

            foreach (double val in value)
            {
                sum += val * val;
            }

            return Math.Sqrt(sum);
        }

        public static double operator *(Gene a, Gene b)
        {
            double dotProduct = 0;

            for (int i = 0; i < a.value.Length; i++)
            {
                dotProduct += a.value[i] * b.value[i];
            }

            return dotProduct;
        }

        public override bool Equals(object? obj)
        {
            return obj is Gene gene &&
                   EqualityComparer<double[]>.Default.Equals(value, gene.value);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(value);
        }
        public override string ToString()
        {
            return $"基因:\n颜色：{Color}\n尺寸：{Size}\n速度：{Speed}\n偏好：{Preference}";
        }


    }
}
