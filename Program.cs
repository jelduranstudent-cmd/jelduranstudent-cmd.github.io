using System;
using System.Collections.Generic;

namespace OrdersInheritanceExercise
{
    // Part 1: Base Class
    public class Order
    {
        protected string orderId;
        protected string customerName;
        protected double subtotal;

        // Constructor
        public Order(string orderId, string customerName, double subtotal)
        {
            this.orderId = orderId;
            this.customerName = customerName;
            this.subtotal = subtotal;
        }

        // Virtual method
        public virtual double CalculateShippingFee()
        {
            return 50;
        }

        // Virtual method
        public virtual void DisplayOrderInfo()
        {
            double shippingFee = CalculateShippingFee();
            double total = subtotal + shippingFee;

            Console.WriteLine($"Order ID: {orderId}");
            Console.WriteLine($"Customer: {customerName}");
            Console.WriteLine($"Subtotal: ₱{subtotal:N2}");
            Console.WriteLine($"Shipping Fee: ₱{shippingFee:N2}");
            Console.WriteLine($"Total: ₱{total:N2}");
        }
    }


    // Part 2: StandardOrder
    public class StandardOrder : Order
    {
        public StandardOrder(string orderId, string customerName, double subtotal)
            : base(orderId, customerName, subtotal)
        {
        }

        public override double CalculateShippingFee()
        {
            return 50;
        }
    }


    // Part 3: ExpressOrder
    public class ExpressOrder : Order
    {
        public ExpressOrder(string orderId, string customerName, double subtotal)
            : base(orderId, customerName, subtotal)
        {
        }

        public override double CalculateShippingFee()
        {
            return base.CalculateShippingFee() + 100;
        }
    }


    // Part 4: PickupOrder
    public class PickupOrder : Order
    {
        public PickupOrder(string orderId, string customerName, double subtotal)
            : base(orderId, customerName, subtotal)
        {
        }

        public override double CalculateShippingFee()
        {
            return 0;
        }

        public override void DisplayOrderInfo()
        {
            base.DisplayOrderInfo();
            Console.WriteLine("Note: This order will be picked up in-store.");
        }
    }


    // Bonus: BulkOrder
    public class BulkOrder : Order
    {
        public BulkOrder(string orderId, string customerName, double subtotal)
            : base(orderId, customerName, subtotal)
        {
        }

        public override double CalculateShippingFee()
        {
            if (subtotal >= 5000)
            {
                return 0;
            }
            else
            {
                return 50;
            }
        }
    }


    // Main Program
    class Program
    {
        static void Main(string[] args)
        {
            List<Order> orders = new List<Order>();

            // Add orders
            orders.Add(new StandardOrder(
                "ORD-001",
                "Ana Reyes",
                1200
            ));

            orders.Add(new ExpressOrder(
                "ORD-002",
                "Carlo Mendoza",
                850
            ));

            orders.Add(new PickupOrder(
                "ORD-003",
                "Liza Santos",
                500
            ));

            // Bonus order
            orders.Add(new BulkOrder(
                "ORD-004",
                "Mark Cruz",
                5500
            ));

            // Display all orders
            foreach (Order o in orders)
            {
                o.DisplayOrderInfo();
                Console.WriteLine("--------------------------");
            }
        }
    }
}