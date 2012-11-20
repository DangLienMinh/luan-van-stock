using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ISAXlib.isax.index
{
    class TerminalNode : AbstractNode
    {
        public Dictionary<String, TimeseriesInstance> arInstances = new Dictionary<string, TimeseriesInstance>();

        public TerminalNode(Sequence seq_key, IndexHashParams param)
        {
            this.setType(NodeType.TERMINAL);
            this.key = seq_key;
            this.param = param;
        }

        public override Boolean IsOverThreshold()
        {
            if (this.param.threshold < 1)
                return false;
            if (this.arInstances.Count > this.param.threshold)
                return true;
            return false;
        }

        public override void Insert(TimeseriesInstance ts_inst)
        {
            Sequence ts_isax = null;
          
        }
        
    }
}
