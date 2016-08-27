using System.Collections.Generic;

namespace BLL.Interface.Entities
{
    public class TagEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual List<ArticleEntity> Articles { get; set; }
    }
}
