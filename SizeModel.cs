namespace WebApplication1.Model
{
    public class SizeModel
    { 
        public string ClientID { get; set; }
    public string Size { get; set; }
    public string SizeDesc { get; set; }
    public string Lang1Desc { get; set; }
    public string Lang2Desc { get; set; }
    public string Lang3Desc { get; set; }
    public string Lang4Desc { get; set; }
    public string Lang5Desc { get; set; }
    public string Lang6Desc { get; set; }
    public string NrfSize { get; set; }
    public string sizeGroup { get; set; }
    public DateTime LastMod { get; set; }
    public DateTime TimeCreated { get; set; }
    public string ModUser { get; set; }
    
    }
    public class LoginResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
