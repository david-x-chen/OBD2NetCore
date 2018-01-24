using System;

namespace Obd2NetCore.Attributes
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
    public class OrderAttribute : Attribute
    {
        public int Order { get; private set; }

        public OrderAttribute(int order)
        {
            Order = order;
        }
    }
}
