using NUnit.Framework;
using System;
using TestApp.Product;

namespace TestApp.Tests;

[TestFixture]
public class ProductInventoryTests
{
    private ProductInventory _inventory = null!;
    
    [SetUp]
    public void SetUp()
    {
        this._inventory = new();
    }
    
    [Test]
    public void Test_AddProduct_ProductAddedToInventory()
    {
        // Arrange
        string productName = "Banana";
        double productPrice = 100;
        int productQty = 10;

        string expectedInventory = $"Product Inventory:{Environment.NewLine}{productName} - Price: ${productPrice:f2} - Quantity: {productQty}";

        // Act
        this._inventory.AddProduct(productName, productPrice, productQty);
        string result = this._inventory.DisplayInventory();

        // Assert
        Assert.AreEqual(expectedInventory, result);
    }

    [Test]
    public void Test_DisplayInventory_NoProducts_ReturnsEmptyString()
    {
        // Arrange
        string expected = "Product Inventory:";
        // Act
        string result = this._inventory.DisplayInventory();
        // Assert
        Assert.AreEqual(expected, result);

    }

    [Test]
    public void Test_DisplayInventory_WithProducts_ReturnsFormattedInventory()
    {
        // Arrange
        string productNameOne = "Banana";
        double productPriceOne = 100;
        int productQtyOne = 10;

        string productNameTwo = "Apple";
        double productPriceTwo = 10;
        int productQtyTwo = 10;

        string expected = $"Product Inventory:{Environment.NewLine}{productNameOne} - Price: ${productPriceOne:f2} - Quantity: {productQtyOne}" +
                                            $"{Environment.NewLine}{productNameTwo} - Price: ${productPriceTwo:f2} - Quantity: {productQtyTwo}";
        // Act
        this._inventory.AddProduct(productNameOne, productPriceOne, productQtyOne);
        this._inventory.AddProduct(productNameTwo, productPriceTwo, productQtyTwo);
        string result = this._inventory.DisplayInventory();
        
        // Assert
        Assert.AreEqual (expected, result);
    }

    [Test]
    public void Test_CalculateTotalValue_NoProducts_ReturnsZero()
    {
        // Arrange
        //string expected = "Product Inventory:";
        // Act
        double result = this._inventory.CalculateTotalValue();
        // Assert
        Assert.AreEqual(0, result);
    }

    [Test]
    public void Test_CalculateTotalValue_WithProducts_ReturnsTotalValue()
    {

        // Arrange
        string productNameOne = "Banana";
        double productPriceOne = 100;
        int productQtyOne = 10;

        string productNameTwo = "Apple";
        double productPriceTwo = 10;
        int productQtyTwo = 10;

        double expectedTotalSum = (10 * 100) + 100;

        // Act
        this._inventory.AddProduct(productNameOne, productPriceOne, productQtyOne);
        this._inventory.AddProduct(productNameTwo, productPriceTwo, productQtyTwo);
        double result = this._inventory.CalculateTotalValue();
        // Assert
        Assert.AreEqual(expectedTotalSum, result);
    }
}
