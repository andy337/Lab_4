using System;
using System.IO;
using System.Linq;

namespace Лаб_4
{
    class Program
    {
        static void Main(string[] args)
        {
            int rez = 0;
            int count = 0;
            using (StreamWriter sw = new StreamWriter(@"C:\Users\Admin\source\repos\Лаб_4\no_file.txt", false, System.Text.Encoding.Default)) { }
            using (StreamWriter sw = new StreamWriter(@"C:\Users\Admin\source\repos\Лаб_4\overflow.txt", false, System.Text.Encoding.Default)) { }
            using (StreamWriter sw = new StreamWriter(@"C:\Users\Admin\source\repos\Лаб_4\bad_data.txt", false, System.Text.Encoding.Default)) { }

            for (int i = 10; i < 30; i++)
            {
                string index = i.ToString();
                try
                {
                    string filePath = @"C:\Users\Admin\source\repos\Лаб_4\" + index + ".txt";

                    string[] lines = File.ReadAllLines(filePath);

                    int first = int.Parse(lines[0]);
                    int second = int.Parse(lines[1]);
                    checked
                    {
                        rez = first * second;
                        count++;
                    }
                    Console.WriteLine(rez);

                }
                catch (FileNotFoundException ex)
                {
                    Console.WriteLine(ex.Message);
                    using (StreamWriter sw = new StreamWriter(@"C:\Users\Admin\source\repos\Лаб_4\no_file.txt", true, System.Text.Encoding.Default))
                    {
                        sw.WriteLine(index + "txt");
                    }
                }
                catch (OverflowException ex)
                {
                    Console.WriteLine(ex.Message);
                    using (StreamWriter sw = new StreamWriter(@"C:\Users\Admin\source\repos\Лаб_4\overflow.txt", true, System.Text.Encoding.Default))
                    {
                        sw.WriteLine(index + "txt");
                    }
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                    using (StreamWriter sw = new StreamWriter(@"C:\Users\Admin\source\repos\Лаб_4\bad_data.txt", true, System.Text.Encoding.Default))
                    {
                        sw.WriteLine(index + "txt");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
            Console.WriteLine("Результат: " + rez / count);
        }
    }
}
