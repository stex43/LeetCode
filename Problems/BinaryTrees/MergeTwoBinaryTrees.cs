using System.Collections.Generic;
using NUnit.Framework;

namespace Problems.BinaryTrees
{
    [TestFixture]
    public sealed class MergeTwoBinaryTrees
    {
        private static IEnumerable<TestCaseData> TestCases()
        {
            yield return new TestCaseData()
                .SetName("{a} {m}")
                .Returns(0);
        }

        // [TestCaseSource(nameof(TestCases))]
        // public TreeNode? Mine_First(TreeNode root1, TreeNode root2)
        // {
        //     return MergeTrees(root1, root2);
        // }

        
        [Test]
        public void Mine_First()
        {
            var root1 = new TreeNode(1, new TreeNode(3, new TreeNode(5)), new TreeNode(2));
            var root2 = new TreeNode(2, new TreeNode(1, left: null, new TreeNode(4)),
                new TreeNode(3, left: null, new TreeNode(7)));
            var r = MergeTrees(root1, root2);
        }

        private static TreeNode? MergeTrees(TreeNode? root1, TreeNode? root2)
        {
            if (root1 == null && root2 == null)
            {
                return null;
            }

            var first = root1?.val ?? 0;
            var second = root2?.val ?? 0;
            var root = new TreeNode(first + second);

            root.left = MergeTrees(root1?.left, root2?.left);
            root.right = MergeTrees(root1?.right, root2?.right);

            return root;
        }
    }
}
