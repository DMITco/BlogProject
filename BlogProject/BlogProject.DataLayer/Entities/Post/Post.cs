using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlogProject.DataLayer.Entities.Post
{
    public class Post
    {
        public Post()
        {
        }

        [Key]
        public int PostID { get; set; }

        [Display(Name = "نویسنده")]
        public int UserId { get; set; }

        [Display(Name = "عنوان پست")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(400)]
        public string PostTitle { get; set; }

        [Display(Name = "متن")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [DataType(DataType.MultilineText)]
        public string PostText { get; set; }

        //[Display(Name = "بازدید")]
        //public int PostVisit { get; set; }

        [Display(Name = "تصویر")]
        public string ImageName { get; set; }

        //[Display(Name = "کلمات کلیدی")]
        //public string PostTags { get; set; }

        [Display(Name = "تاریخ")]
        public DateTime CreateDate { get; set; }



        public virtual List<PostToPostGroup> PostToPostGroup { get; set; }
        public virtual User.User User { get; set; }
    }
}
