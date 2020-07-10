using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace TestUnitario
{
    [TestClass]
    public class UnitTestTrackingIDRepetido
    {
        [TestMethod]
        [ExpectedException(typeof(TrackingIdRepetidoException))]
        public void TestMethodTrackingIdRepetido()
        {
            Correo correo = new Correo();
            Paquete p1 = new Paquete("Av. Mitre 450", "001-001-0001");
            Paquete p2 = new Paquete("Calle Falsa 123", "001-001-0001");

            correo += p1;
            correo += p2;
        }
    }
}
