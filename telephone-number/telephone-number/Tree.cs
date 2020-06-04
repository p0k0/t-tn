using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace telephone_number
{
    public class Tree
    {
        private IList<IList<char>> _rootTrees;//roots numbers

        public Tree()
        {
            _rootTrees = new List<IList<char>>();
        }

        public void Insert(string v)
        {
            if (!_rootTrees.Any())
                _rootTrees.Add(new List<char>());

            _rootTrees.Where(x => x.FirstOrDefault() != null && x == ).Add(v);
        }

        public int NodeCount()
        {
            return _rootTrees.Count;
        }

        public IEnumerable<string> Find(string v)
        {
            throw new NotImplementedException();
        }
    }
}
