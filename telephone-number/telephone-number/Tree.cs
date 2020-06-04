using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace telephone_number
{
    public class Tree
    {
        private IList<string> _data;//roots numbers

        public Tree()
        {
            _data = new List<string>();
        }

        public void Insert(string number)
        {
            _data.Add(number);
        }

        public int NodeCount()
        {
            return _data.Count;
        }

        public IEnumerable<string> Find(string number)
        {
            return _data.Where(storedNumber => storedNumber.Contains(number));
        }
    }
}
