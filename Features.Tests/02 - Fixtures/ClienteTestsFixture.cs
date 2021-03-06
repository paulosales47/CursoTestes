using Features.Clientes;
using Xunit;

namespace Features.Tests
{
    [CollectionDefinition(nameof(ClienteCollection))]
    public class ClienteCollection : ICollectionFixture<ClienteTestsFixture>
    {}

    public class ClienteTestsFixture : IDisposable
    {
        public Cliente GerarClienteValido()
        {
            var cliente = new Cliente(
                Guid.NewGuid(),
                "Paulo",
                "Sampaio",
                DateTime.Now.AddYears(-30),
                "paulo@teste.net",
                true,
                DateTime.Now,
                "87284457830");

            return cliente;
        }

        public Cliente GerarClienteInValido()
        {
            var cliente = new Cliente(
                Guid.NewGuid(),
                "",
                "",
                DateTime.Now,
                "paulo2net.com",
                true,
                DateTime.Now,
                "38831900200");

            return cliente;
        }

        public void Dispose()
        {
        }
    }
}