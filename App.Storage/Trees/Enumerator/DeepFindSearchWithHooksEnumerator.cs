using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trees.Enumerator
{
    public class DeepFindSearchWithHooksEnumerator : NodeEnumerator
    {
        private Stack<Node> _firingNode;
        private Node _currentNode;
        private int pathIndex = 0;
        private IList<StringBuilder> paths;
        private StringBuilder rootPath;


        public DeepFindSearchWithHooksEnumerator(Node node)
        {
            _firingNode = new Stack<Node>();
            _firingNode.Push(node);
            _startNode = node;
            paths = new List<StringBuilder> { new StringBuilder() };
            HookOnLeafVisit += Enumerable_HookOnLeafVisit;
            HookOnNodeVisit += Enumerable_HookOnNodeVisit;
            HookOnPostSplitAtSubnode += Enumerable_HookOnPostSplitAtSubnode;
            HookOnPreSplitAtNode += Enumerable_HookOnPreSplitAtNode;
        }

        public event EventHandler<Node> HookOnNodeVisit;
        public event EventHandler<Node> HookOnLeafVisit;
        public event EventHandler<Node> HookOnPreSplitAtNode;
        public event EventHandler<Node> HookOnPostSplitAtSubnode;

        public IList<string> Paths => paths.Select(x => x.ToString()).ToArray();

        public override object Current => _currentNode;

        public override bool MoveNext()
        {
            if (_firingNode.Count == 0)
                return false;

            _currentNode = _firingNode.Peek();

            if (_currentNode == null)
                return false;

            HookOnNodeVisit?.Invoke(this, _currentNode);
            
            if (_currentNode.SubNodes.Count > 1)
                HookOnPreSplitAtNode?.Invoke(this, _currentNode);
            
            var removed = _firingNode.Pop();

            foreach (var sub in removed.SubNodes)
            {
                _firingNode.Push(sub);
            }

            if (removed.SubNodes.Count > 1)
            {
                foreach (var sub in removed.SubNodes)
                    HookOnPostSplitAtSubnode?.Invoke(this, sub);
            }

            if (_currentNode.SubNodes.Count == 0)
                HookOnLeafVisit?.Invoke(this, _currentNode);

            return true;
        }

        private void Enumerable_HookOnNodeVisit(object sender, Node e)
        {
            paths[pathIndex].Append(e.Data);
        }

        private void Enumerable_HookOnLeafVisit(object sender, Node e)
        {
            pathIndex++;
        }

        private void Enumerable_HookOnPreSplitAtNode(object sender, Node e)
        {
            rootPath = paths[pathIndex];
            paths.Remove(rootPath);
        }

        private void Enumerable_HookOnPostSplitAtSubnode(object sender, Node e)
        {
            paths.Add(new StringBuilder(rootPath.ToString()));
        }
    }
}
