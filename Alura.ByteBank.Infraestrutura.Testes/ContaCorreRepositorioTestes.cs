using Alura.ByteBank.Dados.Repositorio;
using Alura.ByteBank.Dominio.Entidades;
using Alura.ByteBank.Dominio.Interfaces.Repositorios;
using Alura.ByteBank.Infraestrutura.Testes.Servico;
using Alura.ByteBank.Infraestrutura.Testes.Servico.DTO;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Alura.ByteBank.Infraestrutura.Testes
{
    public class ContaCorreRepositorioTestes
    {
        private readonly IContaCorrenteRepositorio _repositorio;
        public ContaCorreRepositorioTestes()
        {
            //Injeção de dependências
            var servico = new ServiceCollection();
            servico.AddTransient<IContaCorrenteRepositorio, ContaCorrenteRepositorio>();
            var provedor = servico.BuildServiceProvider();
            _repositorio = provedor.GetService<IContaCorrenteRepositorio>();

        }
        [Fact]
        public void TesteObterTodasContaCorrente()
        {
            //Arrange
            // var _repositorio = new ContaCorrenteRepositorio(); // Já foi criado na injeção de dependências

            //Act
            List<ContaCorrente> lista = _repositorio.ObterTodos();

            // Assert
            Assert.NotNull(lista);
            Assert.Equal(5, lista.Count);
        }

        [Fact]
        public void TesteObterContaCorrentePorId()
        {
            //Arrange

            //Act
            var contacorrente = _repositorio.ObterPorId(1);


            //Assert
            Assert.NotNull(contacorrente);

        }
        [Theory]
        [InlineData(1)]
        [InlineData(2)]

        public void TesteObterContaCorrentePorVariosId(int id)
        {
            //Arrange 

            //Act
            var contacorrente = _repositorio.ObterPorId(id);

            //Assert
            Assert.NotNull(contacorrente);


        }

        [Fact]
        public void TestaAtualizaSaldoDeterminadaConta()
        {
            //Arrenge
            var conta = _repositorio.ObterPorId(1);
            double saldoNovo = 15;
            conta.Saldo = saldoNovo;

            //Act
            var atualizado = _repositorio.Atualizar(1, conta);

            //Assert
            Assert.True(atualizado);
        }

        [Fact]
        public void TesteInserirNovaContaCorrente()
        {
            //Arrenge 
            var conta = new ContaCorrente()
            {
                Saldo = 10,
                Identificador = Guid.NewGuid(),

                Cliente = new Cliente()
                {
                    Nome = "Calel Filho",
                    CPF = "486.074.980-45",
                    Identificador = Guid.NewGuid(),
                    Profissao = "Contador",
                    Id = 1,
                },
                Agencia = new Agencia()
                {
                    Nome = "Banco JRAA",
                    Identificador = Guid.NewGuid(),
                    Id = 1,
                    Endereco = "Rua Dos Iluminados",
                    Numero = 1000,

                },
            };

            //Act 
            var retorno = _repositorio.Adicionar(conta);

            //Assert
            Assert.True(retorno);
        }

        [Fact]
        public void TestaConsultaPix()
        {
            //Arrange
            var guid = new Guid("a0b80d53-c0dd-4897-ab90-c0615ad80d5a");
            var pix = new PixDTO() { Chave = guid, Saldo = 10 };

            var pixRepositorioMock = new Mock<IPixRepositorio>();
            pixRepositorioMock.Setup(x => x.consultaPix(It.IsAny<Guid>())).Returns(pix);

            var mock = pixRepositorioMock.Object;


            //Act
            var saldo = mock.consultaPix(guid).Saldo;


            //Assert

            Assert.Equal(10, saldo);
        }



    }
}
