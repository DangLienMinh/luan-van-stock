using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ISAXlib.logic.math
{
    //Thực hiện phương pháp cho chuyển đổi và tạo ra dữ liệu ma trận 
    class MatrixFactory
    {
        //Tạo ma trận dòng đơn kiểu double rỗng
        public static double[,] zeros(int m) 
        {
            return new double[1, m];
        }

        //Tạo ma trận n dòng, m cột kiểu double có giá trị 0
        public static double[,] zeros(int n, int m) 
        {
            return new double[n, m];
        }

        //So sánh hai ma trận bởi các thành phần
        public static bool equals(double[,] a, double[,] b)
        {
            int rowsA = a.GetLength(0);
            int colsA = a.GetLength(1);

            int rowsB = b.GetLength(0);
            int colsB = b.GetLength(1);

            if ((rowsA == rowsB) && (colsA == colsB))
            {
                for (int i = 0; i < rowsA; i++)
                {
                    for (int j = 0; j < colsA; j++)
                    {
                        if (a[i,j] != b[i,j])
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        //Sao chép ma trận
        public static double[,] clone(double[,] a) 
        {
            double[,] res = new double[a.GetLength(0), a.GetLength(1)];
            for (int i = 0; i < a.GetLength(0); i++) 
            {
                for (int j = 0; j < a.GetLength(1); j++) 
              {
                res[i,j] = a[i,j];
              }
            }
            return res;
        }

        //Thực hiện ma trận chuyển vị
        public static double[,] transpose(double[,] a) 
        {
            int rows = a.GetLength(0);
            int cols = a.GetLength(1);
            double[,] res = new double[cols, rows];
            for (int i = 0; i < rows; i++) 
            {
              for (int j = 0; j < cols; j++) 
              {
                res[j, i] = a[i, j];
              }
            }
            return res;
          }

        //Mô phỏng chức năng thay đổi hình dáng trong Matlap
        //Returns the m-by-n matrix B whose elements are taken column-wise from A.
        //An error results if A does not have m*n elements
         public static double[,] reshape(double[,] a, int n, int m) 
         {
            int cEl = 0;
            int aRows = a.GetLength(0);

            double[,] res = new double[n,m];

            for (int j = 0; j < m; j++) {
                for (int i = 0; i < n; i++) {
                res[i, j] = a[cEl % aRows, cEl / aRows];
                cEl++;
                }
            }

            return res;
         }

        //Tính toán các cột có nghĩa trong ma trận
         public static double[] colMeans(double[,] a)
         {
             double[] res = new double[a.GetLength(1)];
             for (int j = 0; j < a.GetLength(1); j++)
             {
                 double sum = 0;
                 int counter = 0;
                 for (int i = 0; i < a.GetLength(0); i++)
                 {
                     if (Double.IsNaN(a[i,j]) || Double.IsInfinity(a[i,j]))
                     {
                         continue;
                     }
                     sum += a[i,j];
                     counter += 1;
                 }
                 if (counter == 0)
                 {
                     res[j] = Double.NaN;
                 }
                 else
                 {
                     res[j] = sum / ((double)counter);
                 }
             }
             return res;
        }

        //In ma trận
        /* public static String toString(double[,] a)
         {
             int rows = a.GetLength(0);
             int cols = a.GetLength(1);
             StringBuilder sb = new StringBuilder(4000);
             Formatter formatter = new Formatter(sb, Locale.US);

             sb.Append("       ");
             for (int j = 0; j < cols; j++)
             {
                 formatter.format(" [%1$3d]", j);
             }
             sb.Append(CR);

             for (int i = 0; i < rows; i++)
             {
                 formatter.format(" [%1$3d] ", i);
                 for (int j = 0; j < cols; j++)
                 {
                     formatter.format(" %1$ 6f", a[i,j]);
                 }
                 sb.Append(CR);
             }

             return sb.toString();
         }
         
         public static String toCodeString(double[][] a) 
         {
            int rows = a.GetLength(0);
            int cols = a.GetLength(1);
            StringBuilder sb = new StringBuilder(4000);
            Formatter formatter = new Formatter(sb, Locale.US);

            for (int i = 0; i < rows; i++) {
              sb.Append("{");
              for (int j = 0; j < cols; j++) {
                formatter.format(" %1$ 4f", a[i][j]);
                sb.Append(", ");
              }
              sb.delete(sb.Length() - 2, sb.Length());
              sb.Append("},"+CR);
            }

            return sb.toString();
        }*/
     }
}
