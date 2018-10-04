using System;

namespace PointOfSale
{
	public class ProductEventArgs : EventArgs
	{
		public ProductEventArgs(decimal price)
		{
			Price = price;
		}

		public decimal Price { get; }
	}
}