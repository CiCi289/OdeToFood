using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OdeToFood.Models
{
    public class BookReview
    {
        public int Id { get; set; }

        [Range(1,5)]
        [Required]
        public int Rating { get; set; }
        public string Body { get; set; }

        [Display(Name = "User Name")]
        [DisplayFormat(NullDisplayText = "anonymous reviewer")]
        public string ReviewerName { get; set; }
        public int BookId { get; set; }
    }
}