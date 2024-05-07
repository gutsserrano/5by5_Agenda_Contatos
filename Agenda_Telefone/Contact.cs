using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda_Telefone
{
    internal class Contact
    {
        string name;
        PhoneList phoneList;
        Adress adress;
        string email;

        Contact? next;

        public Contact(string name, PhoneList phoneList, Adress adress, string email)
        {
            this.name = name;
            this.phoneList = phoneList;
            this.adress = adress;
            this.email = email;
            next = null;
        }

        public void SetName(string name)
        {
            this.name = name;
        }

        public string GetName()
        {
            return name;
        }

        public void SetPhoneList(PhoneList phoneList)
        {
            this.phoneList = phoneList;
        }

        public PhoneList GetPhoneList()
        {
            return phoneList;
        }

        public void SetAdress(Adress adress)
        {
            this.adress = adress;
        }

        public Adress GetAdress()
        {
            return adress;
        }

        public void SetEmail(string email)
        {
            this.email = email;
        }

        public string GetEmail()
        {
            return email;
        }

        public void SetNext(Contact next)
        {
            this.next = next;
        }

        public Contact GetNext()
        {
            return this.next;
        }
    }
}
