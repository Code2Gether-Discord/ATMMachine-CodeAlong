using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMMachine
{
    public class CardModel
    {
        public int CardId { get; set; }
        public string BankName { get; set; }
        public int AccountNumber { get; set; }
        public int PIN { get; set; }
        public double Balance { get; set; }

        public CardModel(int cardId, int accountNumber, int pin, double balance, string bankName)
        {
            CardId = cardId;
            AccountNumber = accountNumber;
            PIN = pin;
            Balance = balance;
            BankName = bankName;
        }
    }
}
