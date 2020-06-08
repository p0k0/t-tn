using System.Collections.Generic;

namespace Storage.v2.Tests
{
    public class TVector<T>
    {
        private IDictionary<int, T> _data;

        public TVector()
        {
            _data = new Dictionary<int, T>();
        }

        public T this[int i]
        {
            get { return _data[i]; }
            set { _data[i] = value; }
        }
    }
}
