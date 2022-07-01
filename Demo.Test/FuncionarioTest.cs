using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Test
{
    public class FuncionarioTest
    {
        [Fact]
        [Trait("Categoria", "Funcionario")]
        public void Funcionario_Nome_NaoDeveSerNuloOuVazio()
        {
            //arrange & act
            var funcionario = new Funcionario("", 1000);

            //assert
            Assert.False(string.IsNullOrEmpty(funcionario.Nome));
        }

        [Fact]
        [Trait("Categoria", "Funcionario")]
        public void Funcionario_Apelido_NaoDeveTerApelido()
        {
            //arrange & act
            var funcionario = new Funcionario("Nome Teste", 1000);

            //assert
            Assert.Null(funcionario.Apelido);
            Assert.True(string.IsNullOrEmpty(funcionario.Apelido));
            Assert.False(funcionario.Apelido?.Length > 0);
        }

        [Theory]
        [Trait("Categoria", "Funcionario")]
        [InlineData(700)]
        [InlineData(1500)]
        [InlineData(2000)]
        [InlineData(7500)]
        [InlineData(8000)]
        [InlineData(15000)]
        public void Funcionario_Salario_FaixaSalariaisDevemRespeitarNivelProfissional(double salario)
        {
            //arrange
            var funcionario = new Funcionario("Teste Nome", salario);

            //assert
            if (funcionario.NivelProfissional == NivelProfissional.Junior)
                Assert.InRange(funcionario.Salario, 500, 1999);

            if (funcionario.NivelProfissional == NivelProfissional.Pleno)
                Assert.InRange(funcionario.Salario, 2000, 7999);

            if (funcionario.NivelProfissional == NivelProfissional.Senior)
                Assert.InRange(funcionario.Salario, 8000, double.MaxValue);

            Assert.NotInRange(funcionario.Salario, 0, 499);
        }

        [Fact]
        [Trait("Categoria", "Funcionario")]
        public void Funcionario_Habilidades_NaoDevePossuirHabilidadesVazias() 
        {
            //arrange & act
            var funcionario = FuncionarioFactory.Criar("Teste", 10000);

            //assert
            Assert.All(funcionario.Habilidades, habilidade => Assert.False(string.IsNullOrWhiteSpace(habilidade)));
        }

        [Fact]
        [Trait("Categoria", "Funcionario")]
        public void Funcionario_Habilidades_JuniorDevePossuirHabilidadesBasicas()
        {
            //arrange & act
            var funcionario = FuncionarioFactory.Criar("Teste", 1000);

            //assert
            Assert.Contains("OOP", funcionario.Habilidades);
            Assert.Contains("Lógica de programação", funcionario.Habilidades);
        }

        [Fact]
        [Trait("Categoria", "Funcionario")]
        public void Funcionario_Habilidades_JuniorNaoDevePossuirHabilidadeAvancada()
        {
            //arrange & act
            var funcionario = FuncionarioFactory.Criar("Teste", 1000);

            //assert
            Assert.DoesNotContain("Microserviços", funcionario.Habilidades);
        }

        [Fact]
        [Trait("Categoria", "Funcionario")]
        public void Funcionario_Habilidades_SeniorDevePossuirTodasHabilidades()
        {
            //arrange & act
            var funcionario = FuncionarioFactory.Criar("Teste", 10000);
            var habilidadesBasicasSenior = new List<string>()
            {
                "Lógica de programação",
                "OOP",
                "Testes",
                "Microserviços"
            };

            //assert
            Assert.Equal(habilidadesBasicasSenior, funcionario.Habilidades);
        }

        [Fact]
        [Trait("Categoria", "Funcionario")]
        public void Funcionario_Salario_DeveRetornarErroSalarioInferiorPermitido()
        {
            //arrange & act & assert
            var exception = Assert.Throws<Exception>(
                () => FuncionarioFactory.Criar("Teste", 250));

            Assert.Equal("Salário inferior ao permitido", exception.Message);
        }
    }
}
