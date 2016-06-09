using System;
using System.Text.RegularExpressions;
using System.Linq;

namespace StringCalculatorTests
{
  public class Calculator
  {

    public int Add(string parameter)
    {
      int retval = default(int);
      if (string.IsNullOrEmpty(parameter))
      {
        retval = 0;
      }
      else
      {
        string[] listOfNUmber = GetNumbers(parameter);
        CheckNumbersValidity(listOfNUmber);
        listOfNUmber = listOfNUmber.ToList().Where(a => int.Parse(a) < 1000).ToArray();
        if (listOfNUmber.Length > 0)
        {
          retval = EseguiSomma(retval, listOfNUmber);
        }
        else
        {
          int.TryParse(parameter, out retval);
        }
      }
      return retval;
    }

    private void CheckNumbersValidity(string[] listOfNUmber)
    {
      if (listOfNUmber.Any(a => a.StartsWith("-")))
      {
        throw new NotNegativeAllowedException("Negative not allowed."
          , listOfNUmber.Where(a => a.StartsWith("-")).Select(a => int.Parse(a)).ToList());
      }
    }

    private string[] GetNumbers(string parameter)
    {
      return Regex.Replace(parameter, "//.\n", "").Split(GetSeparators(parameter));
    }

    private char[] GetSeparators(string parameter)
    {
      char[] separators = null;
      if (parameter.StartsWith("//"))
      {
        separators = parameter.Substring(2, 1).ToCharArray();
      }
      else
      {
        separators = new char[] { ';', ',', '\n' };
      }
      return separators;
    }

    private int EseguiSomma(int retval, string[] listOfNUmber)
    {
      foreach (var item in listOfNUmber)
      {
        retval = retval + int.Parse(item);
      }

      return retval;
    }
  }
}