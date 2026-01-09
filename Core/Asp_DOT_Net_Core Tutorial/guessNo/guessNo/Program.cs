namespace guessNo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            int fixValue = 56;
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine("Please enter loop");
                int input1 = Convert.ToInt32(Console.ReadLine());
                if (input1 == fixValue)
                {
                    Console.WriteLine("Right");
                    break;
                }
                else
                {
                    Console.WriteLine("Please eneter agin");
                }
                
            }
        }
    }
}
