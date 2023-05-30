using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Override
{
    internal class Goods
    {
        private string name;
        private DateTime date;
        private Money price;
        private int quantity;
        private int invoiceNumber;

        public Goods(string name, DateTime date, Money price, int quantity, int invoiceNumber)
        {
            this.name = name;
            this.date = date;
            this.price = price;
            this.quantity = quantity;
            this.invoiceNumber = invoiceNumber;
        }

        public void ChangePrice(Money newPrice)
        {
            price = newPrice;
        }

        public void ChangeQuantity(int newQuantity)
        {
            quantity = newQuantity;
        }

        public Money GetTotalCost()
        {
            return price * quantity;
        }

        public void DiscountExpiredGoods()
        {
            TimeSpan daysExpired = DateTime.Today.Subtract(date);

            if (daysExpired.TotalDays > 0)
            {
                double discountPercentage = daysExpired.TotalDays * 0.01;

                Money discountedPrice = price * (1 - discountPercentage);

                ChangePrice(discountedPrice);
            }
        }

        public override string ToString()
        {
            return GetTotalCost().ToString();
        }
    }
}
