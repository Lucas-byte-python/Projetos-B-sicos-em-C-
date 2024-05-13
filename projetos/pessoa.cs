using System;

public class Pessoa
{
    public string Nome { get; set; }
    public int Idade { get; set; }

    public Pessoa(string nome, int idade)
    {
        Nome = nome;
        Idade = idade;
    }
}

public class Suite
{
    public int Número { get; set; }
    public double ValorDiária { get; set; }

    public Suite(int número, double valorDiária)
    {
        Número = número;
        ValorDiária = valorDiária;
    }
}

public class Reserva
{
    public Pessoa Hóspede { get; set; }
    public Suite SuíteReservada { get; set; }
    public int DiasReservados { get; set; }

    public Reserva(Pessoa hóspede, Suite suíte, int diasReservados)
    {
        Hóspede = hóspede;
        SuíteReservada = suíte;
        DiasReservados = diasReservados;
    }

    public double CalcularValorTotal()
    {
        double valorTotal = SuíteReservada.ValorDiária * DiasReservados;

        if (DiasReservados > 10)
        {
            valorTotal *= 0.9; // Aplica o desconto de 10%
        }

        return valorTotal;
    }
}
