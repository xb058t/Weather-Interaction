using System;
namespace a2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                Console.Write("Enter filename:");
                string filename = Console.ReadLine()!;
                Earth e = new(filename);
                e.Run();
            }
            catch (FileError)
            {
                Console.WriteLine("Cannot open the file");
            }
            catch (FormatError)
            {
                Console.WriteLine("Wrong format was used.");
            }
            catch (AreaError)
            {
                Console.WriteLine("Unknown area type was given");
            }
            catch (Exception)
            {
                Console.WriteLine("Unhandled");
            }
        }
    }
}
