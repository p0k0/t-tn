using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Storage.v3
{
    public class RefNode<T>
    {
        public T Data { get; set; }
        public RefNode<T> Parent { get; set; }

        public RefNode(T data)
        {
            Data = data;
        }

        public static RefNode<T> CreateAndReturnHead(IEnumerable<T> datas)
        {
            var d = datas.Select(data => new RefNode<T>(data)).ToList();
            InitHierarchy(d);
            return d.FirstOrDefault();
        }

        private static void InitHierarchy(List<RefNode<T>> d)
        {
            for (int i = 1; i < d.Count; i++)
                d[i].Parent = d[i - 1];
        }

        public static RefNode<T> CreateAndReturnTail(IEnumerable<T> datas)
        {
            var d = datas.Select(data => new RefNode<T>(data)).ToList();
            InitHierarchy(d);
            return d.LastOrDefault();
        }

        public StringBuilder GetPathToRoot()
        {
            if (Parent == null)
                return new StringBuilder(Data.ToString());
            else
                return new StringBuilder(Data.ToString()).Append(Parent.GetPathToRoot());
        }

        public override string ToString()
        {
            return new string(GetPathToRoot().ToString().Reverse().ToArray());
        }
    }
}
