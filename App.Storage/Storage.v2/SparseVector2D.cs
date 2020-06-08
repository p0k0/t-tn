using System.Collections.Generic;
using System.Linq;

namespace Storage.v2
{
    public class SparseVector2D<T> : SparseVector1D<SparseVector1D<T>>
    {
        public SparseVector2D()
        {
            _data = new Dictionary<int, SparseVector1D<T>>();
        }

        public SparseVector2D(int i, int j, T value)
        {
            _data = new Dictionary<int, SparseVector1D<T>>() { [i] = new SparseVector1D<T>(j, value) };
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

        public override SparseVector1D<T> this[int i] 
        { 
            get
            {
                if (!_data.TryGetValue(i, out _))
                    _data.Add(i, new SparseVector1D<T>());

                return _data[i];
            }

            set
            {
                _data[i] = value;
            }
        }

        public T this[int i, int j]
        {
            get 
            {
                if (!_data.TryGetValue(i, out _))
                    _data.Add(i, new SparseVector1D<T>());
                
                return _data[i][j];
            }
            
            set 
            {
                if (_data.TryGetValue(i, out var vector) && vector.IndexExists(j))
                    vector[j] = value;
                else
                    _data.Add(i, new SparseVector1D<T>(j, value));
            }
        }
    }
}
