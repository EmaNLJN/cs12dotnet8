Write("Enter a number: ");
string number = ReadLine()!;

double a = double.Parse(number);
double b = 2.5;
double answer = Add(a, b);

// usar hit count en el breakpoint es util para loops al parecer
WriteLine($"{a} + {b} = {answer}");
WriteLine("Press Enter to end the app.");
ReadLine();

double Add(double a, double b)
{
  return a + b;
}