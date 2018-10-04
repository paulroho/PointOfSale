using Xunit;

namespace PointOfSale
{
	public class CashRegisterTests
	{
		[Fact]
		public void IDONTKNOWYET()
		{
			CashRegister register;

			// Arrange
			register.RegisterProduct("mybarcode", 123.45m);

			register.ProductSuccessfullyScanned += price =>
			{
				// Assert
				return Assert.Equal(123.45m, price);
			};

			// Act
			register.Scan("mybarcode");
		}
	}
}