using System;
using System.Collections;
using System.Collections.Generic;

namespace MyWebAPI.Data
{
    public class Order
    {
        public enum OrderStatusCode
        {
            New = 0, Payment = 1, Complete = 2, Cancel = -1
        }
        public Guid OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public OrderStatusCode OrderStatus { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public Order()
        {
            OrderDetails = new List<OrderDetail>();
        }
    }
}
