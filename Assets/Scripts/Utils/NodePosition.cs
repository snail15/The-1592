using System;

namespace Utils {
    public struct NodePosition : IEquatable<NodePosition>
    {
        public int X { get; set; }
        public int Y { get; set; }

        public NodePosition(int x, int y)
        {
            X = x;
            Y = y;
        }

        public bool Equals(NodePosition other)
        {
            return this == other;
        }
        public override bool Equals(object obj)
        {
            return obj is NodePosition position && X == position.X && Y == position.Y;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }
        public override string ToString()
        {
            return $"X: {X}, Y: {Y}";
        }

        public static bool operator == (NodePosition a, NodePosition b)
        {
            return a.X == b.X && a.Y == b.Y;
        }

        public static bool operator !=(NodePosition a, NodePosition b)
        {
            return !(a == b);
        }

        public static NodePosition operator +(NodePosition a, NodePosition b)
        {
            return new NodePosition(a.X + b.X, a.Y + b.Y);
        }
    
        public static NodePosition operator -(NodePosition a, NodePosition b)
        {
            return new NodePosition(a.X - b.X, a.Y - b.Y);
        }
    }
}
