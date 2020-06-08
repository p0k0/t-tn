using System.Collections.Generic;

namespace Storage.v2
{
    public class SparseVector1D<T>
    {
        protected IDictionary<int, T> _data;

        public SparseVector1D()
        {
            _data = new Dictionary<int, T>();
        }

        public SparseVector1D(int i, T value)
        {
            _data = new Dictionary<int, T> { [i] = value };
        }

        public bool IndexExists(int i) => _data.ContainsKey(i);

        public int Count => _data.Count;

        public virtual T this[int i]
        {
            get { return _data[i]; }
            set { _data[i] = value; }
        }
    }
}
