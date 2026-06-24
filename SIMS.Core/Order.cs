using SIMS.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIMS.Core
{
    public class Order : BaseEntity
    {
        public decimal TotalAmount { get; private set; }
        public DateTime PurchaseDate { get; init; } = DateTime.Now;
        public DateTime? DeliveryDate { get; private set; }
        public OrderStatusType OrderStatus { get; private set; }
        public PaymentStatusType PaymentStatus { get; private set; }
        public Guid AddressId { get; set; }
        public Address Address { get; private set; } = null!;

        public List<OrderItem> OrderItems { get; set; } = new();

        public Order(DateTime? deliveryDate, Guid addressId)
        {
            PurchaseDate = DateTime.Now;
            DeliveryDate = deliveryDate;
            OrderStatus = OrderStatusType.Pending;
            PaymentStatus = PaymentStatusType.Pending;
            AddressId = addressId;
        }

        public void CulateTotalAmount() =>
            TotalAmount = OrderItems.Sum(x => x.Unit * x.Price);

        public void SetOrderStatus(OrderStatusType orderStatus)
        {
            OrderStatus = orderStatus;
        }

    }
}
