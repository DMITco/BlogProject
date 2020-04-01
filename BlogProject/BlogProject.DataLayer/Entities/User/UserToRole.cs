using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlogProject.DataLayer.Entities.User
{
    public class UserToRole
    {
        public UserToRole()
        {
        }

        [Key]
        public int UR_Id { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public bool IsActive { get; set; }



        #region Relations

        public virtual Role Role { get; set; }
        public virtual User User { get; set; }
        


        #endregion

    }
}
