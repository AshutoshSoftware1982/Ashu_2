namespace WebApplication1.Model
{
    public class SizeExplosionModel
    {
         public string ClientID { get; set; }
         public string Size_Explosion { get; set; }
         public string SizeExplDesc { get; set; }
         public string Divison { get; set; }
         public string SizeRange { get; set; }
         public string ExplRatio { get; set; }
         public string ExplBy { get; set; }
         public DateTime LastMod { get; set; }
          public DateTime TimeCreated { get; set; }
          public string ModUser { get; set; }

    }
    public class SizeExplosionsModel
    {
        public string ClientID { get; set; }
        public string Size_Explosion { get; set; }
        public string SizeExplDesc { get; set; }
        public string Divison { get; set; }
        public string SizeRange { get; set; }
        
        public string ExplBy { get; set; }
        
        public string ModUser { get; set; }

    }
}
