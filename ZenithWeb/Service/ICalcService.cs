using ZenithWeb.Models;

namespace ZenithWeb.Service
{
    public interface ICalcService
    {
        decimal CalculateCompoundInterest(CalculatorData myData);
    }
}
