using System;

namespace PointOfSale
{
	public class ProductEventArgs : EventArgs
	{
		public ProductEventArgs(Product product)
		{
			Product = product;
		}

		public Product Product { get; }
	}
}