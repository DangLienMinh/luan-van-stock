using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ISAXlib.isax.index
{
    class SAXBreakpoints
    {
        public double B_Li = 0;
        public double B_Ui = 0;
    }
    class ISAXUtils
    {
        public static Sequence CreateiSAXSequence(Timeseries ts, int base_cardinality, int word_length)
        {
            NormalAlphabet alphabet = new NormalAlphabet();
            int paaSize = word_length;
            int tsLength = ts.size();
            Timeseries PAA;
            try
            {
                PAA =  
            }
        }
    }
}
