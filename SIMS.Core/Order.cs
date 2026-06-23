using SIMS.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIMS.Core
{
    public class Order : TechnicalField
    {
        public decimal TotalAmount { get; private set; }
        public DateTime PurchaseDate { get; init; }
        public DateTime? DeliveryDate { get; private set; }
        public OrderStatusType OrderStatus { get; private set; }
        public PaymentStatusType PaymentStatus { get; private set; }
        public Address Address { get; set; }

        public List<OrderItem> OrderItems { get; set; }

        public Order(DateTime? deliveryDate, Address address, List<OrderItem> orderItems)
        {
            PurchaseDate = DateTime.Now;
            DeliveryDate = deliveryDate;
            OrderStatus = OrderStatusType.Pending;
            PaymentStatus = PaymentStatusType.Pending;
            Address = address;
            OrderItems = orderItems;
        }

        public void CulateTotalAmount() =>
            TotalAmount = OrderItems.Sum(x => x.Unit * x.Price);

        public void SetOrderStatus(OrderStatusType orderStatus)
        {
            OrderStatus = orderStatus;
        }

    }
}
