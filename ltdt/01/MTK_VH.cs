using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01
{
    class MTK_VH
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.Write("nhập số lượng đỉnh: ");
            int a = int.Parse(Console.ReadLine());
            string[] dinh = new string[a];
            for (int i = 0; i < a; i++)
            {
                Console.WriteLine("nhập vào các đỉnh: ");
                dinh[i] = Console.ReadLine();
            }
            Console.Write("các đỉnh là\n");
            for (int i = 0; i < a; i++)
            {
                Console.Write("{0}\t", dinh[i]);
            }
            Console.WriteLine();
            Console.WriteLine("nhập vào số cạnh không vẽ: ");
            int socanhkove = int.Parse(Console.ReadLine());
            string[] canhkove1 = new string[socanhkove];
            string[] canhkove2 = new string[socanhkove];
            for (int i = 0; i < socanhkove; i++)
            {
                Console.WriteLine("cạnh thứ {0}: ", i);
                Console.Write("Nhập đỉnh đầu: ");
                canhkove1[i] = Console.ReadLine();
                Console.Write("Nhập đỉnh cuối: ");
                canhkove2[i] = Console.ReadLine();
            }

            //ma trận kề 
            int[,] mtk = new int[a, a];
            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < a; j++)
                {
                    mtk[i, j] = 0;
                }
            }
            for (int i = 0; i <= a; i++)
            {
                for (int j = i + 1; j < a; j++)
                {
                    for (int k = 0; k < socanhkove; k++)
                    {
                        if (canhkove1[k] == dinh[i])
                        {
                            if (canhkove2[k] == dinh[j])
                            {
                                goto DEN;
                            }

                        }

                    }
                    Console.WriteLine("{0},{1}", dinh[i], dinh[j]);
                    mtk[i, j] = 1;
                    mtk[j, i] = 1;
                DEN:;
                }
            }
            Console.Write("\t");
            for (int i = 0; i < a; i++)
            {
                Console.Write(dinh[i] + "\t");
            }
            Console.WriteLine();
            for (int i = 0; i < a; i++)
            {
                Console.Write("{0}\t", dinh[i]);
                for (int j = 0; j < a; j++)
                {
                    Console.Write(mtk[i, j] + "\t");
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}


