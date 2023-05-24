using Alura.ByteBank.Dados.Repositorio;
using Alura.ByteBank.Dominio.Entidades;
using Alura.ByteBank.Dominio.Interfaces.Repositorios;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Alura.ByteBank.Infraestrutura.Testes
{
    public class ClienteRepositorioTestes
    {
        private readonly IClienteRepositorio _repositorio;
        public ClienteRepositorioTestes()
        {
            //Injeção de dependências
            var servico = new ServiceCollection(); 
            servico.AddTransient<IClienteRepositorio, ClienteRepositorio>();
            var provedor = servico.BuildServiceProvider();
            _repositorio = provedor.GetService<IClienteRepositorio>();

        }
        [Fact]
        public void TesteObterTodosClientes()
        {
            //Arrange
            // var _repositorio = new ClienteRepositorio(); // Já foi criado na injeção de dependências

            //Act
            List<Cliente> lista = _repositorio.ObterTodos();

            // Assert
            Assert.NotNull(lista);
            //Assert.Equal(4,lista.Count);
        }

        [Fact]
        public void TesteObterClientePorId()
        {
            //Arrange

            //Act
            var cliente = _repositorio.ObterPorId(1);


            //Assert
            Assert.NotNull(cliente);

        }
        [Theory]
        [InlineData(1)]
        [InlineData(2)]

        public void TesteObterClientePorVariosId(int id)
        {
            //Arrange 

            //Act
            var cliente = _repositorio.ObterPorId(id);

            //Assert
            Assert.NotNull(cliente);


        }





    }
}
