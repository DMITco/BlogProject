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
        public int RoleMan { get; set; }



        #region Relations

        public virtual User User { get; set; }
        public virtual Role Role { get; set; }


        #endregion

    }
}
