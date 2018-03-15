using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KennellProject2
{
    /// <summary>
    /// Represents a shopping customer
    /// </summary>
    public class Customer : Person
    {
        private bool _isOnMailList;

        public Customer(string name, string address, string email, bool isOnMailList) 
            : base(name, address, email)
        {
            _isOnMailList = isOnMailList;
        }

        public bool isOnMailList
        {
            get { return _isOnMailList; }
        }
    }
}
