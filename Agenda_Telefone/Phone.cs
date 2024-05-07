using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda_Telefone
{
    internal class Phone
    {
        string number;

        Phone? next;

        public Phone(string n)
        {
            number = n;
            next = null;
        }

        public string GetNumber()
        {
            return number;
        }

        public void SetNext(Phone next)
        {
            this.next = next;
        }

        public Phone GetNext()
        {
            return next;
        }
    }
}
