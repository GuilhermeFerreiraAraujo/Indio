using System;
using System.Collections.Generic;
using System.Text;

namespace Indio.Models.Models
{
    public class UserPermission
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int PermissionId { get; set; }

        public Permission Permission { get; set; }

    }
}
