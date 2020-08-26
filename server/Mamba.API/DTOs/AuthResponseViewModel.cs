using System.Collections.Generic;

namespace Mamba.API.DTOs
{
    public class AuthResponseViewModel
    {
        public string AcessToken { get; set; }
        public double ExpiresIn { get; set; }
        public UserTokenViewModel User { get; set; }
    }

    public class UserTokenViewModel
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }
        public string Foto { get; set; }
        public IEnumerable<ClaimTokenViewModel> Claims { get; set; }
    }

    public class ClaimTokenViewModel
    {
        public string Type { get; set; }
        public string Value { get; set; }
    }
}
