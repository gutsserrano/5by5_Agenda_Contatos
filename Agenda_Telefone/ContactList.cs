using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Agenda_Telefone
{
    internal class ContactList
    {
        Contact? head;
        Contact? tail;

        public ContactList()
        {
            head = null;
            tail = null;
        }

        public void Add(Contact contact)
        {
            if (IsEmpty())
            {
                this.head = contact;
                this.tail = contact;
            }
            else
            {
                int comparison = string.Compare(contact.GetName(), head.GetName(), comparisonType: StringComparison.OrdinalIgnoreCase);

                if (comparison <= 0)
                {
                    Contact aux = head;
                    head = contact;
                    head.SetNext(aux);
                }
                else
                {
                    Contact aux = head;
                    Contact prev = head;
                    do
                    {
                        comparison = string.Compare(contact.GetName(), aux.GetName(), comparisonType: StringComparison.OrdinalIgnoreCase);
                        if (comparison > 0)
                        {
                            prev = aux;
                            aux = aux.GetNext();
                        }
                    } while (comparison > 0 && aux != null);

                    prev.SetNext(contact);
                    contact.SetNext(aux);

                    if (aux == null)
                    {
                        tail = contact;
                    }
                }
            }
        }

        public bool RemoveFromName(string name)
        {
            if (!IsEmpty())
            {
                Contact aux = head;
                Contact prev = head;

                bool comparison = name.Equals(head.GetName());

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
                        comparison = name.Equals(aux.GetName());

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

        public void Print()
        {
            Contact aux = head;
            PhoneList auxPhoneList;
            Phone auxPhone;

            int cont = 1;

            if (!IsEmpty())
            {
                do
                {
                    Console.WriteLine("\n====================================\n");
                    Console.WriteLine($"Nome: {aux.GetName()}");
                    Console.WriteLine();
                    Console.WriteLine($"Telefones");

                    auxPhoneList = aux.GetPhoneList();
                    auxPhone = auxPhoneList.GetHead();

                    do
                    {
                        Console.WriteLine($"\tT{cont} >> {auxPhone.GetNumber()}");
                        auxPhone = auxPhone.GetNext();
                        cont++;
                    } while(auxPhone != null);

                    Console.WriteLine();

                    aux = aux.GetNext();

                } while (aux != null);
            }
            else
            {
                Console.WriteLine("\n**Lista de contatos vazia!**");
            }
        }

        public void PrintByName(string name)
        {
            Contact aux = head;
            PhoneList auxPhoneList;
            Phone auxPhone;
            Adress auxAdress;
            int cont = 1;
            bool find = false;

            if (!IsEmpty())
            {
                do
                {
                    if (aux.GetName().Equals(name))
                    {
                        Console.WriteLine($"Nome: {aux.GetName()}");
                        Console.WriteLine();
                        Console.WriteLine($"Telefones");

                        auxPhoneList = aux.GetPhoneList();
                        auxPhone = auxPhoneList.GetHead();

                        do
                        {
                            Console.WriteLine($"\tT{cont} >> {auxPhone.GetNumber()}");
                            auxPhone = auxPhone.GetNext();
                            cont++;
                        } while (auxPhone != null);

                        auxAdress = aux.GetAdress();
                        Console.WriteLine();
                        Console.WriteLine("Endereço");
                        Console.WriteLine($"\tCEP: {auxAdress.GetCep()}");
                        Console.WriteLine($"\tCidade: {auxAdress.GetLocality()}, {auxAdress.GetState()}");
                        Console.WriteLine($"\tLogradouro: {auxAdress.GetPublicPlaceType()} {auxAdress.GetPublicPlace()}");
                        Console.WriteLine($"\tNumero: {auxAdress.GetNumber()}");
                        Console.WriteLine($"\tBairro: {auxAdress.GetNeighborhood()}");
                        Console.WriteLine($"\tComplemento: {auxAdress.GetComplement()}");

                        Console.WriteLine();
                        Console.WriteLine($"Email: {aux.GetEmail()}");

                        find = true;
                    }

                    aux = aux.GetNext();
                } while (aux != null && !find);

                if (!find)
                {
                    Console.WriteLine("\n**Usuário não encontrado!**");
                }
            }
            else
            {
                Console.WriteLine("\n**Lista de contatos vazia!**");
            }
        }

        public Contact FindByName(string name)
        {
            Contact aux = head;

            if (!IsEmpty())
            {
                do
                {
                    if (aux.GetName().Equals(name))
                    {
                        return aux;
                    }

                    aux = aux.GetNext();
                } while (aux != null);
            }
                
            return null;
        }
    }
}
