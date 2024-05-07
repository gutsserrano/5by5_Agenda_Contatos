using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda_Telefone
{
    internal class Phone
    {
        public string Number { get; set; }

        public Phone? Next { get; set; }

        public Phone(string n)
        {
            Number = n;
            Next = null;
        }
    }
}
