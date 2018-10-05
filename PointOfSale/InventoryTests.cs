using FluentAssertions;
using Xunit;

namespace PointOfSale
{
	public class InventoryTests
	{
		[Fact]
		public void FindProduct_ReturnsStuff()
		{
			// Arrange
			Product prod = new Product("a", 10);
			Inventory inventory = new Inventory();
			inventory.RegisterProduct(prod);

			// Act
			IProductFinder productFinder = inventory;
			var result = productFinder.FindProduct("a");

			// Assert
			result.Should().Be(prod);
		}

		[Fact]
		public void FindProduct_ReturnsNothing()
		{
			// Arrange
			Inventory inventory = new Inventory();

			// Act
			IProductFinder productFinder = inventory;
			var result = productFinder.FindProduct("a");

			// Assert
			result.Should().BeNull();
		}

	}
}