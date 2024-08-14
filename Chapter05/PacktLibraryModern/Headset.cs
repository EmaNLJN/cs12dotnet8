namespace Packt.Shared;

// esto en c#12 se conoce como primary constractor
public class Headset(string manufacturer, string productName)
{
  public string Manufacturer { get; set; } = manufacturer;
  public string ProductName { get; set; } = productName;

  public Headset(): this("Microsoft", "HoloLens") {}
}