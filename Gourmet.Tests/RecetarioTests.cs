using System;
using Xunit;
using Gourmet;
using Moq;

namespace Gourmet.Tests
{
    public class RecetarioTests
    {
        private Recetario recetario = new Recetario();

        [Fact]
        public void Comidas_Count_WithEmptyList_Should()
        {
            int result = recetario.RecetarioComidas.Count;

            Assert.Equal(0, result);
        }

        [Fact]
        public void Comidas_Count_WithOneElement_Should()
        {
            recetario.AddComida(new Comida());

            int result = recetario.RecetarioComidas.Count;

            Assert.Equal(1, result);
        }

        [Fact]
        public void AddComida_CallsEjecutarAcciones_ShouldExecuteNoActions()
        {
            var mockNotificador = new Mock<Notificador>();
            mockNotificador.Setup(x => x.EjecutarAccion(It.IsAny<Comida>(), It.IsAny<Recetario>())).Callback<Comida, Recetario>((comida, recetario) => Console.WriteLine("Llamado método EjecutarAccion(...) de Notificador."));
            var recetario = FixtureTests.GetEmptyRecetario();
            var comida = FixtureTests.GetComida_WithIngredientes();
            recetario.AddComida(comida);

            recetario.SuscribirAccion(mockNotificador.Object);

            mockNotificador.Verify(x => x.EjecutarAccion(comida, recetario), Times.Never());
        }

        [Fact]
        public void AddComida_CallsEjecutarAcciones_ShouldExecuteOneAction()
        {
            var mockNotificador = new Mock<Notificador>();
            mockNotificador.Setup(x => x.EjecutarAccion(It.IsAny<Comida>(), It.IsAny<Recetario>())).Callback<Comida, Recetario>((comida, recetario) => Console.WriteLine("Llamado método EjecutarAccion(...) de Notificador."));
            mockNotificador.Setup(x => x.Activa).Returns(true);
            var recetario = FixtureTests.GetEmptyRecetario();
            recetario.SuscribirAccion(mockNotificador.Object);
            var comida = FixtureTests.GetComida_WithIngredientes();

            recetario.AddComida(comida);

            mockNotificador.Verify(x => x.EjecutarAccion(comida, recetario), Times.Once());
        }

        [Fact]
        public void AddComida_CallsEjecutarAccionesAndDesactivarAccion_ShouldExecuteOneAction()
        {
            var mockNotificador = new Mock<Notificador>();
            mockNotificador.Setup(x => x.EjecutarAccion(It.IsAny<Comida>(), It.IsAny<Recetario>())).Callback<Comida, Recetario>((comida, recetario) => Console.WriteLine("Llamado método EjecutarAccion(...) de Notificador."));
            mockNotificador.Setup(x => x.Activa).Returns(true);
            mockNotificador.Setup(x => x.Desactivar()).Callback(() => {Console.WriteLine("Seteando Activa a false");});
            var recetario = FixtureTests.GetEmptyRecetario();
            recetario.SuscribirAccion(mockNotificador.Object);
            var comida1 = FixtureTests.GetComida_WithIngredientes();
            var comida2 = FixtureTests.GetComida_WithIngredientes();

            recetario.AddComida(comida1);
            mockNotificador.Object.Desactivar();

            mockNotificador.Verify(x => x.EjecutarAccion(comida1, recetario), Times.Once());
            mockNotificador.Verify(x => x.Desactivar(), Times.Once());
        }

        [Fact]
        public void AddComida_CallsEjecutarAccionesWithDisabledAction_ShouldExecuteNoAction()
        {
            var mockNotificador = new Mock<Notificador>();
            mockNotificador.Setup(x => x.EjecutarAccion(It.IsAny<Comida>(), It.IsAny<Recetario>())).Callback<Comida, Recetario>((comida, recetario) => Console.WriteLine("Llamado método EjecutarAccion(...) de Notificador."));
            mockNotificador.Setup(x => x.Activa).Returns(false);
            var recetario = FixtureTests.GetEmptyRecetario();
            recetario.SuscribirAccion(mockNotificador.Object);
            var comida1 = FixtureTests.GetComida_WithIngredientes();

            recetario.AddComida(comida1);

            mockNotificador.Verify(x => x.EjecutarAccion(comida1, recetario), Times.Never());
        }
    }
}
