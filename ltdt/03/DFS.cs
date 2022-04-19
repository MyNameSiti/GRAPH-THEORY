using System;
using System.Collections.Generic;
//using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03
{
    class DFS
    {
        public static void search(int[,] mtk, int soluong, string[] cacdinh)
        {
            int[] bien = new int[soluong * 2];
            Stack<int> full = new Stack<int>();
            int dinh = 0;
            int tam = 0;
        TIEP:
            for (int i = 0; i <= soluong; i++)
            {
                try
                {
                    if (mtk[dinh, i] == 1)
                    {

                        if (full.Contains(i))
                        {
                            mtk[dinh, i] = 0;
                            mtk[i, dinh] = 0;
                            continue;
                        }
                        else
                        {
                            full.Push(dinh);
                            bien[tam] = dinh;
                            tam++;
                            mtk[dinh, i] = 0;
                            mtk[i, dinh] = 0;
                            dinh = i;
                            goto TIEP;
                        }
                    }
                }
                catch (System.IndexOutOfRangeException)
                {
                }
                if (i == soluong && dinh != 0)
                {
                    bien[tam] = dinh;
                    dinh = full.Pop();

                    tam++;
                    goto TIEP;
                }
            }
            Console.WriteLine();
            for (int i = 0; i < tam + 1; i++)
            {
                Console.Write("{0}\t", cacdinh[bien[i]]);
            }


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
                        else if(canh1[k] == dinh[j])
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
