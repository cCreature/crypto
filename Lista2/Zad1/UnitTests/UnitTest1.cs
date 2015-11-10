
using System;
using System.Text;
using NUnit.Framework;
using Zad1;
using System.Collections.Generic;


namespace UnitTests
{
 
    public class UnitTest1
    {
        [TestCase("a",Result = "01100001")]
        [TestCase("j", Result = "01101010")]
        [TestCase("x", Result = "01111000")]
        public string TestConverting(string x)
        {
           return Converter.StringToBinary(x);

        }



        [TestCase(new byte[] {0x75}, new byte[] {0x34}, Result = new byte[] {0x41})]
        public byte[] TestXor(byte[] x, byte[] y)
        {
            return Converter.XoR(x, y);


        }
        [TestCase("01000001",Result = "A")]
        [TestCase("00110000", Result = "0")]
        public string Test(string x)
        {
            return Converter.BinToString(x);

        }

        [TestCase("asascB?", Result = true)]
        [TestCase("asascBc###", Result = false)]
        public bool TestRegex(string x)
        {

            return Converter.Check(x);
        }
    }
}
