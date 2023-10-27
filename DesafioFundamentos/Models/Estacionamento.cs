using System.Globalization;
using System.Text.RegularExpressions;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal PrecoInicial { get; set; }
        private decimal PrecoPorHora { get; set; }
        private List<string> Veiculos  { get; set; } = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            PrecoInicial = precoInicial;
            PrecoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine();

            if (Helper.ValidarPlaca(placa))
            {
                placa = Helper.FormatarPlaca(placa);

                if (Veiculos.Any(x => x == placa))
                {
                    Console.WriteLine("Este veículo já encontra-se estacionado.");
                }
                else
                {
                    Veiculos.Add(placa);
                    Console.WriteLine($"Veículo de placa {placa} estacionado com sucesso.");
                }
            }
            else
            {
                Console.WriteLine("Formato da plava inválido.");
            }
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");
            string placa = Console.ReadLine();

            if (Helper.ValidarPlaca(placa))
            {
                placa = Helper.FormatarPlaca(placa);

                // Verifica se o veículo existe
                if (Veiculos.Any(x => x == placa))
                {
                    Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                    int horas = Convert.ToInt32(Console.ReadLine());

                    decimal valorTotal = PrecoInicial + PrecoPorHora * horas;

                    Veiculos.Remove(placa);

                    Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal.ToString("N2", new CultureInfo("pt-BR"))}");
                }
                else
                {
                    Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
                }
            }
            else
            {
                Console.WriteLine("Formato da plava inválido.");
            }  
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (Veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                
                foreach (var item in Veiculos)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
