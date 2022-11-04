using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Primos
{
    class Program
    {
        public static void processo1()
        {
            Console.WriteLine("Iniciando Processo1");
            Thread.Sleep(5000);
            Console.WriteLine("Finalizando Processo1");
        }

        public static void processo2()
        {
            Console.WriteLine("Iniciando Processo1");
            Thread.Sleep(4000);
            Console.WriteLine("Finalizando Processo1");
        }

        public static void processo3()
        {
            Console.WriteLine("Iniciando Processo1");
            Thread.Sleep(3000);
            Console.WriteLine("Finalizando Processo1");
        }

        public static void processo4()
        {
            Console.WriteLine("Iniciando Processo1");
            Thread.Sleep(3000);
            Console.WriteLine("Finalizando Processo1");
        }

        public static void processo5()
        {
            Console.WriteLine("Iniciando Processo1");
            Thread.Sleep(5000);
            Console.WriteLine("Finalizando Processo1");
        }

        public static void processo6()
        {
            Console.WriteLine("Iniciando Processo1");
            Thread.Sleep(1000);
            Console.WriteLine("Finalizando Processo1");
        }

        static void Main(string[] args)
        {
            DateTime inicio, fim;

            inicio = DateTime.Now;
            Parallel.Invoke(
               new Action(() => { processo1(); processo4();}),
               new Action(() => { processo2(); processo5();}),
               new Action(() => processo3())
           );
            processo6();
            fim = DateTime.Now;
            Console.WriteLine("Tudo encerrado após " + (fim - inicio) + " segundos.");
            Console.ReadKey();
        }

    }
}
