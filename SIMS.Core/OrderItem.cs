using SIMS.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIMS.Core
{
    public class OrderItem : TechnicalField
    {
        public Order OrderId { get; private set; }
        public Product ProductId { get; private set; }
        public int Unit { get; private set; }
        public decimal Price { get; private set; }

        public CurrencyType CurrencyType => ProductId.Currency;

        public OrderItem(Order order, Product product, int unit, decimal price)
        {
            SetUnit(unit);
            SetPrice(price);

            OrderId = order;
            ProductId = product;

            Price = price;
        }

        public void SetUnit(int unit)
        {
            if (unit <= 0)
                throw new ArgumentOutOfRangeException(nameof(unit), "Unit cannot be less than 0.");

            Unit = unit;
        }

        public void SetPrice(decimal price)
        {
            if (price <= 0)
                throw new ArgumentOutOfRangeException(nameof(price), "Price cannot be less than 0.");

            Price = price;
        }
    }
}
