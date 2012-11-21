using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ISAXlib.isax.index
{
    public abstract class Alphabet
    {
        /**
  * get the max size of the alphabet.
  * 
  * @return maximum size of the alphabet.
  */
        public abstract int getMaxSize();

        /**
         * Get cut intervals corresponding to the alphabet size.

         */
        public abstract double[] getCuts(int size);
        

        /**
         * Get the distance matrix for the alphabet size.
         */
        public abstract double[][] getDistanceMatrix(int size);
        
    }
}




