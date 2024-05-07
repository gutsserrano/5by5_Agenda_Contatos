using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda_Telefone
{
    internal class PhoneList
    {
        Phone? head;
        Phone? tail;

        public PhoneList()
        {
            head = null;
            tail = null;
        }

        public void Add(Phone phone)
        {
            if (IsEmpty())
            {
                this.head = phone;
                this.tail = phone;
            }
            else
            {
                int comparison = string.Compare(phone.GetNumber(), head.GetNumber(), comparisonType: StringComparison.OrdinalIgnoreCase);

                if (comparison <= 0)
                {
                    Phone aux = head;
                    head = phone;
                    head.SetNext(aux);
                }
                else
                {
                    Phone aux = head;
                    Phone prev = head;
                    do
                    {
                        comparison = string.Compare(phone.GetNumber(), aux.GetNumber(), comparisonType: StringComparison.OrdinalIgnoreCase);
                        if (comparison > 0)
                        {
                            prev = aux;
                            aux = aux.GetNext();
                        }
                    } while (comparison > 0 && aux != null);

                    prev.SetNext(phone);
                    phone.SetNext(aux);

                    if (aux == null)
                    {
                        tail = phone;
                    }
                }
            }
        }

        public bool RemoveFromNumber(string number)
        {
            if (!IsEmpty())
            {
                Phone aux = head;
                Phone prev = head;

                bool comparison = number.Equals(head.GetNumber());

                if (comparison)
                {
                    head = head.GetNext();

                    if (head == null)
                    {
                        tail = null;
                    }
                    return true;
                }
                else
                {
                    do
                    {
                        comparison = number.Equals(aux.GetNumber());

                        if (!comparison)
                        {
                            prev = aux;
                            aux = aux.GetNext();
                        }
                    } while (!comparison && aux != null);

                    if (comparison)
                    {
                        prev.SetNext(aux.GetNext());

                        if (prev.GetNext() == null)
                        {
                            tail = prev;
                        }

                        return true;
                    }

                }
            }

            return false;
        }


        private bool IsEmpty()
        {
            return head == null && tail == null;
        }

        public Phone GetHead()
        {
            return head;
        }
    }
}
