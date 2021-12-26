using ACT.Core.Extensions;

namespace MyApp // Note: actual namespace depends on the project name.
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Development Beta".ToBase64());
            Console.ReadKey();
        }
    }
}