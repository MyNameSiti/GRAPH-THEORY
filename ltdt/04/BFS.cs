using System;
using System.Collections.Generic;
using System.Text;

namespace _04
{
    class BFS
    {
        static void search(int[,] mtk, int soluong, string[] cacdinh)
        {
            int[] bien = new int[soluong * soluong];
            int dinh = 0;
            Stack<int> full = new Stack<int>();
            full.Push(dinh);
        TIEP:
            Console.Write("{0}\t", cacdinh[dinh]);
            for (int i = 0; i <= soluong; i++)
            {
                try
                {
                    if (full.Contains(i))
                        continue;
                    if (mtk[dinh, i] == 1)
                    {
                        mtk[dinh, i] = 0;
                        mtk[i, dinh] = 0;                       
                        full.Push(i);
                        Console.Write("{0}\t", cacdinh[i]);
                    }
                }
                catch (System.IndexOutOfRangeException)
                { }
            }
            Console.WriteLine();
            dinh++;
            if (dinh != soluong) goto TIEP;

        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.Write("nhập số lượng đỉnh: "); //nhập đỉnh
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


            Console.WriteLine("nhập vào số cạnh: ");  //nhập số cạnh
            int socanh = int.Parse(Console.ReadLine());
            string[] canh1 = new string[socanh];
            string[] canh2 = new string[socanh];


            for (int i = 0; i < socanh; i++)  //nhập cạnh 
            {
                Console.WriteLine("cạnh thứ {0}: ", i);
                Console.Write("Nhập đỉnh đầu: ");
                canh1[i] = Console.ReadLine();
                Console.Write("Nhập đỉnh cuối: ");
                canh2[i] = Console.ReadLine();
            }

            //ma trận kề 0
            int[,] mtk = new int[a, a];
            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < a; j++)
                {
                    mtk[i, j] = 0;
                }
            }

            //kiểm tra và hoàn thành ma trận

            for (int i = 0; i <= a; i++)
            {
                for (int j = i + 1; j < a; j++)
                {
                    for (int k = 0; k < socanh; k++)
                    {
                        if (canh1[k] == dinh[i])
                        {
                            if (canh2[k] == dinh[j])
                            {
                                Console.WriteLine("{0},{1}", dinh[i], dinh[j]);
                                mtk[i, j] = 1;
                                mtk[j, i] = 1;
                            }

                        }
                        else if (canh1[k] == dinh[j])
                        {
                            if (canh2[k] == dinh[i])
                            {
                                Console.WriteLine("{0},{1}", dinh[i], dinh[j]);
                                mtk[i, j] = 1;
                                mtk[j, i] = 1;
                            }
                        }
                    }
                }
            }
            search(mtk, a, dinh);

            Console.ReadKey();
        }
    }
}


