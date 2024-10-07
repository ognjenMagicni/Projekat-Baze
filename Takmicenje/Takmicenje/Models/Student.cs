using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Takmicenje.AdditionalClasses;

namespace Takmicenje.Models
{
    public class Student
    {
        public string username;
        public string name;
        public string surname;
        private string password;

        public void setPassword(string passw)
        {
            this.password = HashClass.HashFunction(passw);
        }
        public string getPassword()
        {
            return this.password;
        }

        
    }
}
