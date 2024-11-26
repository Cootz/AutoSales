namespace AutoSales.Model
{

    public class Sale
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public uint Price { get; set; }

        public Car Car { get; set; } = default!;
    }
}