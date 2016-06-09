using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StringCalculatorTests
{
  [TestClass]
  public class UnitTest1
  {
    [TestMethod]
    public void StringaVuotaDeveRestituireZero()
    {
      Calculator sut = new Calculator();

      var actual = sut.Add("");
      Assert.AreEqual(0, actual);
    }

    [TestMethod]
    public void StringaConUnNumeroDeveRestituireSeStesso()
    {
      Calculator sut = new Calculator();
      var parameter = "1";
      var actual = sut.Add(parameter);
      Assert.AreEqual(1, actual);
    }

    [TestMethod]
    public void StringaConDueNumeriDeveRestituireLaSomma()
    {
      Calculator sut = new Calculator();
      var parameter = "1,5";
      var actual = sut.Add(parameter);
      Assert.AreEqual(6, actual);
    }

    [TestMethod]
    public void StringaConNNumeriDeveRestituireLaSomma()
    {
      Calculator sut = new Calculator();
      var parameter = "1,5,1,2";
      var actual = sut.Add(parameter);
      Assert.AreEqual(9, actual);
    }

    [TestMethod]
    public void StringaConNNumeriDiversiSeparatoriDeveRestituireLaSomma()
    {
      Calculator sut = new Calculator();
      var parameter = "1\n2,3";
      var actual = sut.Add(parameter);
      Assert.AreEqual(6, actual);
    }

    [TestMethod]
    [ExpectedException(typeof(System.FormatException))]
    public void StringaConNNumeriDiversiSeparatoriNonValidiDeveRestituireEccezione()
    {
      Calculator sut = new Calculator();
      var parameter = "1,\n";
      var actual = sut.Add(parameter);
      Assert.AreEqual(1, actual);
    }

    [TestMethod]
    public void StringaConNNumeriDelimitatoriConfigurabiliDeveRestituireLaSomma()
    {
      Calculator sut = new Calculator();
      var parameter = "//;\n1;2";
      var actual = sut.Add(parameter);
      Assert.AreEqual(3, actual);
    }

    [TestMethod]
    public void StringaConNNumeriDelimitatoriConfigurabiliConUnaLineaDeveRestituireLaSomma()
    {
      Calculator sut = new Calculator();
      var parameter = "1;2";
      var actual = sut.Add(parameter);
      Assert.AreEqual(3, actual);
    }

    [TestMethod]
    [ExpectedException(typeof(NotNegativeAllowedException))]
    public void StringaConNNumeriNegatioviDeveRestituireEccezione()
    {
      try {
        Calculator sut = new Calculator();
        var parameter = "-1;-2";
        var actual = sut.Add(parameter);
        Assert.Fail();
      }
      catch(NotNegativeAllowedException ex)
      {
        Assert.AreEqual(2, ex.NegativeNumbers.Count);
        throw ex;
      }
    }

    [TestMethod]
    public void StringaConNNumeri1000eRestituireLaSomma()
    {
      Calculator sut = new Calculator();
      var parameter = "//;\n1000;2";
      var actual = sut.Add(parameter);
      Assert.AreEqual(2, actual);
    }
  }
}
