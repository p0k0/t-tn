using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Storage
{
    public abstract class Visitor
    {
        public abstract void Visit(RefData node);
    }

    public abstract class VisitorWithCondition
    {
        public abstract bool Visit(RefData node);
    }

    public class FindVisitor : VisitorWithCondition
    {
        private readonly RefData _targetNode;

        public FindVisitor(RefData targetNode)
        {
            _targetNode = targetNode ?? throw new ArgumentNullException(nameof(targetNode));
        }

        public override bool Visit(RefData node)
        {
            if (node.Data != _targetNode.Data)
                return false;

            return true;
        }
    }

    public abstract class Visitor<T> : Visitor
    {
        private readonly VisitorState<T> _state;

        internal Visitor(VisitorState<T> state)
        {
            _state = state;
        }

        public override void Visit(RefData node)
        {
            _state.ChangeState(node);
        }

        public T GetState() => _state.Data;
    }

    public class VisitorWithStateAsString : Visitor<StringBuilder>
    {
        internal VisitorWithStateAsString() : base(new VisitorStateAsString()) { }

        internal VisitorWithStateAsString(VisitorState<StringBuilder> state) : base(state) { }
    }

    public class VisitorWithStateAsRefData : Visitor<RefData>
    {
        internal VisitorWithStateAsRefData() : base(new VisitorStateAsRefData()) { }

        internal VisitorWithStateAsRefData(VisitorState<RefData> state) : base(state) { }
    }

    public class AccumulatingPathVisitorWithStateAsRefData : Visitor<RefData>
    {
        private int _counter;
        private IList<StringBuilder> _paths;

        internal AccumulatingPathVisitorWithStateAsRefData() : base(new VisitorStateAsRefData()) 
        {
            _paths = new List<StringBuilder>();
        }

        internal AccumulatingPathVisitorWithStateAsRefData(VisitorState<RefData> state) : base(state) 
        {
            _paths = new List<StringBuilder>();
        }

        public override void Visit(RefData node)
        {
            if (node.SubNodes.Any())//it last node at curent path traverse
            {
                if (_paths[_counter] == null)
                    _paths[_counter] = new StringBuilder();

                _paths[_counter].Append(node.Data);
            }
            else
            {
                _counter++;
            }
        }
    }
}
