using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07
{
    class lienthuoc
    {
        public string a, b;
        public int ten;
        public lienthuoc(string a, string b, int ten)
        {
            this.a = a;
            this.b = b;
            this.ten = ten;
        }
    }
    class MTLT
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
            int[] tencanh = new int[socanh];
            lienthuoc[] tt = new lienthuoc[socanh];
            for (int i = 0; i < socanh; i++)
            {
                Console.WriteLine("cạnh thứ {0}: ", i);
                Console.Write("Nhập đỉnh đầu: ");
                canh1[i] = Console.ReadLine();
                Console.Write("Nhập đỉnh cuối: ");
                canh2[i] = Console.ReadLine();
                tencanh[i] = i;
                tt[i] = new lienthuoc(canh1[i], canh2[i], tencanh[i]);
            }

            Console.Write("\t");
            for (int i = 0; i < socanh; i++)
            {
                Console.Write(tencanh[i] + "\t");
            }
            Console.WriteLine();
            for (int i = 0; i < a; i++)
            {
                Console.Write("{0}\t", dinh[i]);
                for (int j = 0; j < socanh; j++)
                {
                    try
                    {
                        if (dinh[i] == tt[j].a)
                            Console.Write("1\t");
                        else if (dinh[i] == tt[j].b)
                            Console.Write("1\t");
                        else Console.Write("0\t");
                    }
                    catch
                    {

                    }
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}

