using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_BettingGame
{
    internal class Bet
    {
        const int dieSides = 6;
        string name;
        double money;
        public int wins;
        int roll;
        //const int repeatGame = 1000;

        Random random = new Random();

        public void RollDice()
        {
            int die1 = 0;
            int die2 = 0;
            die1 = random.Next(6) + 1;
            die2 = random.Next(6) + 1;
            roll = die1 + die2;
        }

        public void StartUp()
        {
            var continueloop = true;

            do
            {
                try
                {

                    Console.WriteLine("Please input your name");
                    name = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(name))
                        throw new Exception("Error! Name not provided");

                    if (name.Any(char.IsDigit))
                        throw new Exception("Error! Please use a real name");

                    continueloop = false;

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            } while (continueloop);


            Console.WriteLine("Please state how much money you have");
            money = Convert.ToDouble(Console.ReadLine());


            Console.ReadLine();
            PlayCraps();
        }

        public void PlayCraps()
        {
            do
            {
                RollDice();
                int point = roll;

                Console.WriteLine("How much would you like to bet? ");
                double bet = Convert.ToDouble(Console.ReadLine());

                Console.ReadLine();

                Console.WriteLine("The shooter rolled: {0}", roll);

                if (roll == 7 || roll == 11)
                {
                    Console.WriteLine("You won!");
                    Console.ReadLine();
                    money += bet;
                    wins++;
                }
                else if (roll == 2 || roll == 3 || roll == 12)
                {
                    Console.WriteLine("You lost.");
                    Console.ReadLine();
                    money -= bet;
                }
                else
                {
                    Console.WriteLine("The point is: {0}", point);
                    roll = 0;
                    while (point != roll || roll != 7)
                    {
                        RollDice();
                        if (roll == point)
                        {
                            Console.WriteLine("You won!");
                            Console.ReadLine();
                            wins++;
                            money += bet;
                            break;
                        }

                        if (roll == 7)
                        {
                            Console.WriteLine("You lost");
                            Console.ReadLine();
                            money -= bet;
                            break;
                        }
                    }

                }

                Console.WriteLine("Money you have: {0}", money);
                Console.WriteLine("Do you want to bet again? (yes/no): ");

            } while (Console.ReadLine().ToLower() == "yes");

            Console.ReadLine();
            Console.Clear();

        }


    }
}

