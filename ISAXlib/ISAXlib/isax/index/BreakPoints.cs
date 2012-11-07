using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ISAXlib.isax.index
{
    class BreakPoints
    {
        public BreakPoints();
        public static double[] getBreakPoints(int alphabet_size)
        {
            double[] break_points = null;
            switch (alphabet_size)
            {
                case 2: break_points = new double[] { 0 }; break;
                case 3: break_points = new double[] { -0.43, 0.43 }; break;
                case 4: break_points = new double[] { -0.67, 0, 0.67 }; break;
                case 5: break_points = new double[] { -0.84, -0.25, 0.25, 0.84 }; break;
                case 6: break_points = new double[] { -0.97, -0.43, 0, 0.43, 0.97 }; break;
                case 7: break_points = new double[] { -1.07, -0.57, -0.18, 0.18, 0.57, 1.07 }; break;
                case 8: break_points = new double[] { -1.15, -0.67, -0.32, 0, 0.32, 0.67, 1.15 }; break;
                case 9: break_points = new double[] { -1.22, -0.76, -0.43, -0.14, 0.14, 0.43, 0.76, 1.22 }; break;
                case 10: break_points = new double[] { -1.28, -0.84, -0.52, -0.25, 0, 0.25, 0.52, 0.84, 1.28 }; break;
                case 11: break_points = new double[] { -1.34, -0.91, -0.6, -0.35, -0.11, 0.11, 0.35, 0.6, 0.91, 1.34 }; break;
                case 12: break_points = new double[] { -1.38, -0.97, -0.67, -0.43, -0.21, 0, 0.21, 0.43, 0.67, 0.97, 1.38 }; break;
                case 13: break_points = new double[] { -1.43, -1.02, -0.74, -0.5, -0.29, -0.1, 0.1, 0.29, 0.5, 0.74, 1.02, 1.43 }; break;
                case 14: break_points = new double[] { -1.47, -1.07, -0.79, -0.57, -0.37, -0.18, 0, 0.18, 0.37, 0.57, 0.79, 1.07, 1.47 }; break;
                case 15: break_points = new double[] { -1.5, -1.11, -0.84, -0.62, -0.43, -0.25, -0.08, 0.08, 0.25, 0.43, 0.62, 0.84, 1.11, 1.5 }; break;
                case 16: break_points = new double[] { -1.53, -1.15, -0.89, -0.67, -0.49, -0.32, -0.16, 0, 0.16, 0.32, 0.49, 0.67, 0.89, 1.15, 1.53 }; break;
                case 17: break_points = new double[] { -1.56, -1.19, -0.93, -0.72, -0.54, -0.38, -0.22, -0.07, 0.07, 0.22, 0.38, 0.54, 0.72, 0.93, 1.19, 1.56 }; break;
                case 18: break_points = new double[] { -1.59, -1.22, -0.97, -0.76, -0.59, -0.43, -0.28, -0.14, 0, 0.14, 0.28, 0.43, 0.59, 0.76, 0.97, 1.22, 1.59 }; break;
                case 19: break_points = new double[] { -1.62, -1.25, -1, -0.8, -0.63, -0.48, -0.34, -0.2, -0.07, 0.07, 0.2, 0.34, 0.48, 0.63, 0.8, 1, 1.25, 1.62 }; break;
                case 20: break_points = new double[] { -1.64, -1.28, -1.04, -0.84, -0.67, -0.52, -0.39, -0.25, -0.13, 0, 0.13, 0.25, 0.39, 0.52, 0.67, 0.84, 1.04, 1.28, 1.64 }; break;
                default: throw new System.ArgumentException("Error! alphabet_size is too big!");
            }
            return break_points;
        }
    }

}