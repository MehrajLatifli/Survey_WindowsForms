using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey
{
    public class User
    {
        public User()
        {
                            
        }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int Mobilnumber { get; set; }

        public string FullData => $" {Name} {LastName} {Age} {Mobilnumber}";

        public override string ToString()
        {
            return $" {Name} {LastName} {Age} {Mobilnumber}";
        }
    }
}
