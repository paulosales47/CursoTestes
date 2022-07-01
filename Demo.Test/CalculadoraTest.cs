namespace Demo.Test
{
    public class CalculadoraTest
    {
        [Fact(DisplayName = "Calculadora_Somar_DeveSerIgual")]
        [Trait("Categoria", "Calculadora")]
        public void Calculadora_Somar_DeveSerIgual() 
        {
            //arrange
            var calculadora = new Calculadora();

            //Act
            double resultadoSoma = calculadora.Somar(10, 20);

            //Assert
            Assert.Equal(30, resultadoSoma);
        }


        [Theory(DisplayName = "Calculadora_Somar_RetornarValorSomasCorretos")]
        [Trait("Categoria", "Calculadora")]
        [InlineData(1, 2, 3)]
        [InlineData(50, 50, 100)]
        [InlineData(1, -1, 0)]
        [InlineData(99, 99, 198)]
        public void Calculadora_Somar_RetornarValorSomasCorretos(double primeiroTermo, double segundoTermo, double resultadoEsperado)
        {
            //arrange
            var calculadora = new Calculadora();

            //Act
            double resultadoSoma = calculadora.Somar(primeiroTermo, segundoTermo);

            //Assert
            Assert.Equal(resultadoEsperado, resultadoSoma);
        }

        [Fact(DisplayName = "Calculadora_Somar_DeveSerDiferente")]
        [Trait("Categoria", "Calculadora")]
        public void Calculadora_Somar_DeveSerDiferente()
        {
            //arrange
            var calculadora = new Calculadora();

            //Act
            double resultadoSoma = calculadora.Somar(1.13123123123, 2.2312313123);

            //Assert
            Assert.NotEqual(3.3, resultadoSoma, precision: 1);
        }

        [Fact(DisplayName = "Calculadora_Dividir_DeveRetornarErroDivisaoPorZero")]
        [Trait("Categoria", "Calculadora")]
        public void Calculadora_Dividir_DeveRetornarErroDivisaoPorZero() 
        {
            //arrange
            var calculadora = new Calculadora();

            //act & assert
            Assert.Throws<DivideByZeroException>(() => calculadora.Dividir(10, 0));
        }

        [Theory(DisplayName = "Calculadora_Dividir_RetornarValorDivisaoCorretos")]
        [Trait("Categoria", "Calculadora")]
        [InlineData(1, 2, 0)]
        [InlineData(50, 50, 1)]
        [InlineData(8, -2, -4)]
        [InlineData(99, 98, 1)]
        public void Calculadora_Dividir_RetornarValorDivisaoCorretos(int primeiroTermo, int segundoTermo, int resultadoEsperado)
        {
            //arrange
            var calculadora = new Calculadora();

            //Act
            double resultadoDivisao = calculadora.Dividir(primeiroTermo, segundoTermo);

            //Assert
            Assert.Equal(resultadoEsperado, resultadoDivisao);
        }
    }
}
