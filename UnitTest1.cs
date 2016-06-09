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

  }
}
