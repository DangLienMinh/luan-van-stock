using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace ISAXlib
{
    class Timeseries
    {
        private List<TPoint> series;

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

        public Timeseries(double[] values, long[] tstamps, double nanValue)
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
        }

        public void add(TPoint p)
        {
            series.Add(p);
        }

 

    }
}
