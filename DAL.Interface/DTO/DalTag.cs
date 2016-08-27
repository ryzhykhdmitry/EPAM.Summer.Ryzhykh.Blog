using System.Collections.Generic;


namespace DAL.Interface.DTO
{
    public class DalTag : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual List<DalArticle> Articles { get; set; }
    }
}
