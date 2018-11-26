namespace Learn.Models.Models
{
    public class Car
    {
        private decimal _discount = 0;

        public Car() { }

        public Car(decimal discount)
            => _discount = discount;

        public int Id { get; set; }

        public Company Manufacturer { get; set; }

        public string Model { get; set; }

        public int Price { get; set; }

        public decimal PriceWithDiscount
            => Price - (Price * _discount);
    }
}
