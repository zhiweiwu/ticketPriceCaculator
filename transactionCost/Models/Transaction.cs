using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace transactionCost.Model
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public List<Customer> Customers { get; set; }
    }
}
