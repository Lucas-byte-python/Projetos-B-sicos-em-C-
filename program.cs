using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Estacionamento estacionamento = new Estacionamento();

        while (true)
        {
            Console.WriteLine("1 - Adicionar veículo");
            Console.WriteLine("2 - Remover veículo");
            Console.WriteLine("3 - Listar veículos");
            Console.WriteLine("4 - Sair");
            Console.Write("Escolha uma opção: ");
            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    Console.Write("Digite a placa do veículo: ");
                    string placa = Console.ReadLine();
                    estacionamento.AdicionarVeiculo(placa);
                    break;
                case "2":
                    Console.Write("Digite a placa do veículo a ser removido: ");
                    string placaRemover = Console.ReadLine();
                    estacionamento.RemoverVeiculo(placaRemover);
                    break;
                case "3":
                    estacionamento.ListarVeiculos();
                    break;
                case "4":
                    Console.WriteLine("Saindo...");
                    return;
                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }
        }
    }
}

class Estacionamento
{
    private Dictionary<string, DateTime> veiculosEstacionados;

    public Estacionamento()
    {
        veiculosEstacionados = new Dictionary<string, DateTime>();
    }

    public void AdicionarVeiculo(string placa)
    {
        veiculosEstacionados[placa] = DateTime.Now;
        Console.WriteLine("Veículo adicionado com sucesso!");
    }

    public void RemoverVeiculo(string placa)
    {
        if (veiculosEstacionados.ContainsKey(placa))
        {
            DateTime entrada = veiculosEstacionados[placa];
            DateTime saida = DateTime.Now;
            TimeSpan tempoEstacionado = saida - entrada;
            double valorCobrado = CalcularValor(tempoEstacionado);
            Console.WriteLine($"Valor cobrado: R${valorCobrado:F2}");
            veiculosEstacionados.Remove(placa);
        }
        else
        {
            Console.WriteLine("Veículo não encontrado!");
        }
    }

    public void ListarVeiculos()
    {
        Console.WriteLine("Veículos estacionados:");
        foreach (var veiculo in veiculosEstacionados)
        {
            Console.WriteLine($"{veiculo.Key} - Entrada: {veiculo.Value}");
        }
    }

    private double CalcularValor(TimeSpan tempoEstacionado)
    {
        // Exemplo de cálculo básico: R$2 por hora estacionada
        double valorPorHora = 2.0;
        double valorCobrado = valorPorHora * tempoEstacionado.TotalHours;
        return valorCobrado;
    }
}
