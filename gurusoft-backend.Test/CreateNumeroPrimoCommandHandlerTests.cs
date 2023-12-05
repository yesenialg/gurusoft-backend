using gurusoft_backend.Application.Contracts;
using gurusoft_backend.Application.Features.NumerosPrimos.Commands.CreateNumerosPrimos;
using Moq;

namespace gurusoft_backend.Test
{
    public class CreateNumerosPrimosCommandHandlerTests
    {
        [Fact]
        public async Task Solicitar7PrimosDesde5_RetornaLosPrimos()
        {
            // Arrange
            var repositoryMock = new Mock<INumerosPrimosRepository>();
            var handler = new CreateNumeroPrimoCommandHandler(repositoryMock.Object);
            var command = new CreateNumeroPrimoCommand
            {
                NumeroInicial = 5,
                CantidadPrimos = 7,
                Usuario = "Yesenia"
            };

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Contains("Numeros primos: 5, 7, 11, 13, 17, 19, 23, ", result);
        }

        [Fact]
        public async Task SolicitarPrimos_SeEnviaLaInfoALaBD()
        {
            // Arrange
            var repositoryMock = new Mock<INumerosPrimosRepository>();
            var handler = new CreateNumeroPrimoCommandHandler(repositoryMock.Object);
            var command = new CreateNumeroPrimoCommand
            {
                NumeroInicial = 5,
                CantidadPrimos = 7,
                Usuario = "Yesenia"
            };

            // Act
            await handler.Handle(command, CancellationToken.None);

            // Assert
            repositoryMock.Verify(repo => repo.AddAsync(It.IsAny<Domain.NumerosPrimos>()), Times.Once);
        }

        [Fact]
        public void EsPrimo_RetornarTrueParaNumeroPrimo()
        {
            // Arrange
            int numero = 13;

            // Act
            var result = CreateNumeroPrimoCommandHandler.EsPrimo(numero);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void EsPrimo_RetornarFalseParaNoPrimo()
        {
            // Arrange
            int numero = 12;

            // Act
            var result = CreateNumeroPrimoCommandHandler.EsPrimo(numero);

            // Assert
            Assert.False(result);
        }
    }
}
