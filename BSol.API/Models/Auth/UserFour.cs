using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace BSol.API.Models.Auth
{
    [Table("UserFour")]
    public class UserFour : IdentityUser
    {
        public string State { get; set; } = string.Empty;
        public string District { get; set; } = string.Empty;
        public int Pincode { get; set; }
        public string Area { get; set; } = string.Empty;
        public double Lattitude { get; set; }
        public double Longitude { get; set; }
    }
}
