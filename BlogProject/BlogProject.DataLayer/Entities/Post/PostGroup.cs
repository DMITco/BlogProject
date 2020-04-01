using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlogProject.DataLayer.Entities.Post
{
    public class PostGroup
    {
        public PostGroup()
        {
            PostToPostGroup = new HashSet<PostToPostGroup>();
        }

        [Key]
        public int GroupId { get; set; }

        [Display(Name = "عنوان گروه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200)]
        public string GroupTitle { get; set; }

        public virtual ICollection<PostToPostGroup> PostToPostGroup { get; set; }
    }
}
