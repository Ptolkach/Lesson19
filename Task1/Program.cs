using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Computer> computers = new List<Computer>()
            {
                new Computer(){Articul = "00001", Name = "Gigabyte", TypeCPU = "Intel Core i7", FrequencyCPU = 2.2, RAM =16, SSD = 512, VideoRAM = 8192, Price=120, Availability = 30},
                new Computer(){Articul = "00002", Name = "MSI Pulse", TypeCPU = "Intel Core i5", FrequencyCPU = 2.7, RAM =8, SSD = 512, VideoRAM = 6144, Price=120, Availability = 60},
                new Computer(){Articul = "00003", Name = "MSI Stealth", TypeCPU = "Intel Core i9", FrequencyCPU = 2.5, RAM =32, SSD = 1024, VideoRAM = 8192, Price=234, Availability = 10},
                new Computer(){Articul = "00004", Name = "HP Victus", TypeCPU = "AMD Ryzen 5600H", FrequencyCPU = 3.3, RAM =16, SSD = 512, VideoRAM = 4096, Price=182, Availability = 20},
                new Computer(){Articul = "00005", Name = "Hasee z7", TypeCPU = "Intel Core i7", FrequencyCPU = 2.3, RAM =16, SSD = 512, VideoRAM = 4096, Price=80, Availability = 30},
                new Computer(){Articul = "00006", Name = "Lenovo", TypeCPU = "Intel Core i5", FrequencyCPU = 2.4, RAM =8, SSD = 256, VideoRAM = 2048, Price=61, Availability = 40},
                new Computer(){Articul = "00007", Name = "Hasee g8", TypeCPU = "Intel Core i7", FrequencyCPU = 2.3, RAM =16, SSD = 512, VideoRAM = 6144, Price=95, Availability = 50},
                new Computer(){Articul = "00008", Name = "MSI Creator Pro", TypeCPU = "Intel Core i9", FrequencyCPU = 2.3, RAM =64, SSD = 2048, VideoRAM = 16384, Price=403, Availability = 0},
                new Computer(){Articul = "00009", Name = "Asus x415jf", TypeCPU = "Intel Pentium 6805", FrequencyCPU = 1.1, RAM =4, SSD = 256, VideoRAM = 2048, Price=35, Availability = 70},
                new Computer(){Articul = "00010", Name = "Asus TUF Gaming", TypeCPU = "AMD Ryzen 6800H", FrequencyCPU = 3.2, RAM =8, SSD = 512, VideoRAM = 4096, Price=120, Availability = 15}
            };
            Console.WriteLine("Введите марку процессора");
            string cpu = Console.ReadLine().ToLower();
            List<Computer> comp1 = computers.Where(x => x.TypeCPU.ToLower().Contains(cpu)).ToList();
            Console.WriteLine("Список компьютеров с процессором марки {0}:",cpu);
            Print(comp1);

            Console.WriteLine("Введите объем оперативной памяти ОЗУ, Gb");
            int ram = Convert.ToInt32(Console.ReadLine());
            List<Computer> comp2 = computers.Where(x => x.RAM>=ram).ToList();
            Console.WriteLine($"Список компьютеров с объемом памяти от {ram}Gb:");
            Print(comp2);
            Console.WriteLine();

            Console.WriteLine("Cписок компьютеров, отсортированный по увеличению стоимости и по наличию:");
            List<Computer> comp3 = computers.OrderBy(x => x.Price).ThenBy(x => x.Availability).ToList();
            Print(comp3);

            Console.WriteLine("Список компьютеров сгруппированный по типу процессора:");
            IEnumerable<IGrouping<string, Computer>> comp4 = computers.GroupBy(x => x.TypeCPU);
            foreach (IGrouping<string, Computer> gr in comp4)
            {
                Console.WriteLine(gr.Key);
                foreach (Computer c in gr)
                {
                    Console.WriteLine($"{c.Articul} {c.Name} {c.TypeCPU} {c.Price} {c.Availability}");
                }
            }

            Console.WriteLine();

            int maxPrice = computers[0].Price;
            int minPrice = computers[0].Price;
            var compMaxPrice = computers[0];
            var compMinPrice = computers[0];
            int count = 0;
            foreach (var c in computers)
            {
                if (maxPrice < c.Price)
                    compMaxPrice = c;
                if (minPrice > c.Price)
                    compMinPrice = c;
                if (c.Availability < 30)
                    count++;
            }
            Console.WriteLine("Самый дорогой компьютер:");
            Console.WriteLine($"{compMaxPrice.Articul} {compMaxPrice.Name} {compMaxPrice.Price}тыс.руб");
            Console.WriteLine("Самый дешевый компьютер:");
            Console.WriteLine($"{compMinPrice.Articul} {compMinPrice.Name} {compMinPrice.Price}тыс.руб");
            Console.WriteLine(count > 0 ? "Есть компьютеры в количестве менее 30 шт." : "Нет компьютеров в количестве менее 30 шт.");
         
            Console.ReadKey();


        }
        static void Print(List<Computer> computers)
        {
            foreach (Computer c in computers)
            {
                Console.WriteLine($"{c.Articul} {c.Name} {c.Price} тыс.руб. В наличии — {c.Availability} шт.");
            }
            Console.WriteLine();
        }
    }
}
