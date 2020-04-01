using System;
using System.Collections.Generic;

namespace ClassLibrary1.Models
{
    public partial class Posts
    {
        public Posts()
        {
            PostToPostGroup = new HashSet<PostToPostGroup>();
        }

        public int PostId { get; set; }
        public string PostTitle { get; set; }
        public string PostText { get; set; }
        public string ImageName { get; set; }
        public DateTime CreateDate { get; set; }
        public int UserCreateId { get; set; }

        public virtual Users UserCreate { get; set; }
        public virtual ICollection<PostToPostGroup> PostToPostGroup { get; set; }
    }
}
