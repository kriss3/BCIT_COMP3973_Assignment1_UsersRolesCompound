using System;
using ZenithWeb.Models;

namespace ZenithWeb.Service
{
    public class CompoundCalculatorService : ICalcService
    {
        public decimal CalculateCompoundInterest(CalculatorData myData)
        {
            if (myData == null)
                return -1;
            decimal result = 0m;
            //Math.Pow(100.00, 3.00); // 100.00 ^ 3.00
            //Principal=5000;
            //InterestRate=0.05;
            //Number of times the interest is compounded: 12
            //Time=10 years

            // example: 1+ 0.05 /12
            var temp1 = Decimal.ToDouble(1 + (myData.InterestRate/100) / myData.NoOfTimesInterestComp);
            var temp2 =(decimal)Math.Pow(temp1, myData.NoOfTimesInterestComp * myData.Time);

            result = myData.Principal * temp2;

            return result;
        }
    }
}
