using System;
using Xunit;
using Gourmet;
using Moq;

namespace Gourmet.Tests
{
    public class NotificadorTests
    {
        [Fact]
        public void EjecutarAccion_CallsSendMailWithComensalVeganoAndComidaVegana_ShouldExecuteOnce()
        {
            var recetario = FixtureTests.GetEmptyRecetario();
            var mockEmailSender = new Mock<EmailSender>();
            mockEmailSender.Setup(x => x.SendMail(It.IsAny<String>())).Callback<String>(mensaje => Console.WriteLine(mensaje));
            var comensalVegano = FixtureTests.GetComensalVegano();
            var comidaVegana = new Comida();
            comidaVegana.AddIngrediente(FixtureTests.GetIngrediente_Vegano());
            var notificador = new Notificador(comensalVegano, mockEmailSender.Object);

            notificador.EjecutarAccion(comidaVegana, recetario);

            mockEmailSender.Verify(x => x.SendMail("mensaje"), Times.Once());
        }

        [Fact]
        public void EjecutarAccion_CallsSendMailWithComensalVeganoAndComidaCarnivora_ShouldExecuteNever()
        {
            var recetario = FixtureTests.GetEmptyRecetario();
            var mockEmailSender = new Mock<EmailSender>();
            mockEmailSender.Setup(x => x.SendMail(It.IsAny<String>())).Callback<String>(mensaje => Console.WriteLine(mensaje));
            var comensalVegano = FixtureTests.GetComensalVegano();
            var comidaCarnivora = new Comida();
            comidaCarnivora.AddIngrediente(FixtureTests.GetIngrediente_Carnivoro());
            var notificador = new Notificador(comensalVegano, mockEmailSender.Object);

            notificador.EjecutarAccion(comidaCarnivora, recetario);

            mockEmailSender.Verify(x => x.SendMail("mensaje"), Times.Never());
        }

        [Fact]
        public void EjecutarAccion_CallsSendMailWithComensalVeganoAndComidaCarnivoraWhenActivaIsFalse_ShouldExecuteNever()
        {
            var recetario = FixtureTests.GetEmptyRecetario();
            var mockEmailSender = new Mock<EmailSender>();
            mockEmailSender.Setup(x => x.SendMail(It.IsAny<String>())).Callback<String>(mensaje => Console.WriteLine(mensaje));
            var comensalVegano = FixtureTests.GetComensalVegano();
            var comidaCarnivora = new Comida();
            comidaCarnivora.AddIngrediente(FixtureTests.GetIngrediente_Carnivoro());
            var notificador = new Notificador(comensalVegano, mockEmailSender.Object);
            notificador.Desactivar();

            notificador.EjecutarAccion(comidaCarnivora, recetario);

            mockEmailSender.Verify(x => x.SendMail("mensaje"), Times.Never());
        }

        [Fact]
        public void EjecutarAccion_CallsSendMailWithComensalVeganoAndComidaVeganaWhenActivaIsFalse_ShouldExecuteNever()
        {
            var recetario = FixtureTests.GetEmptyRecetario();
            var mockEmailSender = new Mock<EmailSender>();
            mockEmailSender.Setup(x => x.SendMail(It.IsAny<String>())).Callback<String>(mensaje => Console.WriteLine(mensaje));
            var comensalVegano = FixtureTests.GetComensalVegano();
            var comidaVegana = new Comida();
            comidaVegana.AddIngrediente(FixtureTests.GetIngrediente_Vegano());
            var notificador = new Notificador(comensalVegano, mockEmailSender.Object);
            notificador.Desactivar();

            notificador.EjecutarAccion(comidaVegana, recetario);

            mockEmailSender.Verify(x => x.SendMail("mensaje"), Times.Never());
        }
    }
}
