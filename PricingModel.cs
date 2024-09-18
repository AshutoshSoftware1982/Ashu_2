using Microsoft.AspNetCore.Routing.Patterns;
using System.Drawing;
using System.Reflection.Emit;

namespace WebApplication1.Model
{
    public class PricingModel
    {
        public string PricingCode { get; set; }
        public int CustomerID { get; set; }

        public string Label { get; set; }

        public string Color { get; set; }

        public string Dim {get;set;}

        public string PPK { get; set; }
        public DateTime EffectiveDate { get; set; }
        public string SellingDivision { get; set; }
        public string BaseCurrency { get; set; }
        public int PriceA { get; set; }
        public int PriceB { get; set; }
        public int PriceC { get; set; }
        public int PriceD { get; set; }
        public int PriceE { get; set; }
        public int PriceF { get; set; }

    }
}
