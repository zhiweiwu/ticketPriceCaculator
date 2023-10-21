using System;
using System.Collections.Generic;
using Xunit;
using transactionCost.Model;
using transactionCost;
using Xunit.Abstractions;
using Microsoft.VisualStudio.TestPlatform.Utilities;


namespace TransactionCostTests
{
    public class TicketPricingCalculatorTests
    {
        [Fact]
        public void TestCalculateTotalCost_SingleCustomer()
        {
            // Arrange
            List<Customer> customers = new List<Customer>
            {
                new Customer { Age = 25 }
            };

            // Act
            double totalCost = TicketPricingCalculator.CalculateTotalCost(customers);

            // Assert
            Assert.Equal(25.0, totalCost); 
        }

        [Fact]
        public void TestCalculateTotalCost_MultipleCustomers()
        {
            // Arrange
            List<Customer> customers = new List<Customer>
            {
                new Customer { Age = 70 },
                new Customer { Age = 36 },
                new Customer { Age = 3 },
                new Customer { Age = 8 },
                new Customer { Age = 9 },
                new Customer { Age = 17 },
            };

            // Act
            double totalCost = TicketPricingCalculator.CalculateTotalCost(customers);

            // Assert
            Assert.Equal(65.75, totalCost); 
        }

        [Fact]
        public void TestCalculateTotalCost_DiscountForChildren()
        {
            // Arrange
            List<Customer> customers = new List<Customer>
            {
                
                new Customer { Age = 3 },
                new Customer { Age = 8 },
                new Customer { Age = 9 },
                
            };

            // Act
            double totalCost = TicketPricingCalculator.CalculateTotalCost(customers);

            // Assert
            Assert.Equal(11.25, totalCost); 
        }

        [Fact]
        public void TestCalculateTotalCost_DiscountForSenior()
        {
            // Arrange
            List<Customer> customers = new List<Customer>
            {
                new Customer { Age = 70 },
            };

            // Act
            double totalCost = TicketPricingCalculator.CalculateTotalCost(customers);

            // Assert
            Assert.Equal(17.50, totalCost);
        }
        [Fact]
        public void TestCalculateTotalCost_DiscountForTeen()
        {
            // Arrange
            List<Customer> customers = new List<Customer>
            {
                new Customer { Age = 17 },
            };

            // Act
            double totalCost = TicketPricingCalculator.CalculateTotalCost(customers);

            // Assert
            Assert.Equal(12, totalCost);
        }


        [Fact]
        public void TestCalculateTotalCost_LessThanZero()
        {
            // Arrange
            List<Customer> customers = new List<Customer>
        {
            new Customer { Name = "John", Age = -5 },
        };

        // Act
        double totalCost = TicketPricingCalculator.CalculateTotalCost(customers);

        // Assert
        Assert.Equal(-1, totalCost);

        }


    }
}
