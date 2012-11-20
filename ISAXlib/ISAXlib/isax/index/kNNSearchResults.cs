using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ISAXlib.isax.index
{
    class kNNSearchResults
    {
        
       int kNN = 0;
       Timeseries search_ts = null;

       public kNNSearchResults(int k, Timeseries ts_search)
        {
           this.kNN = k;
           this.search_ts = ts_search;
        }

       public void AddResult(TimeseriesInstance tsi)
       {
           TimeseriesInstance insert = null;
           try
           {
               insert = tsi.clone();
           }
           catch
           {
               throw new ArgumentException("Error");
           }

           insert.setComparableReferencePoint(search_ts);
           
       }
        
    }
}
