using Blog.Models.AccountViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Blog.Models.ArticleViewModel
{
    public class ArticleViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Title:")]
        [MaxLength(400, ErrorMessage = "Too long title")]
        [Required(ErrorMessage = "Enter title")]
        public string Title { get; set; }
        [Display(Name = "Text:")]
        [Required(ErrorMessage = "Enter some text")]
        public string Text { get; set; }       
        public DateTime PublicationDate { get; set; }
        public int AuthorId { get; set; }
        public int CountLikes { get; set; }
        public RegisterViewModel User { get; set; }

        public IEnumerable<string> Tags { get; set; }
        public IEnumerable<string> Comments { get; set; }
    }
}