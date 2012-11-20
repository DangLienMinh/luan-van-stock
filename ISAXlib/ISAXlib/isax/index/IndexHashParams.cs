using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ISAXlib.isax.index
{
    class IndexHashParams
    {
        public int base_card = 4;
        public int isax_word_length = 4;
        public int d = 1;// iterative double rate per level, has to be less than isax_word_length
        public int orig_ts_len = 0;// the index of the dimension that we are expanding
        public int dim_index = 0;

        public int threshold = 4;
        public Boolean bDebug = false;

        //not sure if we want to use this
        public List<int> lWildBits = new List<int>(); // there would be 4 of these in
        // this case, with each value being 2 at the root
        public List<int> lCards = new List<int>();

        public IndexHashParams()
        {
        }

        public IndexHashParams(List<int> listCards)
        {
            for (int x = 0; x < listCards.Count(); x++)
            {
                this.addCardEntry(listCards.ElementAt(x));
            }
        }

       /* public static List<int> generateChildCardinality(Sequence node_sax_key)
        {
            return generateChildCardinality(node_sax_key.getCardinalities());
        } */

        public void addCardEntry(int card)
        {
            this.lCards.Add(card);
        }
    }
}
