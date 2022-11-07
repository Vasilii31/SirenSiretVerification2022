using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SirenSiretVerification2022;

namespace SirenSiretVerification2022Test
{
    [TestClass]
    public class KeyValidationTest
    {
        private readonly KeyValidation keyValidation;

        //Arrange
        public KeyValidationTest()
        {
            keyValidation = new KeyValidation();
        }

        [TestMethod]
        [DataRow("80040322200015")]
        [DataRow("800403223")]
        public void ShouldControlKeyVerifBeInvalid(string inputStr)
        {
            //Act
            bool isValid = keyValidation.KeyLhunAlgorithm(inputStr);
            //Assert
            Assert.IsFalse(isValid, $"{inputStr} is an valid Siren or Siret");
        }

        [TestMethod]
        [DataRow("800403222")]
        [DataRow("80040322200014")]
        [DataRow("217103746")]
        public void ShouldControlKeyVerifBeValid(string inputStr)
        {
            //Act
            bool isValid = keyValidation.KeyLhunAlgorithm(inputStr);
            //Assert
            Assert.IsTrue(isValid, $"{inputStr} is an invalid Siren or Siret");
        }

        [TestMethod]
        [DataRow("732829320", 40)]
        [DataRow("73282932000074", 50)]
        public void ShouldReturnLhunSumValue(string inputStr, int ResultExpected)
        {
            //Act
            int sum = keyValidation.LhunSum(inputStr);
            //Assert
            Assert.AreEqual(ResultExpected, sum, $"LuhnSum of {inputStr} returned {sum} and {ResultExpected} was expected");
        }
    }
}
