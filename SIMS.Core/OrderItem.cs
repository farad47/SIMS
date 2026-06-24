using SIMS.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIMS.Core
{
    public class OrderItem : BaseEntity
    {
        public Guid OrderId { get; set; }
        public Order Order { get; private set; } = null!;
        public Guid ProductId { get; set; }
        public Product Product { get; private set; } = null!;
        public int Unit { get; private set; }
        public decimal Price { get; private set; }

        public CurrencyType CurrencyType => Product.Currency;

        public OrderItem(int unit, decimal price, Guid productId, Guid orderId)
        {
            SetUnit(unit);
            SetPrice(price);

            ProductId = productId;
            OrderId = orderId;
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
