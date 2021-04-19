using System.ComponentModel.DataAnnotations;

namespace TtryJWTToken.Data
{
    public class AddRoleModel
    {
        [Required]
        public string UserId { get; set; }
        [Required]
        public string Role { get; set; }




    }
}