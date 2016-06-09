using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculatorTests
{
  public class NotNegativeAllowedException : Exception
  {

    public NotNegativeAllowedException(string message, List<int> negativeNumbers)
      : base(message)
    {
      this._negativeNumbers = negativeNumbers;
    }

    private List<int> _negativeNumbers;
    public List<int> NegativeNumbers
    {
      get
      {
        return _negativeNumbers;
      }
      set
      {
        _negativeNumbers = value;
      }
    }
  }
}
