namespace WebApplication1.Model
{
    public class Package_CategoryModel
    {
        public int Package_id { get; set; }
        public int Clientid { get; set; }
        public string Packet_Code { get; set; }
        public string Packcat_Desc { get; set; }
        public DateTime Time_Created { get; set; }
        public DateTime Last_Mod { get; set; }
        public string Mod_User { get; set; }
    }
}
