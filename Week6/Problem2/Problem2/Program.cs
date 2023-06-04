using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem2
{
    class Program
    {
        static void Main(string[] args)
        {
            int opt;
            do
            {
                Console.WriteLine("1. Start");
                Console.WriteLine("2. Exit");
                Console.Write("Enter Option: ");
                opt = int.Parse(Console.ReadLine());
                Console.Clear();

                if (opt == 1)
                {
                    bool game = true;
                    int score = 0;
                    Deck Cards = new Deck();
                    Cards.Shuffle();
                    Card card1 = Cards.GetCard();

                    while (game)
                    {
                        int remain = Cards.CardsLeft();
                        Card card2 = Cards.GetCard();
                        Console.WriteLine("************************");
                        Console.WriteLine("* {0} *", card1.CardName());
                        Console.WriteLine("************************");
                        Console.WriteLine();
                        Console.WriteLine("Remaining Card: {0}", remain);
                        Console.WriteLine();
                        Console.WriteLine("Enter 1 if Next Card is Greater");
                        Console.WriteLine("Enter 2 if Next Card is Smaller");
                        Console.Write("Enter Option: ");
                        int cardOption = int.Parse(Console.ReadLine());

                        if (cardOption == 1)
                        {
                            if (card2.GetValue() >= card1.GetValue())
                            {
                                Console.WriteLine("Great!! Press Any For Back");
                                Console.WriteLine("Card is: {0}", card2.CardName());
                                Console.WriteLine("Score is: {0}", score);
                                score++;
                                card1 = card2;
                                Console.ReadKey();
                                Console.Clear();
                            }
                            else
                            {
                                Console.WriteLine("Sorry You Lose!! Press Any For Back");
                                Console.WriteLine("Card is: {0}", card2.CardName());
                                Console.WriteLine("Score is: {0}", score);
                                Console.ReadKey();
                                Console.Clear();
                            }
                        }

                        if (cardOption == 2)
                        {
                            if (card2.GetValue() < card1.GetValue())
                            {
                                Console.WriteLine("Great!! Press Any For Back");
                                Console.WriteLine("Card is: {0}", card2.CardName());
                                Console.WriteLine("Score is: {0}", score);
                                score++;
                                card1 = card2;
                                Console.ReadKey();
                                Console.Clear();
                            }
                            else
                            {
                                Console.WriteLine("Sorry You Lose!! Press Any For Back");
                                Console.WriteLine("Card is: {0}", card2.CardName());
                                Console.WriteLine("Score is: {0}", score);
                                Console.ReadKey();
                                Console.Clear();
                            }
                        }
                        if (Cards.CardsLeft() == 0 && Cards.GetCard() == null)
                        {
                            game = false;
                            Console.WriteLine("Congrate You have Maximum Score ...");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                    }
                }
            }
            while (opt != 2);
        }
    }
}
