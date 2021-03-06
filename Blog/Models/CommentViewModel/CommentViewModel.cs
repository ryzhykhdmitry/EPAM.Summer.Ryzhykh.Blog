﻿using Blog.Models.AccountViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Blog.Models.CommentViewModel
{
    public class CommentViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter comment")]
        [Display(Name = "Comment:")]
        public string Text { get; set; }

        [DataType(DataType.Date)]
        public DateTime PublicationDate { get; set; }

        public int AuthorId { get; set; }

        [Required]
        public int ArticleId { get; set; }

        public RegisterViewModel Author { get; set; }
    }
}