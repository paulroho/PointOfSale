using System;

namespace PointOfSale
{
	public class CashRegister
	{
		private readonly Inventory _inventory;

		public CashRegister(Inventory inventory)
		{
			_inventory = inventory;
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