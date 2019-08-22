using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rakuten.Test.Core.Enum;

namespace Rakuten.Test.Core.Model
{
    [Serializable()]
    public class User
    {

        public User()
        {
            this.Addresses = new List<AddressData>();
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public GenderType Gender { get; set; }

        public string DocumentId { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public bool Integrated { get; set; }

        public DateTime DateCreation { get; set; }

        public DateTime DateModified { get; set; }

        public List<AddressData> Addresses { get; set; }

    }
}
