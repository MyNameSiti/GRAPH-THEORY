using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06
{
    class MTTS
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.Write("nhập vào số lượng đỉnh: ");
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
            // nhập vào số lượng cạnh
            Console.WriteLine("nhập vào số cạnh : ");
            int socanh = int.Parse(Console.ReadLine());
            string[] canh1 = new string[socanh];
            string[] canh2 = new string[socanh];
            for (int i = 0; i < socanh; i++)
            {
                Console.WriteLine("cạnh thứ {0}: ", i);
                Console.Write("Nhập đỉnh đầu: ");
                canh1[i] = Console.ReadLine();
                Console.Write("Nhập đỉnh cuối: ");
                canh2[i] = Console.ReadLine();
            }
            //tạo ma trận rỗng
            int[,] mtts = new int[a, a];
            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < a; j++)
                {
                    mtts[i, j] = 0;
                }
            }

            for (int i = 0; i < a; i++)
            {
                for (int j = i; j < a; j++)
                {
                    for (int k = 0; k < socanh; k++)
                    {
                        if (canh1[k] == dinh[i])
                        {
                            if (canh2[k] == dinh[j])
                            {
                                Console.WriteLine("nhập trọng số cạnh ( {0} , {1} ): ", dinh[i], dinh[j]);
                                mtts[i, j] = int.Parse(Console.ReadLine());
                                mtts[j, i] = mtts[i, j];
                            }
                        }

                    }
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
                    Console.Write(mtts[i, j] + "\t");
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}