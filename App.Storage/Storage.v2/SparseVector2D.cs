using System.Collections.Generic;
using System.Linq;

namespace Storage.v2
{
    public class SparseVector2D<TIndex, TData> : SparseVector1D<TIndex, SparseVector1D<TIndex, TData>>
    {
        public SparseVector2D()
        {
            _data = new Dictionary<TIndex, SparseVector1D<TIndex, TData>>();
        }

        public SparseVector2D(TIndex i, TIndex j, TData value)
        {
            _data = new Dictionary<TIndex, SparseVector1D<TIndex, TData>>() { [i] = new SparseVector1D<TIndex, TData>(j, value) };
        }

        private int? _count;
        public int Count
        {
            get
            {
                if (_count == default(int?))
                {
                    _count = _data.Values.Sum(x => x.Count);
                }

                return _count.Value;
            } 
        }

        public override SparseVector1D<TIndex, TData> this[TIndex i] 
        { 
            get
            {
                if (!_data.TryGetValue(i, out _))
                    _data.Add(i, new SparseVector1D<TIndex, TData>());

                return _data[i];
            }

            set
            {
                _data[i] = value;
            }
        }

        public TData this[TIndex i, TIndex j]
        {
            get 
            {
                if (!_data.TryGetValue(i, out _))
                    _data.Add(i, new SparseVector1D<TIndex, TData>());
                
                return _data[i][j];
            }
            
            set 
            {
                if (_data.TryGetValue(i, out var vector) && vector.HasValueAt(j))
                    vector[j] = value;
                else
                    _data.Add(i, new SparseVector1D<TIndex, TData>(j, value));
            }
        }
    }
}
