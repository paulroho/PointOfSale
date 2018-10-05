using FluentAssertions;
using Xunit;

namespace PointOfSale
{
	public class InventoryAsProductFinderTests
	{
		[Fact]
		public void FindProduct_ReturnsStuff()
		{
			Product prod = new Product("existingBarcode", 10);
			IProductFinder productFinder = BuildInventoryWith(prod);

			// Act
			var result = productFinder.FindProduct("existingBarcode");

			result.Should().Be(prod);
		}

		[Fact]
		public void FindProduct_ReturnsNothing()
		{
			IProductFinder productFinder = BuildEmptyInventory();
		
			// Act
			var result = productFinder.FindProduct("barcodeDoesntExist");

			result.Should().BeNull();
		}

		private static Inventory BuildEmptyInventory()
		{
			return BuildInventoryWith(null);
		}

		private static Inventory BuildInventoryWith(Product prod)
		{
			var inventory = new Inventory();
			inventory.RegisterProduct(prod);
			return inventory;
		}
	}
}