using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlogProject.DataLayer.Entities.Post
{
    public class PostToPostGroup
    {
        public PostToPostGroup()
        {
        }

        [Key]
        public int PPG_Id { get; set; }
        public int PostId { get; set; }
        public int GroupID { get; set; }



        #region Relations

        public virtual Post Post { get; set; }
        public virtual PostGroup PostGroup { get; set; }


        #endregion
    }
}
