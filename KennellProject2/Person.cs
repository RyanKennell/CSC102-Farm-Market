using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KennellProject2
{
    /// <summary>
    /// Represents the ordinary person
    /// </summary>
    public class Person
    {
        private string _name;
        private string _address;
        private string _emailAddress;

        public Person(string name, string address, string email)
        {
            _name = name;
            _address = address;
            _emailAddress = email;
        }

        public string Name
        {
            get { return _name; }
        }

        public string Address
        {
            get { return _address; }
        }

        public string EmailAddress
        {
            get { return _emailAddress; }
        }
    }
}
