using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeAlgorithm
{
    public class Program
    {
        /// <summary>
        /// É método principal a ser executado no projeto. Ele faz a chamada do Menu em Loop até que o usuário escolha parar o projeto
        /// </summary>
        static void Main()
        {
            while (ShowMenu()) { }
        }

        /// <summary>
        /// Esse método serve para descrever o menu. Ele foi criado para facilitar a chamada do menu, quando por algum
        /// motivo, como o usuário responde algo inválido, precisar voltar as opções do menu
        /// </summary>
        static bool ShowMenu()
        {
            Console.WriteLine("===== MENU =====");
            Console.WriteLine("1 - Digitar array e construir árvore");
            Console.WriteLine("0 - Sair");
            Console.Write("Opção: ");

            string option = Console.ReadLine();

            if (option == "0")
            {
                Console.WriteLine("Encerrando...");
                return false;
            }

            if (option != "1")
            {
                Console.WriteLine("Opção inválida.");
                return true;
            }

            ReadAndBuildTree();
            return true;
        }
        /// <summary>
        /// Esse método faz a leitura do array digitado pelo usuário, faz a validação dele,
        /// chama o método para criar a árvore e por fim, começa a exibir na tela os dados e faz
        /// a chamada para métodos auxiliares de exibição
        /// </summary>
        static void ReadAndBuildTree()
        {
            Console.WriteLine("Digite os números do array separados por espaço ou vírgula:");
            string input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Entrada vazia. Tente novamente...");
                return;
            }

            string[] parts = input
                .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

            int[] array = new int[parts.Length];

            for (int i = 0; i < parts.Length; i++)
            {
                if (!int.TryParse(parts[i], out array[i]))
                {
                    Console.WriteLine("Entrada inválida. Use apenas números inteiros.");
                    return;
                }
            }

            if (array.Length != array.Distinct().Count())
            {
                Console.WriteLine("Não pode haver números repetidos.");
                return;
            }

            BuildTree builder = new BuildTree();

            TreeNode root = builder.Build(array, 0, array.Length - 1);

            Console.WriteLine($"\nRaiz: {root.Value}");

            List<int> leftBranch = new List<int>();
            CollectValues(root.Left, leftBranch);
            leftBranch.Sort((a, b) => b.CompareTo(a));

            List<int> rightBranch = new List<int>();
            CollectValues(root.Right, rightBranch);
            rightBranch.Sort((a, b) => b.CompareTo(a));

            Console.Write($"Galhos da esquerda: {(leftBranch.Count > 0 ? string.Join(", ", leftBranch) : "")}");
            Console.WriteLine();

            Console.Write($"Galhos da direita: {(rightBranch.Count > 0 ? string.Join(", ", rightBranch) : "")}");
            Console.WriteLine();

            Console.WriteLine("\nÁrvore construída:");
            PrintVisualTree(root.Value, leftBranch, rightBranch);

            Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
            Console.ReadKey();
        }

        /// <summary>
        /// Método recursivo que percorre a árvore e coleta todos os valores dos nós em uma lista
        /// </summary>
        static void CollectValues(TreeNode node, List<int> list)
        {
            if (node == null) return;
            list.Add(node.Value);
            CollectValues(node.Left, list);
            CollectValues(node.Right, list);
        }

        /// <summary>
        /// Esse método busca exibir na tela a forma "figurativa" da árvore contendo os valores corretos
        /// </summary>
        static void PrintVisualTree(int rootVal, List<int> leftBranch, List<int> rightBranch)
        {
            int leftDepth = leftBranch.Count;
            int rightDepth = rightBranch.Count;
            int maxDepth = Math.Max(leftDepth, rightDepth);

            int step = 4;
            int rootX = (leftDepth + 1) * step;

            Console.WriteLine(new string(' ', rootX) + rootVal);

            for (int i = 1; i <= maxDepth; i++)
            {
                var sbSlash = new StringBuilder();
                var sbVal = new StringBuilder();

                int currentPos = 0;

                if (i <= leftDepth)
                {
                    int slashPos = rootX - ((i - 1) * step) - 2;
                    if (slashPos < 0) slashPos = 0;

                    if (slashPos > currentPos) sbSlash.Append(new string(' ', slashPos - currentPos));
                    sbSlash.Append("/");
                    currentPos = slashPos + 1;
                }

                if (i <= rightDepth)
                {
                    int slashPos = rootX + ((i - 1) * step) + 2;
                    if (slashPos > currentPos) sbSlash.Append(new string(' ', slashPos - currentPos));
                    sbSlash.Append("\\");
                }

                Console.WriteLine(sbSlash.ToString());

                currentPos = 0;
                if (i <= leftDepth)
                {
                    int val = leftBranch[i - 1];
                    int valPos = rootX - (i * step);
                    if (valPos < 0) valPos = 0;

                    if (valPos > currentPos) sbVal.Append(new string(' ', valPos - currentPos));
                    sbVal.Append(val);
                    currentPos = valPos + val.ToString().Length;
                }

                if (i <= rightDepth)
                {
                    int val = rightBranch[i - 1];
                    int valPos = rootX + (i * step);

                    if (valPos > currentPos) sbVal.Append(new string(' ', valPos - currentPos));
                    sbVal.Append(val);
                }
                Console.WriteLine(sbVal.ToString());
            }
        }
    }
}
