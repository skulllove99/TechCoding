using System;

namespace TechCoding
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BusinessLogic calculateBusinessLogic = new BusinessLogic();
            calculateBusinessLogic.Calculation();
            Console.WriteLine("succeed!");
        }
    }
}
