using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Globalization;
using System.Xml.Serialization;

namespace LP4_06_11_2020_RelogioPonto
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream arquivo = new FileStream("Abril 2017.txt", FileMode.Open, FileAccess.Read);
            StreamReader ponteiro = new StreamReader(arquivo);

            List<BatidaDePonto> batidasDePonto = new List<BatidaDePonto>();

            while (ponteiro.Peek() >= 0)
            {
                string ponto = ponteiro.ReadLine();
                batidasDePonto.Add(new BatidaDePonto()
                {
                    cd_Funcionario = int.Parse(ponto.Substring(0, 15)),
                    dt_Ponto = DateTime.ParseExact(ponto.Substring(15, 6), "ddMMyy", CultureInfo.InvariantCulture).ToShortDateString(),
                    hr_Ponto = DateTime.ParseExact(ponto.Substring(21, 4), "HHmm", CultureInfo.InvariantCulture).ToShortTimeString(),
                    ds_Adendo = ponto.Substring(25, 8)
                });
            }

            Console.WriteLine("Listando as batidas de ponto registradas...");

            foreach (BatidaDePonto batida in batidasDePonto)
            {
                Console.WriteLine("");
                Console.WriteLine("cd_Funcionario: " + batida.cd_Funcionario);
                Console.WriteLine("dt_Ponto:       " + batida.dt_Ponto);
                Console.WriteLine("hr_Ponto:       " + batida.hr_Ponto);
                Console.WriteLine("ds_Adendo:      " + batida.ds_Adendo);
            }

            Console.WriteLine("");
            Console.WriteLine("Convertendo para arquivo XML...");

            XmlSerializer serializador = new XmlSerializer(batidasDePonto.GetType());
            TextWriter saida = new StreamWriter("BatidasDePonto_abril2017.xml");
            serializador.Serialize(saida, batidasDePonto);

            Console.WriteLine("O arquivo BatidasDePonto_abril2017.xml foi gerado.");
            Console.WriteLine("Aperte uma tecla qualquer para encerrar o programa.");

            Console.ReadKey();
        }
    }
}
