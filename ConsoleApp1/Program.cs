using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Input Zero or a non numeric value: ");
                int a = Int32.Parse(Console.ReadLine());
                int b = 1 / a;
            }
            catch (DivideByZeroException e)
            {
                e.LogToTXT();
                e.LogToCVS();
            }
            catch (Exception e)
            {
                e.LogToTXT();
                e.LogToCVS();
            }
        }
    }
}
