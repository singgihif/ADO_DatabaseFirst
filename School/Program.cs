using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("==============================");
            System.Console.WriteLine("1. Pelajar");
            System.Console.WriteLine("2. Mata Pelajaran");
            System.Console.WriteLine("=====================");
            System.Console.Write("pilihan kalian : ");
            int pilih = Convert.ToInt32(System.Console.ReadLine());
            switch (pilih)
            {
                case 1:
                    StudentController panggilstudt = new StudentController();
                    panggilstudt.Menu();
                    break;
                case 2:
                    StudiesController panggilstudy = new StudiesController();
                    panggilstudy.Menu();
                    break;
                default:
                    System.Console.Write("Periksa kembali");
                    System.Console.Read();
                    break;

            }
        }
    }
}
