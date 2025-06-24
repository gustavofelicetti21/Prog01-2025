namespace Modelo
{
    public class Order
    {
        public int Id { get; set; }
        public Customer? Customer { get; set; }
        public DateTime OrderDate { get; set; }
        public Address? ShippingAddress { get; set; }
        public List<OrderItem>? OrderItems { get; set; }
        public Order()
        {
            OrderDate = DateTime.Now;
            OrderItems = new List<OrderItem>();
        }

        public Order(int orderId) : this()
        {
            this.Id = orderId;

        }

        public Order(int orderId, Address address) : this(orderId)
        {
            this.ShippingAddress = address;
        }

        public bool Validate()
        {
            return true;
        }

        public Order Retrive()
        {
            return new Order();
        }

        public void Save(Order order)
        {

        }
    }
}
