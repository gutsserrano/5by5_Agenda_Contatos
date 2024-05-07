using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda_Telefone
{
    internal class Contact
    {
        public string Name { get; set; }
        public  List<Phone> PhoneList { get; set; }
        public Adress Adress { get; set; }
        public string Email { get; set; }

        public Contact? Next { get; set; }

        public Contact(string name, List<Phone> phoneList, Adress adress, string email)
        {
            this.Name = name;
            this.PhoneList = phoneList;
            this.Adress = adress;
            this.Email = email;
            Next = null;
        }
    }
}
