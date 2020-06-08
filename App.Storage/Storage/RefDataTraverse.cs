using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Storage
{
    public class RefDataTraverse//as DFS
    {
        public void Traverse(RefData node, Visitor visitor)
        {
            visitor.Visit(node);
            foreach (var sub in node.SubNodes)
            {
                Traverse(sub, visitor);
            }
        }
    }

    public class RefDataDownsideTraverseWithCondition
    {
        public virtual bool Traverse(RefData node, VisitorWithCondition visitor)
        {
            if (visitor.Visit(node))
                return true;

            foreach (var sub in node.SubNodes)
            {
                if (Traverse(sub, visitor))
                    return true;
            }

            return false;
        }
    }

    //because possible path select when one branch is splitting - in that case we should use some kind of selection logic
    public class RefDataDownsideAccumulateTraverseWithBranchPathAsString
    {
        private Expression<Func<RefData, bool>> _nextNodePredicate;
        private readonly string _traversePath;

        public RefDataDownsideAccumulateTraverseWithBranchPathAsString(string traversePath)
        {
            _traversePath = traversePath ?? throw new ArgumentNullException(nameof(traversePath));
        }

        public void Traverse(RefData node, VisitorWithStateAsString visitor)
        {
            visitor.Visit(node);

            _nextNodePredicate = nextNode => _traversePath.TrimStart(visitor.GetState().ToString().ToCharArray())
                                                          .StartsWith(nextNode.Data.ToString());

            foreach (var sub in node.SubNodes.Where(_nextNodePredicate.Compile()))
            {
                Traverse(sub, visitor);
            }
        }
    }

    //because possible path select when one branch is splitting - in that case we should use some kind of selection logic
    public class RefDataConcretePathTraverser
    {
        private Expression<Func<RefData, bool>> _nextNodePredicate;
        private RefData _traversePath;

        public RefDataConcretePathTraverser(RefData traversePath)
        {
            _traversePath = traversePath ?? throw new ArgumentNullException(nameof(traversePath));
        }

        public void Traverse(RefData node, VisitorWithStateAsRefData visitor)
        {
            visitor.Visit(node);

            _traversePath = _traversePath.SubNodes.SingleOrDefault();

            if (_traversePath == null)
                return;

            _nextNodePredicate = nextNode => nextNode.Data == _traversePath.Data;

            Traverse(node.SubNodes.Where(_nextNodePredicate.Compile()).SingleOrDefault(), visitor);
        }
    }

    public class RefDataDownsideTraverserSavingAllSubnode
    {
        public RefDataDownsideTraverserSavingAllSubnode()
        {

        }

        public void Traverse(RefData node, Visitor visitor)
        {
            visitor.Visit(node);
            foreach (var sub in node.SubNodes)
            {
                Traverse(sub, visitor);
            }
        }
    }

    public class RefDataDownsideTraverserWithSeekSatisfiedPaths
    {
        private Expression<Func<RefData, bool>> _nextNodePredicate;
        private IList<StringBuilder> _paths;

        private Stack<char> _traversedPath;
        private RefData _targetTraversePath;

        public RefDataDownsideTraverserWithSeekSatisfiedPaths(RefData traversePath)
        {
            _targetTraversePath = traversePath ?? throw new ArgumentNullException(nameof(traversePath));
            _paths = new List<StringBuilder>();
            _traversedPath = new Stack<char>();
        }

        public void Traverse(RefData node)
        {
            _traversedPath.Push(node.Data);
            var nextNodes = Enumerable.Empty<RefData>();
            var isTraverseAlongPath = _targetTraversePath.SubNodes.Any();
            if (isTraverseAlongPath)
            {
                _targetTraversePath = _targetTraversePath.SubNodes.SingleOrDefault();//next target node(from straight path)
                _nextNodePredicate = nextNode => nextNode.Data == _targetTraversePath.Data;
                nextNodes = node.SubNodes.Where(_nextNodePredicate.Compile());
            }
            else
            {
                nextNodes = node.SubNodes;
            }

            if (!nextNodes.Any())
            {
                _paths.Add(new StringBuilder(new string(_traversedPath.AsEnumerable().Reverse().ToArray())));
                return;
            }

            foreach (var sub in nextNodes)
            {
                Traverse(sub);
                _traversedPath.Pop();
            }
        }

        public IList<StringBuilder> GetTraversedPaths() => _paths;
    }

    /// <summary>
    /// traverse refData by tree struture using straight sourceHead as map if any branchin accure
    /// </summary>
    public class RefDataDownsideAccumulateTraverseWithStraightBranch
    {
        private RefData _currentHead;

        public RefDataDownsideAccumulateTraverseWithStraightBranch(RefData sourceHead)
        {
            _currentHead = sourceHead ?? throw new ArgumentNullException(nameof(sourceHead));
        }

        public void Traverse(RefData node, VisitorWithStateAsString visitor)
        {
            visitor.Visit(node);

            _currentHead = _currentHead.SubNodes.FirstOrDefault();

            foreach (var sub in node.SubNodes.Where(sub => _currentHead != null && sub.Data == _currentHead.Data))
            {
                Traverse(sub, visitor);
            }
        }
    }
}
