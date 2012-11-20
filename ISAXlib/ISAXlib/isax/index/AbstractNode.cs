using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ISAXlib.isax.index
{
    // Base class for iSAX hash tree
    public abstract class AbstractNode
    {
        private NodeType nt = NodeType.TERMINAL;

        public Sequence key;

        public IndexHashParams param;

        // Get the node type
        public NodeType getType()
        {
            return this.nt;
        }

        //Constructor
        public AbstractNode()
        {
        }

        public Dictionary<String, TimeseriesInstance> getNodeInstances()
        {
            return null;
        }

        public TimeseriesInstance getNodeInstanceByKey(String strKey)
        {
            return null;
        }

        public Boolean IsOverThreshold()
        {
            return false;
        }

        public void setType(NodeType t)
        {
            this.nt = t;
        }

        // Performs a recursive lookup to find an approximate match, if it exists
        public TimeseriesInstance ApproxSearch(Timeseries ts)
        {
            return null;
        }

        // Performs kNN search for a sequence across the buckets. Currently broken

        public void kNNSearch(kNNSearchResults results)
        {
        }

        public void Insert(TimeseriesInstance ts_inst)
        {
        }
    }
}
