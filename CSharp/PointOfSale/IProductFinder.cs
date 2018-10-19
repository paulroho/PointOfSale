namespace PointOfSale
{
	public interface IProductFinder
	{
		Product FindProduct(string barcode);
	}
}