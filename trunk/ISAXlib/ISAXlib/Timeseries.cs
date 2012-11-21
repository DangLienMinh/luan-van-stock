using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace ISAXlib
{
    class Timeseries
    {
        private List<TPoint> series;
        private static const string COMMA = ", ";
        
        public Timeseries()
        {
            series = new List<TPoint>();
        }

        public Timeseries(double[] values, long[] tstamps)
        {
            series = new List<TPoint>();
            if (values.Length == tstamps.Length)
            {
                for (int i = 0; i < values.Length; i++)
                    series.Add(new TPoint(values[i], tstamps[i]));
            }
            else
            {
                throw new System.ArgumentException("The lengths of the values and timestamps arrays are not equal!");
            }
        }

        /* public Timeseries(double[] values, long[] tstamps, double nanValue)
        {
            series = new List<TPoint>();
            if (values.Length == tstamps.Length)
            {
                for (int i = 0; i < values.Length; i++)
                    if (nanValue == values[i])
                        series.Add(new TPoint((0.0D / 0.0D), tstamps[i]));
                    else
                        series.Add(new TPoint(values[i], tstamps[i]));
            }
            else
            {
                throw new System.ArgumentException("The lengths of the values and timestamps arrays are not equal!");
            }
        } */

        public void add(TPoint p)
        {
            series.Add(p);
        }

        public void addByTime(TPoint p) // thêm TPoint vào Timeserie theo thời gian
        {
            if (series.Count == 0)
            {
                series.Add(p);
                return;
            }

            if (p.tstamp() > (series.ElementAt(series.Count() - 1).tstamp()))
            {
                series.Add(p);
                return;
            }

            if (p.tstamp() < (series.ElementAt(0).tstamp()))
            {
                series.Insert(0, p);
                return;
            }
            else
            {
                int pos2insert = findPositions(p);
                series.Insert(pos2insert, p);
                return;
            }
        }

        public int findPositions(TPoint p) //Tim  TPoint p trong Timeseries
        {
            int i = 0;
            int j = series.Count() - 1;
            int k = 0;

            while (j - i > 1)
            {
                k = i + (j - i) / 2;
                if (p.tstamp() == series.ElementAt(k).tstamp())
                    return k;
                if (p.tstamp() < series.ElementAt(k).tstamp())
                    j = k;
                else
                    i = k;
            }

            if (j - i == 1)
                return j;
            else
                return -1;
        }

        public void removeAt(int pos)
        {
            if (pos >= 0 && pos < series.Count())
                series.RemoveAt(pos);
            else
                throw new System.ArgumentException("Illegal position specified for removal");
        }

        public int size()
        {
            return series.Count();
        } // trả về kích thước của Timeserie

        public TPoint elementAt(int i)  // trả về TPoint tại vị trí i
        {
            return series.ElementAt(i);
        }

        public double[] values() // trả về mảng các value của Timeserie
        {
            double[] res = new double[series.Count()];
            for(int i = 0; i < series.Count(); i++)
                res[i] = series.ElementAt(i).value();
            return res;

        }

        public Boolean equals(Object o)
        {
            if (o is Timeseries)
            {
                Timeseries ot = (Timeseries)o;
                if (size() == ot.size())
                {
                    for (int i = 0; i < series.Count(); i++)
                        if (!(series.ElementAt(i).equals(ot.elementAt(i))))
                            return false;
                    return true;
                }
            }
            return false;
        }

        public Timeseries subsection(int start, int end)
        {
            if (start >= 0 && end < series.Count())
            {
                int len = (end - start) + 1;
                double[] val = new double[len];
                long[] ts = new long[len];
                for (int i = start; i <= end; i++)
                {
                    TPoint tp = series.ElementAt(i);
                    val[i - start] = tp.value();
                    ts[i - start] = tp.tstamp();
                }

                return new Timeseries(val, ts);
            }
            else
            {
                throw new System.ArgumentException("Invalid interval specified: timeseries size");
            }
        } // trả về một Timeserie con trong Timeserie 

        public Timeseries clone() // tự nhân bản ra 1 timeseries mới
        {
            double[] val;
            long[] ts;
            int len =  series.Count();
            
            val = new double[len];
            ts = new long[len];

            for (int i = 0; i < len; i++)
            {
                TPoint tp = (TPoint)series.ElementAt(i);
                val[i] = tp.value();
                ts[i] = tp.tstamp();
            }

            return new Timeseries(val, ts);
            
        }

        public double[,] valuesAsMatrix()
        {
            double res[,] = new double[1, series.size()];
            for(int i = 0; i < series.size(); i++)
                res[0, i] = ((TPoint)series.get(i)).value();

            return res;
        }

        public long[] tstamps()
        {
            long res[] = new long[series.size()];
            for(int i = 0; i < series.size(); i++)
                res[i] = ((TPoint)series.get(i)).tstamp();

            return res;
        }

    }
        
}



