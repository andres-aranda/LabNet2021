using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Negocio;

namespace Testing
{
    [TestClass]
    public class UnitTestIntegerExt
    {
        #region Tests de DividirPorCero();

        [DataRow(2)]
        [DataRow(5)]
        [DataRow(10)]
        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void DividirPorZero_ShouldMakeExeption(int numero)
        {
            //Arrange handle in DataRow

            //Act
            numero.DividirPorCero();

            //Assert handle in ExpectedException
        }

        #endregion

        #region Tests de DividirPor(this int dividendo, int divisor);

        [DataRow(8, 0)]
        [DataRow(0, 0)]
        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void DividirDosNumeros_ShouldMakeExeptionDivideByZeroException(int dividendo, int divisor)
        {
            //Arrange handle in DataRow

            //Act
            dividendo.DividirPor(divisor);

            //Assert handle in ExpectedException
        }


        [DataRow("y", 7)]
        [DataRow(6, "y")]
        [DataRow("x", "y")]
        [DataRow(null, "y")]
        [DataRow("x", null)]
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DividirDosNumeros_ShouldMakeArgumentException(int? numero1, int? numero2)
        {
            //Arrange handle in DataRow
            int dividendo = (int)numero1;
            int divisor = (int)numero2;

            //Act
            dividendo.DividirPor(divisor);

            //Assert handle in ExpectedException
        }

        [DataRow(null, 9)]
        [DataRow(8, null)]
        [DataRow(null, null)]
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void DividirDosNumeros_ShouldMakeInvalidOperationException(int? numero1, int? numero2)
        {
            //Arrange handle in DataRow
            int dividendo = (int)numero1;
            int divisor = (int)numero2;

            //Act
            dividendo.DividirPor(divisor);

            //Assert handle in ExpectedException
        }
        #endregion

        #region Tests de ProducirExepcion();

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void ProducirExepcion_ShouldMakeOlnlyExeption()
        {
            //Arrange 

            //Act
            Logic.ProducirExepcion();

            //Assert handle in ExpectedException
        }

        #endregion

        #region Tests de ProducirExepcionProducirExepcionPersonalizada();

        [TestMethod]
        [ExpectedException(typeof(CustomExeption))]
        public void ProducirExepcionPersonalizada_ShouldMakeCustomExeption()
        {
            //Arrange 

            //Act
            Logic.ProducirExepcionPersonalizada();

            //Assert handle in ExpectedException
        }

        #endregion

    }
}
