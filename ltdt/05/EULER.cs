using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05
{
    class EULER
    {
        static bool kiemtrachutrinh(int[,] mtk, int soluong)
        {
            int tam = 0;
            for (int i = 0; i < soluong; i++)
            {
                tam = 0;
                for (int j = 0; j < soluong; j++)
                {
                    if (mtk[i, j] == 1)
                    {
                        tam++;
                    }
                }
                if (tam % 2 == 1 || tam == 0)
                {
                    return false;
                }

            }
            return true;
        }
        static bool kiemtraduongdi(int[,] mtk, int soluong)
        {
            int tam = 0;
            int tam1 = 0;
            for (int i = 0; i < soluong; i++)
            {
                tam = 0;
                for (int j = 0; j < soluong; j++)
                {
                    if (mtk[i, j] == 1)
                    {
                        tam++;
                    }
                }
                if (tam == 0)
                {
                    return false;
                }
                if (tam % 2 == 1)
                {
                    tam1++;
                }
            }
            if (tam1 <= 2)
                return true;
            else return false;
        }
        static int kiemtra(int[,] mtk, int soluong)
        {
            if (kiemtrachutrinh(mtk, soluong))
            {
                return 1;
            }
            else if (kiemtraduongdi(mtk, soluong))
                return 0;
            else return -1;
        }
        static void chutrinh(int[,] mtk, int soluong, string[] cacdinh)
        {
            int dinh = 0;
        TIEP1:
            Console.Write("{0} ", cacdinh[dinh]);
        TIEP:
            for (int i = 0; i < soluong; i++)
            {
                if (mtk[dinh, i] == 1)
                {
                    Console.Write("{0} ", cacdinh[i]);
                    mtk[dinh, i] = 0;
                    mtk[i, dinh] = 0;
                    dinh = i;
                    goto TIEP;
                }
            }
            Console.WriteLine();
            if (kiemtramatranke(mtk, soluong) != -1)
            {
                dinh = kiemtramatranke(mtk, soluong);
                goto TIEP1;
            }

        }
        static int[] dinhcuaduongdi(int[,] mtk, int soluong)
        {
            int tam = 0;
            int[] tam1 = new int[2];
            int tam3 = 0;
            for (int i = 0; i < soluong; i++)
            {
                tam = 0;
                for (int j = 0; j < soluong; j++)
                {
                    if (mtk[i, j] == 1)
                    {
                        tam++;
                    }
                }
                if (tam % 2 == 1)
                {
                    tam1[tam3] = i;
                    tam3++;
                }
            }
            return tam1;
        }
        static void duongdi(int[,] mtk, int soluong, string[] cacdinh)
        {
            int[] bien = new int[soluong * soluong];
            int[] dinhle = new int[2];
            dinhle = dinhcuaduongdi(mtk, soluong);
            int dinh = dinhle[0];
        TIEP1:
            int tam = 0;
            bien[tam] = dinh;
            tam++;
        TIEP:
            for (int i = 0; i < soluong; i++)
            {
                if (mtk[dinh, i] == 1)
                {
                    bien[tam] = i;
                    tam++;
                    mtk[dinh, i] = 0;
                    mtk[i, dinh] = 0;
                    dinh = i;
                    goto TIEP;
                }
            }
            if (kiemtramatranke(mtk, soluong) != -1)
            {
                dinh = dinhle[0];
                goto TIEP1;
            }
            else
            {
                for (int i = 0; i < tam; i++)
                {
                    Console.Write("{0} ", cacdinh[bien[i]]);
                }
            }
        }
        static int kiemtramatranke(int[,] mtk, int soluong)
        {
            for (int i = 0; i < soluong; i++)
            {
                for (int j = 0; j < soluong; j++)
                {
                    if (mtk[i, j] == 1)
                        return i;
                }
            }
            return -1;
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
            if (kiemtra(mtk, a) == 1)
            {
                chutrinh(mtk, a, dinh);
            }
            else if (kiemtra(mtk, a) == 0)
                duongdi(mtk, a, dinh);
            else Console.WriteLine("đồ thị trên không có chu trình EULER");
            Console.ReadKey();
        }
    }
}
