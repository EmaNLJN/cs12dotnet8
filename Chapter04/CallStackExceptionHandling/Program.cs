using CallStackExceptionHandlingLib;
using static System.Console;

WriteLine("In Main");
Alpha();

void Alpha()
{
  WriteLine("In Alpha");
  Beta();
}

void Beta()
{
  WriteLine("In Beta");
  try
  {
    Processor.Gamma();
  }
  catch (Exception ex)
  {
    WriteLine($"Caught this: {ex.Message}");
    // rethrow la excepcion de catch y retiene la informacion original del call stack.
    throw;
  }
}
