using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rakuten.Test.Core.Enum;

namespace Rakuten.Test.Core.Model
{
    [Serializable()]
    public class Order
    {

        public int Id { get; set; }

        public int UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public AddressType AddressType { get; set; }

        public string ZipCode { get; set; }

        public string Address { get; set; }

        public string District { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        public decimal Amount { get; set; }

        public decimal Shipping { get; set; }

        public OrderStatus CurrentStatus { get; set; }

        public bool Integrated { get; set; }

        public DateTime DateCreation { get; set; }

        public DateTime DateModified { get; set; }

    }
}
