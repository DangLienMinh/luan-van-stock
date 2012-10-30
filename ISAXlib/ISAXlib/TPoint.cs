using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ISAXlib
{
    public class TPoint
    {
        private double value;
        private long tstamp;

        public TPoint(double value, long tstamp) // tstamp là tổ hợp ngày và giờ
        {
            this.value = value;
            this.tstamp = tstamp;
        }

        public double value()
        {
            return value;
        }

        public long tstamp()
        {
            return tstamp;
        }

        public void setValue(double newValue)
        {
            value = newValue;
        }

        public long setTstamp(long newTstamp)
        {
            tstamp = newTstamp;   
        }

        public Boolean equals(Object o) // hàm kiểm tra một object có phải là TPoint không
        {
            if (o is TPoint) // từ khóa "is" dùng để kiểm tra một object có phải là một instance của object khác hay không
            {
                TPoint tp = (TPoint)o;
                if (value = tp.value() && tstamp = tp.tstamp())
                    return true;
            }
            return false;
        }

        public int compareTo(TPoint o) // hàm so sánh hai TPoint, ưu tiên so sánh theo tstamp
        {
            if (value == o.value() && tstamp == o.tstamp())
                return 0;
            if (tstamp > o.tstamp())
                return 1;
            if (tstamp < o.tstamp())
                return -1;
            return value <= o.value() ? -1 : 1;
        }

    }
}
