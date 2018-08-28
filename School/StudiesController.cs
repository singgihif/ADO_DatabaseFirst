using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    class StudiesController
    {
        SchoolsEntities _context = new SchoolsEntities();
        int input;
        public void Menu()
        {
            System.Console.WriteLine("=====================");
            System.Console.WriteLine("1. Get All");
            System.Console.WriteLine("2. Get By Id");
            System.Console.WriteLine("3. Insert");
            System.Console.WriteLine("4. Update");
            System.Console.WriteLine("5. Delete");
            System.Console.WriteLine("=====================");
            System.Console.Write("pilihan kalian : ");
            int choice = Convert.ToInt32(System.Console.ReadLine());

            switch (choice)
            {
                case 1:
                    GetAll();
                    System.Console.Read();
                    break;
                case 2:
                    System.Console.Write("Masukkan Id yang ingin di cari : ");
                    input = Convert.ToInt32(System.Console.ReadLine());
                    GetById(input);
                    System.Console.Read();
                    break;
                case 3:
                    Insert();
                    System.Console.Read();
                    break;
                case 4:
                    System.Console.Write("Masukkan Id yang ingin di ubah : ");
                    input = Convert.ToInt32(System.Console.ReadLine());
                    Update(input);
                    System.Console.Read();
                    break;
                case 5:
                    System.Console.Write("Masukkan Id yang ingin hapus : ");
                    input = Convert.ToInt32(System.Console.ReadLine());
                    Delete(input);
                    System.Console.Read();
                    break;
                default:
                    System.Console.Write("Periksa kembali");
                    System.Console.Read();
                    break;
            }
        }

        public void Insert()
        {
            System.Console.Write("Masukkan Nama Mata Pelajaran : ");
            string Nama_Matapelajaran = System.Console.ReadLine();
            System.Console.Write("Masukkan Id Mata Pelajaran : ");
            int Id_Mp = Convert.ToInt32(System.Console.ReadLine());
            var getdept = _context.Studies.Find(Id_Mp);
            Study study = new Study()
            {
                ID = Id_Mp,
                Name_study = Nama_Matapelajaran
            };
            try
            {
                _context.Studies.Add(study);
                var result = _context.SaveChanges();
            }
            catch (Exception ex)
            {
                System.Console.Write(ex.InnerException);
            }
        }

        public int Update(int input)
        {
            System.Console.WriteLine("Masukkan Nama Mata Pelajaran : ");
            string Nama_Matapelajaran = System.Console.ReadLine();
            Study study = GetById(input);
            study.Name_study = Nama_Matapelajaran;
            _context.Entry(study).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
            return input;
        }

        
        public List<Study> GetAll()
        {
            var getall = _context.Studies.ToList();
            foreach (Study study in getall)
            {
                System.Console.WriteLine("================");
                System.Console.WriteLine("Id : " + study.ID);
                System.Console.WriteLine("Nama Mata Pelajaran : " + study.Name_study);
                System.Console.WriteLine("================");
            }
            return getall;
        }

        public void Delete(int input)
        {
            var study = _context.Studies.FirstOrDefault(x => x.ID == input);
            try
            {
                if (study == null)
                {
                    System.Console.WriteLine("Id Tidak Tersedia");
                }
                else
                {
                    var x = (from y in _context.Studies
                             where y.ID == input
                             select y).FirstOrDefault();
                    _context.Studies.Remove(x);
                    _context.SaveChanges();
                    System.Console.WriteLine("Hapus Data Sukses");
                }
            }
            catch (Exception ex)
            {
                System.Console.Write(ex.InnerException);
            }
        }

        public Study GetById(int input)
        {
            var study = _context.Studies.FirstOrDefault(x => x.ID == input);
            if (study == null)
            {
                System.Console.WriteLine("Id tersebut tidak ada");
            }
            else if (study.ID == input)
            {
                Console.WriteLine("Kode Siswa : " + study.ID);
                Console.WriteLine("Nama Siswa : " + study.Name_study);
            }
            return study;
        }
    }
}
