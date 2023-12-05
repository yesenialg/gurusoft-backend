using gurusoft_backend.Application.Features.EntradaSalidaPatron.Queries.GetPatronSalida;

namespace gurusoft_backend.Test
{
    public class GetPatronSalidaCommandHandlerTests
    {
        [Fact]
        public async Task StringCaracteresPar_RetornaDosCaracteresDelMedio()
        {
            // Arrange
            var handler = new GetPatronSalidaCommandHandler();
            var command = new GetPatronSalidaCommand { Entrada = "jafgyA" };

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.Equal("fg", result);
        }


        [Fact]
        public async Task StringCaracteresImpar_RetornaElCaracterDelMedio()
        {
            // Arrange
            var handler = new GetPatronSalidaCommandHandler();
            var command = new GetPatronSalidaCommand { Entrada = "Qc1uoTgfd" };

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.Equal("o", result);
        }

        [Fact]
        public async Task StringVacio_RetornaVacio()
        {
            // Arrange
            var handler = new GetPatronSalidaCommandHandler();
            var command = new GetPatronSalidaCommand { Entrada = "" };

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.Equal("", result);
        }
    }
}