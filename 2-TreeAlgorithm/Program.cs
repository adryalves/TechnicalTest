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
        /// É método principal a ser executado no projeto.
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
                Console.WriteLine("Entrada vazia.");
                Console.ReadKey();
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

            Console.Write("Galhos da esquerda: ");
            PrintLinear(root.Left);
            Console.WriteLine();

            Console.Write("Galhos da direita: ");
            PrintLinear(root.Right);
            Console.WriteLine();

            Console.WriteLine("\nÁrvore construída:");
            PrintTree(root);

            Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
            Console.ReadKey();
        }

        /// <summary>
        /// Método Recursivo para exibir os valores do nó a direita ou a esquerda
        static void PrintLinear(TreeNode node)
        {
            if (node == null) return;

            Console.Write(node.Value + " ");
            PrintLinear(node.Left);
            PrintLinear(node.Right);
        }

        /// <summary>
        /// Esse método busca exibir na tela a forma "figurativa" da árvore contendo os valores corretos
        /// </summary>
        static void PrintTree(TreeNode root)
        {

            int height = Height(root);
            int maxWidth = (int)Math.Pow(2, height) * 2;

            TreeNode[] current = new TreeNode[] { root };

            for (int level = 1; level <= height; level++)
            {
                int spacesBetween = maxWidth / (int)Math.Pow(2, level);
                int spacesBefore = spacesBetween / 2;

                Console.Write(new string(' ', spacesBefore));
                TreeNode[] next = new TreeNode[current.Length * 2];
                int index = 0;

                foreach (var node in current)
                {
                    if (node == null)
                    {
                        Console.Write(" ");
                        next[index++] = null;
                        next[index++] = null;
                    }
                    else
                    {
                        Console.Write(node.Value);
                        next[index++] = node.Left;
                        next[index++] = node.Right;
                    }
                    Console.Write(new string(' ', spacesBetween));
                }

                Console.WriteLine();

                if (level < height)
                {
                    Console.Write(new string(' ', spacesBefore - 1));

                    foreach (var node in current)
                    {
                        if (node == null)
                        {
                            Console.Write("  ");
                        }
                        else
                        {
                            Console.Write(node.Left != null ? "/" : " ");
                            Console.Write(" ");
                            Console.Write(node.Right != null ? "\\" : " ");
                        }
                        Console.Write(new string(' ', spacesBetween - 1));
                    }
                    Console.WriteLine();
                }

                current = next;
            }
        }

        /// <summary>
        /// Método também recursivo para saber o tamanho da árvore
        /// </summary>
        static int Height(TreeNode node)
        {
            if (node == null) return 0;
            return 1 + Math.Max(Height(node.Left), Height(node.Right));
        }
    }
}
