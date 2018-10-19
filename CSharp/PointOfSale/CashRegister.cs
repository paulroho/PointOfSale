using System;

namespace PointOfSale
{
	public class CashRegister
	{
		private readonly IProductFinder _productFinder;

		public CashRegister(IProductFinder productFinder)
		{
			_productFinder = productFinder;
		}

		public event EventHandler<ProductEventArgs> ProductSuccessfullyScanned;

		public void Scan(string barcode)
		{
			var product = _productFinder.FindProduct(barcode);
			if (product != null)
			{
				ProductSuccessfullyScanned?.Invoke(this, new ProductEventArgs(product));
			}
		}
	}
}