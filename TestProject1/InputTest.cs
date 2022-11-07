using Microsoft.VisualStudio.TestTools.UnitTesting;
using SirenSiretVerification2022;
using System;

namespace SirenSiretVerification2022Test
{
    [TestClass]
    public class InputTest
    {
        private readonly Input _input;

        //Arrange
        public InputTest()
        {
            _input = new Input();
        }

        [TestMethod]
        [DataRow("")]
        [DataRow("asjh2132d")]
        [DataRow("1232684651321651321651")]
        [DataRow("-651321651")]
        [DataRow("   6513 21651 ")]
        public void ShouldParseResultBeNegativ(string inputStr)
        {
            //Act
            bool parsingSuccess = _input.CheckParsing(inputStr);
            //Assert
            Assert.IsFalse(parsingSuccess, $"{inputStr} is not parsable into a long");
        }

        [TestMethod]
        [DataRow("6513218")]
        [DataRow("6")]
        [DataRow("    21651")]
        [DataRow("21651      ")]
        public void ShouldParseResultPositiv(string inputStr)
        {
            //Act
            bool parsingSuccess = _input.CheckParsing(inputStr);
            //Assert
            Assert.IsTrue(parsingSuccess, $"{inputStr} is not parsable into a long");
        }

        [TestMethod]
        [DataRow("840v22")]
        [DataRow("2")]
        [DataRow("800432130322200014")]
        public void ShouldInputLengthBeIncorrect(string inputStr)
        {
            //Act
            bool length = _input.CheckInputLength(inputStr);
            //Assert
            Assert.IsFalse(length, $"{inputStr} is not the good length");
        }

        [TestMethod]
        [DataRow("   403222")]
        [DataRow("80040322200014")]
        [DataRow("217103abc")]
        [DataRow("800403223")]
        [DataRow("str40322200015")]
        public void ShouldInputLengthBeCorrect(string inputStr)
        {
            //Act
            bool length = _input.CheckInputLength(inputStr);
            //Assert
            Assert.IsTrue(length, $"{inputStr} is not the good length");
        }

        [TestMethod]
        [DataRow("800432130322200014")]
        [DataRow("-651321651")]
        [DataRow("   6513 21651 ")]
        [DataRow("")]
        [DataRow("840v22")]
        [DataRow("   840222")]
        public void ShouldInputGlobalTestBeIncorrect(string inputStr)
        {
            //Act
            bool inputCorrect = _input.CheckGlobalCorrect(inputStr);
            //Assert
            Assert.IsFalse(inputCorrect, $"{inputStr} failed one of the verification tests");
        }


        [TestMethod]
        [DataRow("800403222")]
        [DataRow("80040322200014")]
        [DataRow("217103746")]
        [DataRow("800403223")]
        [DataRow("80040322200015")]
        [DataRow(" 800403223")]
        public void ShouldInputGlobalTestBeCorrect(string inputStr)
        {
            //Act
            bool inputCorrect = _input.CheckGlobalCorrect(inputStr);
            //Assert
            Assert.IsTrue(inputCorrect, $"{inputStr} failed one of the verification tests");
        }
    }
}