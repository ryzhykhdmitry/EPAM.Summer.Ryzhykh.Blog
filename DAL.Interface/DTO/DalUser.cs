using System;
using System.Collections.Generic;

namespace DAL.Interface.DTO
{
    public class DalUser : IEntity
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

        public virtual List<DalArticle> Articles { get; set; }

        public virtual List<DalComment> Comments { get; set; }

        public virtual List<DalRole> Roles { get; set; } 
    }
}
