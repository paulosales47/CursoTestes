namespace Demo.Test
{
    public class FuncionarioFactoryTest
    {
        [Fact]
        [Trait("Categoria", "FuncionarioFactory")]
        public void FuncionarioFactory_Criar_DeveRetornarTipoFuncionario() 
        {
            //arrange & act
            var funcionario = FuncionarioFactory.Criar("Teste", 10000);

            //assert
            Assert.IsType<Funcionario>(funcionario);
        }

        [Fact]
        [Trait("Categoria", "FuncionarioFactory")]
        public void FuncionarioFactory_Criar_DeveRetornarTipoDerivadoPessoa()
        {
            //arrange & act
            var funcionario = FuncionarioFactory.Criar("Teste", 10000);

            //assert
            Assert.IsAssignableFrom<Pessoa>(funcionario);
        }
    }
}
