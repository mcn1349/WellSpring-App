using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WellSpring.Core.Model
{
    public class UserTable
    {
        public UserTable() { }
        public UserTable(UserTableAutoCompleteResult user)
        {
            Name = user.Name;
            AimCalorie = user.AimCalorie;
            DOB = user.DOB;
            Email = user.Email;
            Weight = user.Weight;
        }

        public string Id { get; set; }

        public string Name { get; set; }
        public int AimCalorie { get; set; }
        public DateTime DOB { get; set; }
        public string Email { get; set; }
        public int Weight { get; set; }

    }
}
