using System;
using System.Collections.Generic;
using System.Linq;

namespace ATMMachine
{
    class Program
    {
        static void Main(string[] args)
        {

            //Get our data, Creating the cards.
            List<CardModel> cards = new List<CardModel>()
            {
                new CardModel(1, 12345, 1111, 250.00, "Lloyds"),
                new CardModel(2, 55555, 2222, 100.50, "HSBC"),
                new CardModel(3, 99999, 3333, 1000, "Bank Of England"),
            };

            //Create the list of options used on line 55
            IDictionary<int, string> ATMoptions = new Dictionary<int, string>
            {
                {1, "Cancel" },
                {2, "View Balance" },
                {3, "Withdraw Wibbly Dollars" },
            };
            
            //This ensures the app is always running
            while (true)
            {
                bool cardHasBeenEntered = false;

                Console.WriteLine("Free Cash Withdrawal, Please Enter a Card...");

                //This is a discard, once the try prase returns true it will discard the returned value
                _ = int.TryParse(Console.ReadLine(), out int enteredCardId);


                //Find the card with the entered cardId from the above ReadLine()
                CardModel chosenCard = cards.Find(c => c.CardId == enteredCardId);
                

                //If card is not equal to null, meaning it has found the card entered, go to the next step
                if (chosenCard != null)
                {
                    //set the card entered to true and go to next step
                    cardHasBeenEntered = true;

                    while (cardHasBeenEntered)
                    {
                        //Tell the user to chose from a list of options
                        Console.WriteLine("Choose from a list of options....");
                        
                        //loop through the options declared on line 21, and print
                        foreach (KeyValuePair<int, string> option in ATMoptions)
                        {
                            Console.WriteLine($"{option.Key}: - {option.Value}");
                        }

                        bool validChosenAction = int.TryParse(Console.ReadLine(), out int chosenAction);

                        // If the chosen value is value go into the specifics of the options
                        if (validChosenAction)
                        {
                            switch (chosenAction)
                            {
                                case 1:
                                    //returns the user to the welcome page and clears the console
                                    cardHasBeenEntered = false;
                                    Console.Clear();
                                    break;

                                case 2:
                                    //Displays the value of the current card/account
                                    Console.WriteLine($"W: {chosenCard.Balance} Wibbly Dollars.");
                                    break;

                                case 3:
                                    //ask the user to enter an amount to withdraw
                                    Console.WriteLine($"Select an amount to withdraw...");
                                    bool validWithdrawal = int.TryParse(Console.ReadLine(), out int ammount);

                                    //if its valid go to method
                                    if (validWithdrawal)
                                    {
                                        WithdrawWibblyDollars(ammount, chosenCard);
                                    }

                                    break;

                                default:
                                    break;
                            }
                        }
                    }
                }
                    
            }

            static void WithdrawWibblyDollars(int amount, CardModel chosenCard)
            {
                //sets the message to not enough funds
                string message = "Not enough funds";

                //if the condition is true change the message and subtract the amount from the balance
                if (amount <= chosenCard.Balance)
                {
                    message = $"You withdrew {amount} Wibbly Dollars";
                    chosenCard.Balance -= amount;
                }

                Console.WriteLine(message);
                
            }
        }
    }
}
