using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using transactionCost.Model;


namespace transactionCost
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string json = File.ReadAllText("../json/transactions.json");
            List<Transaction> transactions = JsonConvert.DeserializeObject<List<Transaction>>(json);

            foreach (var transaction in transactions)
            {
                int transactionId = transaction.TransactionId;
                double totalCost = TicketPricingCalculator.CalculateTotalCost(transaction.Customers);

                Console.WriteLine($"## Transaction {transactionId} ##");
                Console.WriteLine($"Projected total cost: ${totalCost:F2}\n");
            }
        }


    }
}
