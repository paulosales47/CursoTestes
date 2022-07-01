using Features.Core;
using FluentAssertions;
using Xunit;

namespace Features.Tests
{
    public class CpfValidationTests
    {
        [Theory(DisplayName = "CPF Validos")]
        [Trait("Categoria", "CPF Validation Tests")]
        [InlineData("65289034684")]
        [InlineData("75102025406")]
        [InlineData("85149235288")]
        [InlineData("90348419015")]
        [InlineData("72131410905")]
        public void Cpf_ValidarMultiplosNumeros_TodosDevemSerValidos(string cpf)
        {
            // Assert
            var cpfValidation = new CpfValidation();

            // Act & Assert
            cpfValidation.EhValido(cpf).Should().BeTrue();
        }

        [Theory(DisplayName = "CPF Invalidos")]
        [Trait("Categoria", "CPF Validation Tests")]
        [InlineData("27358130960159")]
        [InlineData("7350551185469")]
        [InlineData("56164348764")]
        [InlineData("23515216258")]
        [InlineData("86124777197")]
        [InlineData("52554787845")]
        public void Cpf_ValidarMultiplosNumeros_TodosDevemSerInvalidos(string cpf)
        {
            // Assert
            var cpfValidation = new CpfValidation();

            // Act & Assert
            cpfValidation.EhValido(cpf).Should().BeFalse();
        }
    }
}