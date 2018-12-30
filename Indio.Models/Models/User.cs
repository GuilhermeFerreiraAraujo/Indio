using Indio.Models.Models;
using System.Collections.Generic;

namespace Indio.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual List<UserPermission> UserPermissions {get; set;}
    }
}
