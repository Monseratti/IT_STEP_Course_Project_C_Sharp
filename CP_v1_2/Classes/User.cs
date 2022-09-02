using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Windows.Media;

namespace CP_v1_2
{
    public class User
    {
        public enum Role
        {
            root, user, guest
        }
        public int UserID { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        public string UserName { get; set; }
        [Required]
        public Role UsersRole { get; set; }

        public byte[] UserPhoto { get; set; }

        [NotMapped]
        public ImageSource photo { get; set; }

        public ICollection<TemporaryUser> temporaryUsers { get; set; }
        public ICollection<Wallet> Wallets { get; set; }
        public ICollection<PlanningCashFlow> PlansCF { get; set; }
    }
}
