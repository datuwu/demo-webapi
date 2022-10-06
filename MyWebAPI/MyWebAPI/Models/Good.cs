using System;

namespace MyWebAPI.Models
{
    public class GoodVM
    {
        public string Name { get; set; }
        public double UnitPrice { get; set; }

    }
    public class Good : GoodVM
    {
        public Guid Id { get; set; }
    }
}
