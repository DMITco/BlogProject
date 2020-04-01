using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlogProject.DataLayer.Entities.Post
{
    public class PostToPostGroup
    {

        [Key]
        public int PPGId { get; set; }
        public int PostId { get; set; }
        public int GroupID { get; set; }



        #region Relations
        public virtual PostGroup Group { get; set; }
        public virtual Post Post { get; set; }



        #endregion
    }
}
