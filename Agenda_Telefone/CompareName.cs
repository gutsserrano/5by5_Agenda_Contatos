using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda_Telefone
{
    internal class CompareName : IComparer<Contact>
    {
        public int Compare(Contact c1, Contact c2)
        {
            return string.Compare(c1.Name, c2.Name);
        }
    }
}
