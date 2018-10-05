using System;

namespace PointOfSale
{
	public class CashRegister
	{
		private readonly Inventory _inventory = new Inventory();

		public void RegisterProduct(Product product)
		{
			_inventory.RegisterProduct(product);
		}

		public event EventHandler<ProductEventArgs> ProductSuccessfullyScanned;

		public void Scan(string barcode)
		{
			var product = _inventory.FindProduct(barcode);
			if (product != null)
			{
				ProductSuccessfullyScanned?.Invoke(this, new ProductEventArgs(product));
			}
		}
	}
}