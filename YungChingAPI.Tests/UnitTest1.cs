using Moq;
using Xunit;
using YungChingAPI.Models;
using YungChingAPI.Repositorys;
using YungChingAPI.Request;
using YungChingAPI.Services;
using YungChingAPI.Utils;
using Assert = Xunit.Assert;
namespace YungChingAPI.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void UpdateProductTest()
        {
            // Arrange
            var productId = 1;
            var categoryId = 2;
            var supplierId = 3;
            var updateRequest = new UpdateProductRequest
            {
                ProductId = productId,
                CategoryId = categoryId,
                SupplierId = supplierId
            };

            Mock<IProductRepository> mockProductRepository = new();
            Mock<ICategoryRepository> mockCategoryRepository = new();
            Mock<ISupplierRepository> mockSupplierRepository = new();

            var productService = new ProductService(
                mockProductRepository.Object,
                mockCategoryRepository.Object,
                mockSupplierRepository.Object
            );
            // Setup
            mockProductRepository.Setup(x => x.GetById(productId))
                                 .Returns(new Product { ProductId = productId });

            mockCategoryRepository.Setup(x => x.GetById(categoryId))
                                  .Returns(new Category { CategoryId = categoryId });

            mockSupplierRepository.Setup(x => x.GetById(supplierId))
                                  .Returns(new Supplier { SupplierId = supplierId });

            mockProductRepository.Setup(x => x.UpdateOne(updateRequest))
                                 .Returns(1);

            // Act
            productService.UpdateProduct(updateRequest);

            // Assert
            mockProductRepository.Verify(x => x.UpdateOne(It.IsAny<UpdateProductRequest>()), Times.Once);

        }
        [Fact]
        public void UpdateProductTest_ProductNotFound()
        {
            // Arrange
            var productId = 1;
            var updateRequest = new UpdateProductRequest
            {
                ProductId = productId,
            };

            Mock<IProductRepository> mockProductRepository = new();
            Mock<ICategoryRepository> mockCategoryRepository = new();
            Mock<ISupplierRepository> mockSupplierRepository = new();

            var productService = new ProductService(
                mockProductRepository.Object,
                mockCategoryRepository.Object,
                mockSupplierRepository.Object
            );
            // Setup
            mockProductRepository.Setup(x => x.GetById(productId));

            // Assert
            var exception = Assert.Throws<MyException>(() => productService.UpdateProduct(updateRequest));
            Assert.Equal("2001", exception.ErrorCode);
        }
    }
}