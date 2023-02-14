using AspNet_MediatR_Demo.Domain.Entity;
using AspNet_MediatR_Demo.Repository;
using System.Xml.Linq;

namespace AspNet_MeditR_Tests
{
    public class ProductTests
    {
        [Fact]
        public void Product_ShouldHaveCorrectProperties()
        {
            // Arrange
            var name = "Product 1";
            var price = 10.5m;

            // Act
            var product = new Produto() { Nome = name, Preco = price };

            // Assert
            Assert.Equal(name, product.Nome);
            Assert.Equal(price, product.Preco);
        }

        [Fact]
        public void Product_Update_ShouldUpdateProperties()
        {
            // Arrange
            var name = "Product 1";
            var price = 10.5m;
            var product = new Produto { Nome = name, Preco = price };

            // Act
            var newName = "Product 2";
            var newPrice = 20.0m;
            product.Update(newName, newPrice);

            // Assert
            Assert.Equal(newName, product.Nome);
            Assert.Equal(newPrice, product.Preco);
        }

        [Fact]
        public async Task ProductRepository_CreateProduct_ShouldAddProduct()
        {
            // Arrange
            var repository = new ProdutoRepository();
            var product = new Produto() { Id = 4, Nome = "Product 1", Preco = 10.5m };

            // Act
            await repository.Add(product);

            // Assert
            var createdProduct = await repository.Get(product.Id);
            Assert.Equal(product.Nome, createdProduct.Nome);
            Assert.Equal(product.Preco, createdProduct.Preco);
        }

        [Fact]
        public async Task ProductRepository_UpdateProduct_ShouldUpdateProduct()
        {
            // Arrange
            var repository = new ProdutoRepository();
            var product = new Produto() { Id = 6, Nome = "Product 1", Preco = 10.5m };
            await repository.Add(product);

            // Act
            var newName = "Product 2";
            var newPrice = 20.0m;
            product.Update(newName, newPrice);
            await repository.Edit(product);

            // Assert
            var updatedProduct = await repository.Get(product.Id);
            Assert.Equal(newName, updatedProduct.Nome);
            Assert.Equal(newPrice, updatedProduct.Preco);
        }

        [Fact]
        public async Task ProductRepository_DeleteProduct_ShouldDeleteProduct()
        {
            // Arrange
            var repository = new ProdutoRepository();
            var product = new Produto() { Id = 7, Nome = "Product 1", Preco = 10.5m };
            await repository.Add(product);

            // Act
            await repository.Delete(product.Id);

            // Assert
            var deletedProduct = await repository.Get(product.Id);
            Assert.Null(deletedProduct);
        }
    }
}