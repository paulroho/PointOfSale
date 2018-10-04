namespace PointOfSale
{
	public class Product
	{
		public Product(string barcode, decimal price)
		{
			Barcode = barcode;
			Price = price;
		}

		public string Barcode { get; }
		public decimal Price { get; }
	}
}