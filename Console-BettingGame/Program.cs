namespace Console_BettingGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("Hello, Welcome to the C# Console Money Betting Game");
            Console.WriteLine("----------------------------------------------------------");

            Console.ReadLine();

            Bet NewGame = new Bet();
            NewGame.StartUp();
            Console.WriteLine("Amount of times won: {0}", NewGame.wins.ToString());
            Console.WriteLine("Thank you for playing!");

            Console.ReadKey();
        }
    }
}