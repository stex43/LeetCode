using System;
using System.Collections;
using System.Collections.Generic;

namespace Problems.BinaryTrees
{
    public sealed class TreeNode
    {
        public int val;
        public TreeNode? left;
        public TreeNode? right;

        public TreeNode(int val = 0, TreeNode? left = null, TreeNode? right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }

        private bool Equals(TreeNode other)
        {
            return this.val == other.val && Equals(this.left, other.left) && Equals(this.right, other.right);
        }

        public override bool Equals(object? obj)
        {
            return ReferenceEquals(this, obj) || obj is TreeNode other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.val, this.left, this.right);
        }
    }
}