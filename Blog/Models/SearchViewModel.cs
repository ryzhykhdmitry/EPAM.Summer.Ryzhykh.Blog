﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Blog.Models
{
    public class SearchViewModel
    {
        [MinLength(2, ErrorMessage = "Too short string")]
        public string SearchString { get; set; }
    }
}