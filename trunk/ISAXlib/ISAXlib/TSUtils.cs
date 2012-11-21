using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using ISAXlib.logic.math;
using ISAXlib.logic.sax;

namespace ISAXlib
{
    class TSUtils
    {
        static const char[] ALPHABET = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm',
        'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
        
        //Đọc Timeseries từ file
        public static Timeseries readTS(string filename, int sizeLimit)
        {
            StreamReader reader = File.OpenText(filename); 
            //StreamReader br = new StreamReader(new FileReader(new File(filename)));
            String line = null;
            double[] values = new double[sizeLimit];
            long[] tstamps = new long[sizeLimit];
            int i = 0;
            while ((line = reader.ReadLine()) != null)
            {
                values[i] = Double.Parse(line);
                tstamps[i] = (long)i;
                i++;
            }
            reader.Close();
            return new Timeseries(values, tstamps);
        }

        //Trả về số lượng Timeseries tối đa (loại ra những Timeseries không hợp lệ - k phải là số)
        public static double max(Timeseries series)
        {
            if (countNaN(series) == series.size())
            {
                return Double.NaN;
            }
            double[] values = series.values();
            double max = Double.MinValue;
            for (int i = 0; i < values.Length; i++)
            {
                if (max < values[i])
                {
                    max = values[i];
                }
            }
            return max;
        }

        //Trả về số lượng Timeseries tối đa
        public static double max(double[] series)
        {
            if (countNaN(series) == series.Length)
            {
                return Double.NaN;
            }
            double max = Double.MinValue;
            for (int i = 0; i < series.Length; i++)
            {
                if (max < series[i])
                {
                    max = series[i];
                }
            }
            return max;
        }

        //Trả về số lượng Timeseries tối thiểu (loại ra những Timeseries không hợp lệ - k phải là số)
        public static double min(Timeseries series)
        {
            if (countNaN(series) == series.size())
            {
                return Double.NaN;
            }
            double[] values = series.values();
            double min = Double.MaxValue;
            for (int i = 0; i < values.Length; i++)
            {
                if (min > values[i])
                {
                    min = values[i];
                }
            }
            return min;
        }

        //Trả về số lượng Timeseries tối thiểu
        public static double min(double[] series)
        {
            if (countNaN(series) == series.Length)
            {
                return Double.NaN;
            }
            double min = Double.MaxValue;
            for (int i = 0; i < series.Length; i++)
            {
                if (min > series[i])
                {
                    min = series[i];
                }
            }
            return min;
        }

        //Tính giá trị trung bình của Timeseries
        public static double mean(Timeseries series) 
        {
            double res = 0D;
            int count = 0;
            for(int i = 0; i < series.size(); i++)
            {
                TPoint tp = series.elementAt(i);
                if(Double.IsNaN(tp.value()) || Double.IsInfinity(tp.value())) 
                {
                    continue;
                }
                else 
                {
                    res += tp.value();
                    count += 1;
                }
            }
            if(count > 0)
            {
                return res / ((double) count);
            }
            return Double.NaN;
        }
        
        //Tính giá trị trung bình của Timeseries
        public static double mean(double[] series) 
        {
            double res = 0D;
            int count = 0;
            for (int i = 0; i < series.Count(); i++)
            {
                double tp = series[i];
                if (Double.IsNaN(tp) || Double.IsInfinity(tp))
                {
                    continue;
                }
                else 
                {
                    res += tp;
                    count += 1;
                }
            }
                if (count > 0)
                {
                  return res / ((double) count);
                }
                return Double.NaN;
        }

        //Tính toán phương sai của Timeseries
        public static double var(Timeseries series)
        {
            double res = 0D;
            double _mean = mean(series);
            if (Double.IsNaN(_mean) || Double.IsInfinity(_mean))
            {
                return Double.NaN;
            }
            int count = 0;
            for (int i = 0; i < series.size(); i++)
            {
                TPoint tp = series.elementAt(i);

                if (Double.IsNaN(tp.value()) || Double.IsInfinity(tp.value()))
                {
                    continue;
                }
                else
                {
                    res += (tp.value() - _mean) * (tp.value() - _mean);
                    count += 1;
                }
            }
            if (count > 0)
            {
                return res / ((double)(count - 1));
            }
            return Double.NaN;
        }

        //Tính toán phương sai của Timeseries
        public static double var(double[] series)
        {
            double res = 0D;
            double _mean = mean(series);
            if (Double.IsNaN(_mean) || Double.IsInfinity(_mean))
            {
                return Double.NaN;
            }
            int count = 0;
            for (int i = 0; i < series.Count(); i++)
            {
                double tp = series[i];
                if (Double.IsNaN(tp) || Double.IsInfinity(tp))
                {
                    continue;
                }
                else
                {
                    res += (tp - _mean) * (tp - _mean);
                    count += 1;
                }
            }
            if (count > 0)
            {
                return res / ((double)(count - 1));
            }
            return Double.NaN;
        }

        //Tính độ lệch chuẩn của các timeseries
        public static double stDev(Timeseries series) 
        {
            double num0 = 0D;
            double sum = 0D;
            int count = 0;
            for (int i = 0; i < series.size(); i++)
            {
                TPoint tp = series.elementAt(i);
                if (Double.IsNaN(tp.value()) || Double.IsInfinity(tp.value())) 
                {
                    continue;
                }
                else 
                {
                    num0 = num0 + tp.value() * tp.value();
                    sum = sum + tp.value();
                    count += 1;
                }
            }
            if (count > 0) 
            {
                double len = ((double) count);
                return Math.Sqrt((len * num0 - sum * sum) / (len * (len - 1)));
            }
            return Double.NaN;
        }

        //Tính độ lệch chuẩn của các timeseries
        public static double stDev(double[] series) 
        {
            double num0 = 0D;
            double sum = 0D;
            int count = 0;
            for (int i = 0; i < series.Count(); i++)
            {
                double tp = series[i];
                if (Double.IsNaN(tp) || Double.IsInfinity(tp))
                {
                    continue;
                }
                else 
                {
                    num0 = num0 + tp * tp;
                    sum = sum + tp;
                    count += 1;
                }
            }
            if (count > 0) 
            {
                double len = ((double)count);
                return Math.Sqrt((len * num0 - sum * sum) / (len * (len - 1)));
            }
            return Double.NaN;
        }

        //Z-Nomalize (0 ~ 1)
         public static Timeseries zNormalize(Timeseries series) 
         {

            // get values and timestamps out of there
            //
            double[] res = new double[series.size()];
            long[] tstamps = new long[series.size()];

            // get mean-giá trị trung bình and sdev-độ lệch chuẩn, NaN's will be removed.
            //
            double _mean = mean(series);
            double sd = stDev(series);

            // check if we hit special case, where something got NaN
            //
            if (Double.IsInfinity(_mean) || Double.IsNaN(_mean) || Double.IsInfinity(sd) || Double.IsNaN(sd)) 
            {
              //
              // case[1] single value within the timeseries, normalize this value
              // to 1, whatever
              int nanNum = countNaN(series);
              if ((series.size() - nanNum) == 1) 
              {
                for (int i = 0; i < res.Length; i++) 
                {
                  if (Double.IsInfinity(series.elementAt(i).value())
                      || Double.IsNaN(series.elementAt(i).value())) 
                  {
                      res[i] = series.elementAt(i).value();
                  }
                  else 
                  {
                      res[i] = 1.0D;
                  }
                  tstamps[i] = series.elementAt(i).tstamp();
                }
              }
              //
              // case[2] all values are NaN's
              else if (series.size() == nanNum) 
              {
                  for (int i = 0; i < res.Length; i++)
                  {
                      res[i] = series.elementAt(i).value();
                      tstamps[i] = series.elementAt(i).tstamp();
                  }
              }
            }
            //
            // case[3] SD happens to be a zero, i.e. they all are the same
            else if (sd == 0.0D) 
            {
              //
              // now - check the case when SD is playing the trick, like
              // [1.0, 1.0, NaN, NaN, NaN, NaN, NaN] ->
              // subsection: [1.0, 1.0, NaN, NaN, NaN, NaN, NaN]
              // m: 1.0 sd: 0.0 ->
              // normal: [NaN, NaN, NaN, NaN, NaN, NaN, NaN] ->
              // NaN,NaN,NaN,NaN,NaN,NaN,NaN, -> "_______"
              // ??
                for (int i = 0; i < res.Length; i++)
                {
                if (Double.IsInfinity(series.elementAt(i).value())
                    || Double.IsNaN(series.elementAt(i).value())) 
                {
                    res[i] = series.elementAt(i).value();
                }
                else 
                {
                    res[i] = 1.0D;
                }
                tstamps[i] = series.elementAt(i).tstamp();
              }
            }
            //
            // normal case, everything seems to be fine
            else 
            {
              // sd and mean here, - go-go-go
                for (int i = 0; i < res.Length; i++)
                {
                    res[i] = (series.elementAt(i).value() - _mean) / sd;
                    tstamps[i] = series.elementAt(i).tstamp();
                }
            }
            return new Timeseries(res, tstamps);
      }

        //Z-Nomalize (0 ~ 1)
        public static double[] zNormalize(double[] series) 
        {
            // get values and timestamps out of there
            //
            double[] res = new double[series.Length];

            // get mean and sdev, NaN's will be removed.
            //
            double _mean = mean(series);
            double sd = stDev(series);

            // check if we hit special case, where something got NaN
            //
            if (Double.IsInfinity(_mean) || Double.IsNaN(_mean) || Double.IsInfinity(sd) || Double.IsNaN(sd)) 
            {
              //
              // case[1] single value within the timeseries, normalize this value
              // to 1, whatever
              int nanNum = countNaN(series);
              if ((series.Length - nanNum) == 1) 
              {
                for (int i = 0; i < res.Length; i++) 
                {
                    if (Double.IsInfinity(series[i]) || Double.IsNaN(series[i])) 
                    {
                    res[i] = series[i];
                    }
                    else 
                    {
                    res[i] = 1.0D;
                    }
                }
              }
              //
              // case[2] all values are NaN's
              else if (series.Length == nanNum)
              {
                for (int i = 0; i < res.Length; i++) 
                {
                  res[i] = series[i];
                }
              }
            }
            //
            // case[3] SD happens to be a zero, i.e. they all are the same
            else if (sd == 0.0D) 
            {
              //
              // now - check the case when SD is playing the trick, like
              // [1.0, 1.0, NaN, NaN, NaN, NaN, NaN] ->
              // subsection: [1.0, 1.0, NaN, NaN, NaN, NaN, NaN]
              // m: 1.0 sd: 0.0 ->
              // normal: [NaN, NaN, NaN, NaN, NaN, NaN, NaN] ->
              // NaN,NaN,NaN,NaN,NaN,NaN,NaN, -> "_______"
              // ??
              for (int i = 0; i < res.Length; i++) {
                if (Double.IsInfinity(series[i]) || Double.IsNaN(series[i])) 
                {
                  res[i] = series[i];
                }
                else 
                {
                  res[i] = 1.0D;
                }
              }
            }
            //
            // normal case, everything seems to be fine
            else 
            {
              // sd and mean here, - go-go-go
              for (int i = 0; i < res.Length; i++) 
              {
                res[i] = (series[i] - _mean) / sd;
              }
            }
            return res;
      }

        //Xấp xỉ Timeseries sử dụng PAA. 
        //Nếu Timeseries  có một số giá trị NaN thì chúng được xử lý như sau:
        //. Nếu tất cả các giá trị mảnh là NaN thì chúng được xấp xỉ như NaN
        //. Nếu có 1 giá trị đúng trên mảnh thì thuật toán sẽ xử lý nó như bình thường
        //(maybe instead i should if on the approximated
        //segment amount of NaN's greater than amount of actual values)
        public static Timeseries paa(Timeseries ts, int paaSize) 
        {
        // fix the length
        int len = ts.size();
        // check for the trivial case
        if (len == paaSize) 
        {
          return ts.clone();
        }
        else 
        {
          // get values and timestamps
          double[,] vals = ts.valuesAsMatrix();
          long[] tStamps = ts.tstamps();
          // work out PAA by reshaping arrays
          double[,] res;
          if (len % paaSize == 0) {
            res = MatrixFactory.reshape(vals, len / paaSize, paaSize);
          }
          else {
            double[,] tmp = new double[paaSize,len];
            // System.out.println(Matrix.toString(tmp));
            for (int i = 0; i < paaSize; i++) {
              for (int j = 0; j < len; j++) {
                tmp[i,j] = vals[0,j];
              }
            }
            // System.out.println(Matrix.toString(tmp));
            double[,] expandedSS = MatrixFactory.reshape(tmp, 1, len * paaSize);
            // System.out.println(Matrix.toString(expandedSS));
            res = MatrixFactory.reshape(expandedSS, len, paaSize);
            // System.out.println(Matrix.toString(res));
          }
          //
          // now, here is a new trick comes in game - because we have so many
          // "lost" values
          // PAA game rules will change - we will omit NaN values and put NaNs
          // back to PAA series
          //
          //
          // this is the old line of code here:
          // double[] newVals = MatrixFactory.colMeans(res);
          //
          // i will need to test this though
          //
          //
          double[] newVals = MatrixFactory.colMeans(res);

          // work out timestamps
          long start = tStamps[0];
          long interval = tStamps[len - 1] - start;
          double increment = Convert.ToDouble(interval) / Convert.ToDouble(paaSize);
          long[] newTstamps = new long[paaSize];
          for (int i = 0; i < paaSize; i++) {
              newTstamps[i] = start + Convert.ToInt32(increment / 2.0D + i * increment);
          }
          return new Timeseries(newVals, newTstamps);
        }
      }

        //Cung cấp thực thi biến đổi PAA
        public static double[] paa(double[] ts, int paaSize) 
        {
    // fix the length
    int len = ts.Length;
    // check for the trivial case
    if (len == paaSize) {
        return Arrays.copyOf(ts, ts.Length);
    }
    else {
      // get values and timestamps
      double[,] vals = asMatrix(ts);
      // work out PAA by reshaping arrays
      double[,] res;
      if (len % paaSize == 0) 
      {
        res = MatrixFactory.reshape(vals, len / paaSize, paaSize);
      }
      else {
        double[,] tmp = new double[paaSize,len];
        for (int i = 0; i < paaSize; i++) 
        {
          for (int j = 0; j < len; j++) 
          {
            tmp[i,j] = vals[0,j];
          }
        }
        double[,] expandedSS = MatrixFactory.reshape(tmp, 1, len * paaSize);
        res = MatrixFactory.reshape(expandedSS, len, paaSize);
      }
      double[] newVals = MatrixFactory.colMeans(res);

      return newVals;
    }

  }
        //Chuyển Timeseries sang kiểu chuỗi
       public static char[] ts2String(Timeseries series, Alphabet alphabet, int alphabetSize)
      {
        double[] cuts = alphabet.getCuts(alphabetSize);
        char[] res = new char[series.size()];
        for (int i = 0; i < series.size(); i++) {
          res[i] = num2char(series.elementAt(i).value(), cuts);
        }
        return res;
      }
       
        //Chuyển đổi các timeseries vào đại diện tượng trưng bằng cách sử dụng cắt giảm cho khoảng thời gian
       public static char[] ts2String(double[] vals, double[] cuts)
       {
           char[] res = new char[vals.Length];
           for (int i = 0; i < vals.Length; i++)
           {
               res[i] = num2char(vals[i], cuts);
           }
           return res;
       }
        //Chuyển Timeseries sang kiểu chuỗi
        public static char[] ts2StringWithNaN(Timeseries series, Alphabet alphabet, int alphabetSize)
        {
            double[] cuts = alphabet.getCuts(alphabetSize);
            return ts2StringWithNaNByCuts(series, cuts);
        }

        //Chuyển Timeseries sang kiểu chuỗi
        public static char[] ts2StringWithNaNByCuts(Timeseries series, double[] cuts) 
        {
            char[] res = new char[series.size()];
            for (int i = 0; i < series.size(); i++) 
            {
                if (Double.IsNaN(series.elementAt(i).value())
                    || Double.IsInfinity(series.elementAt(i).value())) 
                {
                res[i] = '_';
                }
                else 
                {
                    res[i] = num2char(series.elementAt(i).value(), cuts);
                }
            }
            return res;
            }

        //Lập bản đồ từ kiểu số sang kiểu kí tự?!?
       public static char num2char(double value, double[] cuts)
       {
           int count = 0;
           while ((count < cuts.Length) && (cuts[count] <= value))
           {
               count++;
           }
           return ALPHABET[count];
       }

       //Chuyển đổi chỉ mục sang kí tự
        public static char num2char(int idx)
       {
           return ALPHABET[idx];
       }

        //Chuyển đổi Timeseries sang chỉ mục sử dụng SAX
        public static int[] ts2Index(Timeseries series, Alphabet alphabet, int alphabetSize)
        {
            double[] cuts = alphabet.getCuts(alphabetSize);
            int[] res = new int[series.size()];
            for (int i = 0; i < series.size(); i++) 
            {
              res[i] = num2index(series.elementAt(i).value(), cuts);
            }
            return res;
        }

        //Lập bản đồ số chỉ mục?!
        public static int num2index(double value, double[] cuts)
        {
            int count = 0;
            while ((count < cuts.Length) && (cuts[count] <= value))
            {
                count++;
            }
            return count;
        }

        //Đếm số lượng các giá trị trong mảng series k phải là số
        public static int countNaN(double[] series)
        {
            int res = 0;
            // for (double d : series)
            for (int i = 0; i < series.Count(); i++)
            {
                double d = series[i];
                if (Double.IsInfinity(d) || Double.IsNaN(d))
                {
                res += 1;
                }
            }
            return res;
    }

        //Đếm số lượng các TPoint trong Timeseries k phải là số
        private static int countNaN(Timeseries series)
        {
        int res = 0;
        for (int i = 0; i < series.size(); i++)
        {
            TPoint tp = series.elementAt(i);
            if (Double.IsInfinity(tp.value()) || Double.IsNaN(tp.value()))
            {
            res += 1;
            }
        }
        return res;
        }

        //Chuyển đổi các vector thành ma trận một hàng
        private static double[,] asMatrix(double[] vector) 
        {
        double[,] res = new double[1, vector.Length];
        for (int i = 0; i < vector.Length; i++) 
        {
          res[0,i] = vector[i];
        }
        return res;
  }

    }
}
