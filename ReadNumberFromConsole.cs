namespace ReadNumber
{
  class Program
  {
    public static void Main(string[] args)
    {
      static int ReadNumber()
        {
            int value;

            try
            {
                value = int.Parse(Console.ReadLine());
            }
            catch (OverflowException)
            {
                throw new OverflowException();
            }
            catch (FormatException)
            {
                throw new FormatException();
            }

            return value;
        }
    }
  }
}
