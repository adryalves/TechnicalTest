using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeAlgorithm
{
    /// <summary>
    /// Esse é o método que de fato constroi a árvore, ele recebe o array e os índices de inicio e fim,
    /// inicialmente é calculado o maior valor do array que é a raiz da árvore. E Após isso, tem-se 
    /// o cálculo dos nós da direita e da esquerda, esse método também é recursivo,  afim de ir construindo
    /// cada nó pertencente a outro nó
    /// </summary>
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
