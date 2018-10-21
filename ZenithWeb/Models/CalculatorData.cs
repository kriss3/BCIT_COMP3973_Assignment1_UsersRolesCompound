using System.ComponentModel.DataAnnotations;

namespace ZenithWeb.Models
{
    /// <summary>
    /// Formula: A=P(1+r/n)^(n(t))
    /// A => Amount (CalcResults);
    /// P => Principal;
    /// r => Interests Rate(decimal);
    /// n => number of times interest is compounded per year;
    /// t => Time (in years)
    /// </summary>
    public class CalculatorData
    {
        [Display(Name ="Principal amount (P)")]
        public int Principal { get; set; }
        [Display(Name="Annual Rate (r)")]
        public decimal InterestRate { get; set; }
        [Display(Name ="Compounds per year (n)")]
        public int NoOfTimesInterestComp { get; set; }
        [Display(Name ="Years (t)")]
        public int Time { get; set; }
        [Display(Name ="Investment Balance Result")]
        public decimal CalcResults { get; set; }
    }
}
