using System;

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
        var listOfNUmber = parameter.Split(",".ToCharArray());
        if (listOfNUmber.Length > 0)
        {
          foreach (var item in listOfNUmber)
          {
            retval = retval + int.Parse(item);
          }
        }
        else
        {
          int.TryParse(parameter, out retval);
        }
      }
      return retval;
    }
  }
}