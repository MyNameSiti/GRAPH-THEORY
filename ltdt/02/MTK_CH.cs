using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02
{
    class MTK_CH
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

                Nhap:
                    Console.WriteLine("chọn hướng của cạnh");
                    Console.WriteLine("1: [{0},{1}]", dinh[i], dinh[j]);
                    Console.WriteLine("2: [{0},{1}]", dinh[j], dinh[i]);
                    int biennho = int.Parse(Console.ReadLine());
                    switch (biennho)
                    {
                        case 1:
                            mtk[i, j] = 1;
                            break;
                        case 2:
                            mtk[j, i] = 1;
                            break;
                        default:
                            goto Nhap;

                    }
                DEN:;
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
                                goto DEN2;
                            }
                        }

                    }
                    if (mtk[i, j] == 1)
                    {
                        Console.WriteLine("{0},{1}", dinh[i], dinh[j]);
                    }
                    else Console.WriteLine("{0},{1}", dinh[j], dinh[i]);
                    DEN2:;
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
