namespace WebApplication1.Model
{
    public class CountryModel
    {
        public string Country_Name { get; set; }
    }

    public class CountyAllModel
    {
        public string CountryCode { get; set; }
        public string Country_Name { get; set; }

        public int IsActive { get; set; }

        public string Abbreviation { get; set; }

        public string Time_Name { get; set; }
    }
    public class CountryCodeModel
    {
        public string CountryCode { get; set; }
    }

}
