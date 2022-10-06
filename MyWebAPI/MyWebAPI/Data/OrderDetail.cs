using System;

namespace MyWebAPI.Data
{
    public class OrderDetail
    {
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public int Amount { get; set; }
        public double UnitPrice { get; set; }
        public decimal SaleRate { get; set; }

        public Order Order { get; set; }
        public Good Good { get; set; }
    }
}
