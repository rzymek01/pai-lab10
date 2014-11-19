using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{

    public class Person : PersonTO
    {
        public Person(String firstname = "", string surname = "", int id = -1)
            : base(firstname, surname, id)
        {

        }
    }
}
