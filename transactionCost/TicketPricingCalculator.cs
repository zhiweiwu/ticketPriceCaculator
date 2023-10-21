using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using transactionCost.Model;

namespace transactionCost
{
    public class TicketPricingCalculator
    {
        public static double CalculateTotalCost(List<Customer> customers)
        {
            double totalCost = 0;
            int childCount = 0;

            foreach (var customer in customers)
            {
                if (customer.Age >= 65)
                {
                    totalCost += 0.7 * 25;
                }
                else if (customer.Age >= 18)
                {
                    totalCost += 25;
                }
                else if (customer.Age >= 11)
                {
                    totalCost += 12;
                }
                else if (customer.Age < 0) {
                    totalCost = -1;
                    Console.WriteLine("Error: Age cannot be less than 0 for customer: " + customer.Name);
                    break;

                }
                else
                {
                    totalCost += 5;
                    childCount++;
                    if (childCount >= 3)
                    {
                        totalCost -= childCount * 5 * 0.25;
                    }
                }
            }

            return totalCost;
        }
    }
}
