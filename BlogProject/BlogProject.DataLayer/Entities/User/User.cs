using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlogProject.DataLayer.Entities.User
{
    public class User
    {
        public User()
        {
            Posts = new HashSet<Post.Post>();
            UserToRoles = new HashSet<UserToRole>();
        }

        [Key]
        public int UserId { get; set; }

        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمیتواند بیشتر از بلاک {1} باشد")]
        public string UserName { get; set; }


        [Display(Name = "نام")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمیتواند بیشتر از بلاک {1} باشد")]
        public string Name { get; set; }


        [Display(Name = "نام خانوادگی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمیتواند بیشتر از بلاک {1} باشد")]
        public string Family { get; set; }



        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمیتواند بیشتر از بلاک {1} باشد")]
        [EmailAddress(ErrorMessage = "ایمیل وارد شده معتبر نمی باشد")]
        public string Email { get; set; }



        [Display(Name = "کلمه عبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمیتواند بیشتر از بلاک {1} باشد")]
        public string Password { get; set; }

        [Display(Name = "کدفعالسازی")]
        [MaxLength(50, ErrorMessage = "{0} نمیتواند بیشتر از بلاک {1} باشد")]
        public string ActiveCode { get; set; }


        [Display(Name = "وضعیت")]
        public bool IsActice { get; set; }


        [Display(Name = "آواتار")]
        [MaxLength(200, ErrorMessage = "{0} نمیتواند بیشتر از بلاک {1} باشد")]
        public string UserAvatar { get; set; }


        [Display(Name = "تاریخ ثبت نام")]
        public DateTime RegisterDate { get; set; }



        #region Relations
        public virtual ICollection<Post.Post> Posts { get; set; }
        public virtual ICollection<UserToRole> UserToRoles { get; set; }
        #endregion
    }
}
