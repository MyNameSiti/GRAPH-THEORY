using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace _08
{
    class Dijkstra
    {
        //tìm giá trị nhỏ nhất
        private static int MinimumDistance(int[] distance, bool[] shortestPathTreeSet, int verticesCount)
        {
            int min = int.MaxValue;
            int minIndex = 0;
            //cho chạy từ o đến số lượng đỉnh
            for (int v = 0; v < verticesCount; ++v)
            {
                //tìm đỉnh nhỏ nhất sau đó trả về trả về 
                if (shortestPathTreeSet[v] == false && distance[v] <= min)
                {
                    min = distance[v];
                    minIndex = v;
                }
            }
            return minIndex;
        }
        //vẽ 
        private static void Print(int[] distance, int verticesCount)
        {
            Console.WriteLine("đường đi    trọng lượng của đường đi");
            for (int i = 0; i < verticesCount; ++i)
                Console.WriteLine("0-{0}\t      {1}", i, distance[i]);
        }
        //thuật toán
        public static void DijkstraAlgo(int[,] graph, int source, int verticesCount)
        {
            int[] distance = new int[verticesCount];
            bool[] shortestPathTreeSet = new bool[verticesCount];
            //gắn khoảng cách là maximum và các đường đi là false
            for (int i = 0; i < verticesCount; ++i)
            {
                distance[i] = int.MaxValue;
                shortestPathTreeSet[i] = false;
            }
            //khoảng cách từ đỉnh là 0
            distance[source] = 0;
            for (int count = 0; count < verticesCount - 1; ++count)
            {
                //tìm giá trị nhỏ nhất
                int u = MinimumDistance(distance, shortestPathTreeSet, verticesCount);
                //trả về vị trí đó là true
                shortestPathTreeSet[u] = true;
                for (int v = 0; v < verticesCount; ++v)
                    //nếu đường đi đúng, đồ thị đúng, khoảng cách đã thay đổi vầ khoảng cách từ đỉnh u cộng với trọng số nhỏ hơn v
                    if (!shortestPathTreeSet[v] && Convert.ToBoolean(graph[u, v]) && distance[u] != int.MaxValue && distance[u] + graph[u, v] < distance[v])
                        distance[v] = distance[u] + graph[u, v];
            }

            Print(distance, verticesCount);
        }

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
            Console.Write("chọn vị trí: ");
            int vitri = int.Parse(Console.ReadLine());
            DijkstraAlgo(mtts, vitri, a);
            Console.ReadKey();
        }
    }
}