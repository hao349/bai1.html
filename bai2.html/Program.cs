using System;
using Managers;

class Program
{
    static void Main()
    {
        StudentManager studentManager = new StudentManager();
        int choice;
        do
        {
            Console.Clear();
            Console.WriteLine("===== QUAN LY SINH VIEN =====\n");
            Console.WriteLine("1 - Them Sinh Vien");
            Console.WriteLine("2 - Xem danh sach");
            Console.WriteLine("3 - Cap nhat thong tin");
            Console.WriteLine("4 - Xoa sinh vien");
            Console.WriteLine("5 - Thoat");
            Console.Write("\n Nhap lua Chon: ");
         
           
            string input = Console.ReadLine();

            if (!int.TryParse(input, out choice) || choice < 1 || choice > 5)
            {
                Console.WriteLine("\nLua chon khong hop le! Nhan Enter de thu lai...");
                Console.ReadLine();
                continue;
            }
            

            Console.WriteLine();
            switch (choice)
            {
                case 1:
                    studentManager.AddStudent();
                    break;
                case 2:
                    studentManager.ListStudents();
                    break;
                case 3:
                    studentManager.UpdateStudent();
                    break;
                case 4:
                    studentManager.DeleteStudent();
                    break;
                case 5:
                    Console.WriteLine("\nThoat chuong trinh... Nhan Enter de ket thuc.");
                    Console.ReadLine();
                    break;
            }

        } while (choice != 5);
    }
}
    

