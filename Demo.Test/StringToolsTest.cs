using System.Text.RegularExpressions;

namespace Demo.Test
{
    public class StringToolsTest
    {
        [Fact]
        [Trait("Categoria", "StringTools")]
        public void StringTools_UnirNomes_RetornaNomeCompleto() 
        {
            //arrange
            var stringTools = new StringTools();

            //act
            string nomeCompleto = stringTools.UnirPalavras("Teste","abc");

            //assert
            Assert.Equal("Teste abc", nomeCompleto);
        }

        [Fact]
        [Trait("Categoria", "StringTools")]
        public void StringTools_UnirPalavras_DeveIgnorarCase() 
        {
            //arrange
            var stringTools = new StringTools();

            //act
            string nomeCompleto = stringTools.UnirPalavras("Nome", "Teste");

            //assert
            Assert.Equal("NOME TESTE", nomeCompleto, ignoreCase: true);
        }

        [Fact]
        [Trait("Categoria", "StringTools")]
        public void StringTools_UnirPalavras_DeveConterTrecho()
        {
            //arrange
            var stringTools = new StringTools();

            //act
            string nomeCompleto = stringTools.UnirPalavras("Nome", "Teste");

            //assert
            Assert.Contains("Tes", nomeCompleto);
        }

        [Fact]
        [Trait("Categoria", "StringTools")]
        public void StringTools_UnirPalavras_DeveComecarCom()
        {
            //arrange
            var stringTools = new StringTools();

            //act
            string nomeCompleto = stringTools.UnirPalavras("Nome", "Teste");

            //assert
            Assert.StartsWith("Nom", nomeCompleto);
        }

        [Fact]
        [Trait("Categoria", "StringTools")]
        public void StringTools_UnirPalavras_DeveTerminarCom()
        {
            //arrange
            var stringTools = new StringTools();

            //act
            string nomeCompleto = stringTools.UnirPalavras("Nome", "qwe");

            //assert
            Assert.EndsWith("we", nomeCompleto);
        }

        [Fact]
        [Trait("Categoria", "StringTools")]
        public void StringTools_UnirPalavras_ValidarExpressaoRegular()
        {
            //arrange
            var stringTools = new StringTools();
            var regex = new Regex("[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+$");

            //act
            string nomeCompleto = stringTools.UnirPalavras("Nsda", "Qwe");

            //assert
            Assert.True(regex.Match(nomeCompleto).Success);
        }
    }
}
