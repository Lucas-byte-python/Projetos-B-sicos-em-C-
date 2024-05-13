public class Program
{
    public static void Main()
    {
        Pessoa hóspede = new Pessoa("João", 30);
        Suíte suíte = new Suíte(101, 150.0);
        Reserva reserva = new Reserva(hóspede, suíte, 15);

        double valorTotal = reserva.CalcularValorTotal();

        Console.WriteLine($"Valor total da reserva: R$ {valorTotal}");
    }
}
