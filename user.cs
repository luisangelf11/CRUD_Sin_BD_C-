using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDSinBD
{
    public class user
    {
        private string name;
        private string lastname;
        private int age;
        private int id;

        public string Name { get => name; set => name = value; }
        public string Lastname { get => lastname; set => lastname = value; }
        public int Age { get => age; set => age = value; }
        public int Id { get => id; set => id = value; }
    }
}
