using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace TestUnitario
{
    [TestClass]
    public class UnitTestListaPaquetes
    {
        [TestMethod]
        public void TestMethodListaPaquetes()
        {
            Correo correo = new Correo();

            Assert.IsNotNull(correo.Paquetes);
        }
    }
}
