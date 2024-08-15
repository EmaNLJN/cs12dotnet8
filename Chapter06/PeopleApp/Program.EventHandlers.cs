using Packt.Shared;

partial class Program
{
  private static void Harry_Shout(object? sender, EventArgs e)
  {
    if (sender is null) return;

    // is es pattern maching, por lo tanto, si sender es realmente de tipo person, entonces
    // p no solo va a ser valida en el bloque del if, si no, de todo el codigo que este por debajo.
    if (sender is not Person p) return;
    // tener cuidado en caso que se use else, porque p puede seguir valiendo por debajo del mismo
    // asi que se deberia garantizarse que el flujo de retorno del metodo sea el correcto.

    WriteLine($"{p.Name} is this angry: {p.AngerLevel}.");
  }

  // another method to handle the event recieved by the harry object
  private static void Harry_Shout_2(object? sender, EventArgs e)
  {
    WriteLine("Stop it!");
  }
}
