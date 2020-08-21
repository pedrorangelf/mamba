namespace Mamba.API.Extensions
{
    public class JwtSettings
    {
        public string Secret { get; set; }
        public int ExpiraEmHoras { get; set; }
        public string Emissor { get; set; }
        public string ValidoEm { get; set; }
    }
}
