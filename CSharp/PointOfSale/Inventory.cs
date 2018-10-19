namespace PointOfSale
{
	public class Inventory : IProductFinder
	{
		private Product _product;

		public void RegisterProduct(Product product)
		{
			_product = product;
		}

		public Product FindProduct(string barcode)
		{
			if (ProductExists(barcode))
			{
				return _product;
			}

			return null;
		}

		private bool ProductExists(string barcode)
		{
			return _product?.Barcode == barcode;
		}
	}
}