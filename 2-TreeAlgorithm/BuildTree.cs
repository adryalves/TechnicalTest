using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeAlgorithm
{
    public class BuildTree
    {
        public TreeNode Build(int[] array, int start, int end)
        {
            if (start > end)
                return null;

            int maxIndex = start;
            for (int i = start + 1; i <= end; i++)
            {
                if (array[i] > array[maxIndex])
                    maxIndex = i;
            }

            TreeNode node = new TreeNode(array[maxIndex]);

            node.Left = Build(array, start, maxIndex - 1);
            node.Right = Build(array, maxIndex + 1, end);

            return node;
        }

    }
}
