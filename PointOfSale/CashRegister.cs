using System;

namespace PointOfSale
{
	public class CashRegister
	{
		public void RegisterProduct(string barcode, decimal price)
		{
		}

		public event Action<decimal> ProductSuccessfullyScanned;

		public void Scan(string barcode)
		{
		}
	}
}