using Features.Clientes;
using Xunit;

namespace Features.Tests
{
    public class ClienteTests
    {
        [Fact(DisplayName = "Novo Cliente Válido")]
        [Trait("Categoria","Cliente Trait Testes")]
        public void Cliente_NovoCliente_DeveEstarValido()
        {
            // Arrange
            var cliente = new Cliente(
                Guid.NewGuid(),
                "Paulo",
                "Sampaio",
                DateTime.Now.AddYears(-30),
                "teste@teste.net",
                true,
                DateTime.Now,
                "71757015604");

            // Act
            var result = cliente.EhValido();

            // Assert 
            Assert.True(result);
            Assert.Empty(cliente.ValidationResult?.Errors);
        }

        [Fact(DisplayName = "Novo Cliente Inválido")]
        [Trait("Categoria", "Cliente Trait Testes")]
        public void Cliente_NovoCliente_DeveEstarInvalido()
        {
            // Arrange
            var cliente = new Cliente(
                Guid.NewGuid(),
                "",
                "",
                DateTime.Now,
                "teste2dominio.com",
                true,
                DateTime.Now,
                "12302750888");

            // Act
            var result = cliente.EhValido();

            // Assert 
            Assert.False(result);
            Assert.NotEmpty(cliente.ValidationResult?.Errors);
        }
    }
}