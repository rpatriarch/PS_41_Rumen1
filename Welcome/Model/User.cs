using System;
using Welcome.Others;

namespace Welcome.Model
{
	
	public class User
	{
		protected int id;
        public virtual int Id { get => id; set => id = value; }
        public string? Names { get; set; }
		public string? Password { get; set; }
		public UserRolesEnum Role { get; set; }
		public bool Active { get; set; }
		public DateTime ValidUntil { get; set; }
        public int RoleOrder
        {
            get
            {
             
                switch (Role)
                {
                    case UserRolesEnum.ADMIN:
                        return 1;
                    case UserRolesEnum.INSPECTOR:
                        return 2;
                    case UserRolesEnum.PROFESSOR:
                        return 3;
                    case UserRolesEnum.STUDENT:
                        return 4;
                    case UserRolesEnum.USER:
                        return 5;
                    case UserRolesEnum.ANONYMOUS:
                    default:
                        return 6;
                }
            }
        }

    }
}

