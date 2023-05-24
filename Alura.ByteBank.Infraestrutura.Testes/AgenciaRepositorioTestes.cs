using Alura.ByteBank.Dados.Repositorio;
using Alura.ByteBank.Dominio.Entidades;
using Alura.ByteBank.Dominio.Interfaces.Repositorios;
using Alura.ByteBank.Infraestrutura.Testes.Servico;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Alura.ByteBank.Infraestrutura.Testes
{
    public class AgenciaRepositorioTestes
    {
        private readonly IAgenciaRepositorio _repositorio;
        
        // Propriedade de saída de testes no console
        public ITestOutputHelper SaidaConsoleTeste { get; set; }
        public AgenciaRepositorioTestes(ITestOutputHelper saidaConsoleTeste)
        {
            SaidaConsoleTeste = saidaConsoleTeste;
            SaidaConsoleTeste.WriteLine("Construtor Executado Com Sucesso! ");

            //Injeção de dependências no Construtor
            var servico = new ServiceCollection(); 
            servico.AddTransient<IAgenciaRepositorio, AgenciaRepositorio>();
            var provedor = servico.BuildServiceProvider();
            _repositorio = provedor.GetService<IAgenciaRepositorio>();

        }
        [Fact]
        public void TesteObterTodasAgencias()
        {
            //Arrange
            // var _repositorio = new ClienteRepositorio(); // Já foi criado na injeção de dependências

            //Act
            List<Agencia> lista = _repositorio.ObterTodos();

            // Assert
            Assert.NotNull(lista);
            Assert.Equal(4,lista.Count);
        }

        [Fact]
        public void TesteObterAgenciaPorId()
        {
            //Arrange

            //Act
            var agencia = _repositorio.ObterPorId(1);


            //Assert
            Assert.NotNull(agencia);

        }
        [Theory]
        [InlineData(1)]
        [InlineData(2)]

        public void TesteObterAgenciaPorVariosId(int id)
        {
            //Arrange 

            //Act
            var agencia = _repositorio.ObterPorId(id);

            //Assert
            Assert.NotNull(agencia);


        }
        [Fact]
        public void TesteInsereUmaNovaAgenciaNaBaseDeDadosRepositorio()
        {
            //Arrange            
            string nome = "C6 Bank";
            int numero = 125982;
            Guid identificador = Guid.NewGuid();
            string endereco = "Rua: 7 de Setembro - Centro";

            var agencia = new Agencia()
            {
                Nome = nome,
                Identificador = identificador,
                Endereco = endereco,
                Numero = numero
            };

            //Act
            var retorno = _repositorio.Adicionar(agencia);

            //Assert
            Assert.True(retorno);
        }
        [Fact]
        public void TestaAtualizacaoInformacaoDeterminadaAgenciaRepositorio()
        {
            //Arrange      
            var agencia = _repositorio.ObterPorId(2);
            var nomeNovo = "BTG Pactual";
            agencia.Nome = nomeNovo;

            //Act
            var atualizado = _repositorio.Atualizar(2, agencia);

            //Assert
            Assert.True(atualizado);
        }

        [Fact]
        public void TestaRemoverInformacaoDeterminadaAgencia()
        {
            //Arrange
            //Act
            var atualizado = _repositorio.Excluir(6);

            //Assert
            Assert.True(atualizado);
        }

        [Fact]
        public void TestaExcecaoConsultaPorAgenciaPorId()
        {
            //Arrange
            //Act

            //Assert
            Assert.Throws<FormatException>( // Testando uma excecão quando buscar uma agencia que não existe
               () => _repositorio.ObterPorId(33)
               );
        }

        [Fact]
        public void TestaAdicionarAgenciaMock()
        {
            //Arrange
            var agencia = new Agencia()
            {
                Nome = "Agencia Amaral",
                Identificador = Guid.NewGuid(),
                Id = 4, 
                Endereco = "Rua Gonzaga",
                Numero = 1234
            };

            var repositorioMock = new ByteBankRepositorio();

            //Act
            var adicionado = repositorioMock.AdicionarAgencia(agencia);

            //Assert
            Assert.True(adicionado);

        }

        [Fact]
        public void TestaObterAgenciaMock()
        {
            //Arrange
            var bytebankrepositorioMock = new Mock<IByteBankRepositorio>();
            var mock = bytebankrepositorioMock.Object;

            //Act
            var lista = mock.BuscarAgencias();

            //Assert
            bytebankrepositorioMock.Verify(b => b.BuscarAgencias());
        }

    }
}
