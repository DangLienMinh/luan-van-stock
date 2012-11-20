using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Collections;

namespace ISAXlib.isax.index
{
    class Sequence
    {
        private int orig_length = 0;
        private ArrayList symbols = new ArrayList();

        //Constructor
        public Sequence(int len)
        {
            this.orig_length = len;
        }

        //Provides access to internal storage
        public ArrayList getSymbols()
        {
            return this.symbols;
        }

        // Get the length
        public int getOrigLength()
        {
            return this.orig_length;
        }

        public void setOrigLength(int len)
        {
            this.orig_length = len;
        }

        // Clones the iSAX sequence
        public Sequence clone()
        {
            Sequence new_Sequence = new Sequence(this.orig_length);

            for (int i = 0; i <this.symbols.Count; i++)
            {
                new_Sequence.symbols.Add(this.symbols[i]);
            }
            return new_Sequence;
        }


        //Extracts the cardinalities of each symbol
      /*  public List<int> getCardinalities()
        {
            List<int> lCards = new List<int>();
            for (int x = 0; x < this.symbols.Count; x++)
            {
                lCards.Add((int)this.symbols[x]);
            }
            
        }*/

    }
}
