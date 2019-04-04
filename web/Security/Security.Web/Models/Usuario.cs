using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Security.Web.Models
{
    public class Usuario
    {
        public enum Types
        {
            Administrador = 100, Normal = 200
        }

        public string Fullname { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        public string User { get; set; }
        public bool updatepassword { get; set; }
        public bool IsBlocked { get; set; }
        public int CountBlocked { get; set; }
        public DateTime DateUpdatePassword { get; set; }

        public Types RolUser { get; set; }

        public int TypeUser
        {
            get
            {
                return (int)RolUser;
            }
            set
            {
                switch (value)
                {
                    case 100:
                        RolUser = Types.Administrador;
                        break;
                    case 200:
                        RolUser = Types.Normal;
                        break;
                    default:
                        RolUser = Types.Normal;
                        break;
                }
            }
        }
    }
}
