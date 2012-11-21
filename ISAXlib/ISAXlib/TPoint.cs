using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ISAXlib
{
    public class TPoint
    {
        private double _value;
        private long _tstamp;
    
        public TPoint(double value, long tstamp) // tstamp là tổ hợp ngày và giờ
        {
            this._value = value;
            this._tstamp = tstamp;
        }

        public double value()
        {
            return _value;
        }

        public long tstamp()
        {
            return _tstamp;
        }

        public void setValue(double newValue)
        {
            _value = newValue;
        }

        public void setTstamp(long newTstamp)
        {
            _tstamp = newTstamp;   
        }

        public Boolean equals(Object o) // hàm kiểm tra một object có phải là TPoint không
        {
            if (o is TPoint) // từ khóa "is" dùng để kiểm tra một object có phải là một instance của object khác hay không
            {
                TPoint tp = (TPoint)o;
                if (_value == tp.value() && _tstamp == tp.tstamp())
                    return true;
            }
            return false;
        }

        public int compareTo(TPoint o) // hàm so sánh hai TPoint, ưu tiên so sánh theo tstamp
        {
            if (_value == o.value() && _tstamp == o.tstamp())
                return 0;
            if (_tstamp > o.tstamp())
                return 1;
            if (_tstamp < o.tstamp())
                return -1;
            return _value <= o.value() ? -1 : 1;
        }

       
    }
}
