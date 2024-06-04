using System.Text;

namespace buoi1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Khai báo mảng số nguyên có 10 phần tử
            const int MAX = 100;
            int n;
            float[,] a = new float[MAX, MAX];

            Console.OutputEncoding = Encoding.UTF8;
            Console.Write("Nhập kích thước của ma trận vuông (n): ");
            n = int.Parse(Console.ReadLine());

            Console.WriteLine("\n- Nhập các phần tử của ma trận:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"\ta [{i}][{j}] = ");
                    a[i, j] = float.Parse(Console.ReadLine());
                }
            }

            Console.WriteLine("\n- Ma trận vừa nhập là:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write("\t" + a[i, j] + "    ");
                }
                Console.WriteLine();
            }

            float sum = 0;
            for (int i = 0; i < n; i++)
            {
                sum += a[i, i];
            }


            Console.WriteLine($"\n=> Tổng đường chéo chính của ma trận là: {sum}");
        }


    }
    
}
