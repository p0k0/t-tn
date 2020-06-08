using System.Collections.Generic;

namespace Storage.v2
{
    public class SparseVector1D<TIndex, TData>
    {
        protected IDictionary<TIndex, TData> _data;

        public SparseVector1D()
        {
            _data = new Dictionary<TIndex, TData>();
        }

        public SparseVector1D(TIndex i, TData value)
        {
            _data = new Dictionary<TIndex, TData> { [i] = value };
        }

        public bool HasValueAt(TIndex i) => _data.ContainsKey(i);

        public int Count => _data.Count;

        public virtual TData this[TIndex i]
        {
            get { return _data[i]; }
            set { _data[i] = value; }
        }
    }
}
