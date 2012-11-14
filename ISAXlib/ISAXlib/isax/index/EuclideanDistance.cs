using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ISAXlib.isax.index
{
    class EuclideanDistance
    {
        // Tính khoảng cách Euclidean giữa 2 điểm
        private static double distance(double p1, double p2)
        {
            return Math.Sqrt((p1 - p2) * (p1 - p2));
        }

        // Tính khoảng cách Euclidean giữa hai điểm n vectơ
        private static double distance(double[] point1, double[] point2)
        {
            if (point1.Length == point2.Length)
            {
                Double sum = 0;
                for (int i = 0; i < point1.Length; i++)
                {
                    sum = sum + (point2[i] - point1[i]) * (point2[i] - point1[i]);
                }
                return Math.Sqrt(sum);
            }
            else
            {
                throw new ArgumentException("Exception in Euclidean distance : array lengths are not equal");
            }
        }

        // Tính khoảng cách Euclidean giữa hai chuỗi thời gian có chiều dài bằng nhau
        public static double seriesDistance(double[] query, double[] template)
        {
            if (query.Length == template.Length)
            {
                double res = 0;
                for (int i = 0; i < query.Length; i++)
                    res = res + (query[i] - template[i]) * (query[i] - template[i]);
                return Math.Sqrt(res);
            }
            else
            {
                throw new ArgumentException("Exception in Euclidean distance: array length are not equal");
            }
        }
    }
}
