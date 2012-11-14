using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ISAXlib.isax.index
{
    class TimeseriesInstance
    {
        private Timeseries ts;
        private Timeseries ts_compareTo_BaseRef;

        private Dictionary<String, long> hmOccurences = new Dictionary<String, long>(); // HaspMap in Java = Dictionary in C#

        public TimeseriesInstance(Timeseries ts)
        {
            this.ts = ts;
            this.ts_compareTo_BaseRef = null;
        }

        public Dictionary<String, long> getOccurences()
        {
            return this.hmOccurences;
        }

        // public voidd Debug()

        public TimeseriesInstance clone()
        {
            TimeseriesInstance tsi = new TimeseriesInstance(this.ts.clone());
            Dictionary<String, long> hm = this.getOccurences();


            return tsi;

        }

        public Timeseries getTS()
        {
            return this.ts;
        }

        public void AddOccurences(TimeseriesInstance instances)
        {
            Dictionary<string, long> hm = instances.getOccurences();

        }

        public void AddOccurenceByKey(String strKey, long offset)
        {
            if (this.hmOccurences.ContainsKey(strKey))
            {
                // Không làm gì
            }
            else
            {
                this.hmOccurences.Add(strKey, offset);
            }
        }

        public void AddOccurence(String strFilename, long offset)
        {
            String strKey = strFilename + "+" + offset;
            this.AddOccurenceByKey(strKey, offset);
        }

        public Boolean equals(Object o)
        {
            if (o is TimeseriesInstance)
            {
                TimeseriesInstance other = (TimeseriesInstance) o;
                return this.ts.equals(other.ts);
            }

            return false;
        }

        // This is the reference timeseries that the compareTo() method uses to calculate 
        // which has a larger distance from a base point for kNN calculations
        // - this is only used for compareTo(), which is used by the heap to sort
        public void setComparableReferencePoint(Timeseries ts_base)
        {
            this.ts_compareTo_BaseRef = ts_base;
        }

        public int compareTo(TimeseriesInstance other)
        {
            if (null == this.ts_compareTo_BaseRef)
                return 0;
            double my_dist = 0;
            double other_dist = 0;
            try
            {
                my_dist = EuclideanDistance.seriesDistance(this.ts.values(), this.ts_compareTo_BaseRef.values());
                other_dist = EuclideanDistance.seriesDistance(other.ts.values(), this.ts_compareTo_BaseRef.values());
            }
            catch 
            {
               throw new ArgumentException("Error");
            }

            if (my_dist == other_dist)
            {
                return 0;
            }
            else if (my_dist > other_dist)
            {
                return 1;
            }
            else if (my_dist < other_dist)
            {
                return -1;
            }

            return 0;
        }
    }
}
