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

        public static bool isPrimo(int x)
        {
            int f = x/2 + 1;
            for (int i=2;i<f;++i)
                if (x%i == 0) return false;
            return true;
        }

        public static void procPrimos(int id, int inicio, int fim)
        {
            DateTime hinicio, hfim;
            int k = 0;

            hinicio = DateTime.Now;
            for (int i = inicio; i < fim; ++i)
                if (isPrimo(i)) ++k;
            hfim = DateTime.Now;

            Console.WriteLine("Paralelo " + id + "encontrou " + k + " numeros primos.");
            Console.WriteLine("Começou em.: " + hinicio.ToString("MM/dd/yyyy hh:mm:ss.fff tt"));
            Console.WriteLine("Terminou em: " + hfim.ToString("MM/dd/yyyy hh:mm:ss.fff tt"));
            Console.WriteLine("Tempo = " + (hfim - hinicio));
        }


        static void Main(string[] args)
        {
            DateTime inicio, fim;

            inicio = DateTime.Now;
            Parallel.Invoke(
               new Action(() => procPrimos(1, 1, 100000)),
               new Action(() => procPrimos(2, 100001, 200000)),
               new Action(() => procPrimos(3, 200001, 300000))
           );
            fim = DateTime.Now;
            Console.WriteLine("Tudo encerrado após " + (fim - inicio) + " segundos.");
            Console.ReadKey();
        }

    }
}
