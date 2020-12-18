using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Human
    {
        public Person Person { get; set; }
        public Email Email { get; set; }
        public Password Password { get; set; }
        public Address Address { get; set; }
        public PersonPhone PersonPhone { get; set; }
    }
}
