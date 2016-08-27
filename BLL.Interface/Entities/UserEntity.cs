using System;
using System.Collections.Generic;

namespace BLL.Interface.Entities
{
    public class UserEntity
    {
        public int Id { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public DateTime? RegistrationDate { get; set; }

        public DateTime? BirthDate { get; set; }

        public bool Blocked { get; set; }

        public byte[] Avatar { get; set; }

        public string About { get; set; }

        public virtual List<ArticleEntity> Articles { get; set; }

        public virtual List<CommentEntity> Comments { get; set; }

        public virtual List<RoleEntity> Roles { get; set; }
    }
}
