using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    class StudentController
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
            System.Console.Write("Masukkan Nama Siswa : ");
            string Nama_Siswa = System.Console.ReadLine();
            System.Console.Write("Masukkan Tanggal Lahir : ");
            DateTime Tanggal_lahir = Convert.ToDateTime(System.Console.ReadLine());
            System.Console.Write("Masukkan Alamat : ");
            string Alamat_siswa = System.Console.ReadLine();
            System.Console.Write("Masukkan Nama Ayah : ");
            string Nama_ayah = System.Console.ReadLine();
            System.Console.Write("Masukkan Id Siswa : ");
            int Id_Siswa = Convert.ToInt32(System.Console.ReadLine());
            System.Console.Write("Masukkan Id Mata Pelajaran : ");
            int Id_Mp = Convert.ToInt32(System.Console.ReadLine());
            var getdept = _context.Studies.Find(Id_Mp);
            if (getdept == null)
            {
                System.Console.Write("Tidak ada Id department : " + Id_Mp);
            }
            else
            {
                Student student = new Student()
                {
                    Studies_id = Id_Mp,
                    Name_student = Nama_Siswa,
                    Birth = Tanggal_lahir,
                    Location = Alamat_siswa,
                    Name_father = Nama_ayah,
                    ID = Id_Siswa
                };
                _context.Students.Add(student);
                _context.SaveChanges();
            }
        }

        public int Update(int input)
        {
            System.Console.Write("Masukkan Nama Siswa : ");
            string Nama_Siswa = System.Console.ReadLine();
            System.Console.Write("Masukkan Tanggal Lahir : ");
            DateTime Tanggal_lahir = Convert.ToDateTime(System.Console.ReadLine());
            System.Console.Write("Masukkan Alamat : ");
            string Alamat_siswa = System.Console.ReadLine();
            System.Console.Write("Masukkan Nama Ayah : ");
            string Nama_ayah = System.Console.ReadLine();
            System.Console.Write("Masukkan Id Mata Pelajaran : ");
            int Id_Mp = Convert.ToInt32(System.Console.ReadLine());
            var getdept = _context.Studies.Find(Id_Mp);
            if (getdept == null)
            {
                System.Console.Write("Tidak ada Id department : " + Id_Mp);
            }
            else
            {
                Student student = GetById(input);
                student.Name_student = Nama_Siswa;
                student.Birth = Tanggal_lahir;
                student.Location = Alamat_siswa;
                student.Name_father = Nama_ayah;
                student.ID = Id_Mp;

                _context.Entry(student).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();
            }
            return input;
        }

        public void Delete(int input)
        {
            var student = _context.Students.FirstOrDefault(x => x.ID == input);
            try
            {
                if (student == null)
                {
                    System.Console.WriteLine("Id Tidak Tersedia");
                }
                else
                {
                    var x = (from y in _context.Students
                             where y.ID == input
                             select y).FirstOrDefault();
                    _context.Students.Remove(x);
                    _context.SaveChanges();
                    System.Console.WriteLine("Hapus Data Sukses");
                }
            }
            catch (Exception ex)
            {
                System.Console.Write(ex.InnerException);
            }
        }


        public List<Student> GetAll()
        {
            var getall = _context.Students.ToList();
            foreach (Student student in getall)
            {
                System.Console.WriteLine("================");
                System.Console.WriteLine("Id : " + student.ID);
                System.Console.WriteLine("Nama Depan : " + student.Name_student);
                System.Console.WriteLine("Nama Belakang : " + student.Birth);
                System.Console.WriteLine("Phone Number : " + student.Location);
                System.Console.WriteLine("Birth Date : " + student.Name_father);
                System.Console.WriteLine("Department : " + student.Study.Name_study);
                System.Console.WriteLine("================");
            }
            return getall;
        }

        public Student GetById(int input)
        {
            var student = _context.Students.FirstOrDefault(x => x.ID == input);
            if (student == null)
            {
                System.Console.WriteLine("Id tersebut tidak ada");
            }
            else if (student.ID == input)
            {
                Console.WriteLine("Kode Siswa : " + student.ID);
                Console.WriteLine("Nama Siswa : " + student.Name_student);
            }
            return student;
        }
    }
}
