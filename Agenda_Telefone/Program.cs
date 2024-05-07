﻿using System.Globalization;
using System.Runtime.Intrinsics.X86;

namespace Agenda_Telefone
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Contact> contactList = new();

            int option;

            do
            {
                Console.Clear();
                option = Menu();

                switch (option)
                {
                    case 1:
                        AddContact(contactList);
                        break;
                    case 2:
                        RemoveContact(contactList);
                        break;
                    case 3:
                        EditContact(contactList);
                        break;
                    case 4:
                        PrintAll(contactList);
                        break;
                    case 5:
                        FindContact(contactList);
                        break;
                }
            } while(option != 0);
        }

        static int Menu()
        {
            int op;
            do
            {
                Console.WriteLine("1 - Adicionar contato");
                Console.WriteLine("2 - Remover contato");
                Console.WriteLine("3 - Editar contato");
                Console.WriteLine("4 - Imprimir todos os contatos");
                Console.WriteLine("5 - Imprimir um contato específico");
                Console.WriteLine("0 - Sair");
                op = int.Parse(Console.ReadLine());
            } while (op < 0 || op > 5);

            return op;
        }

        static void AddContact(List<Contact> contactList)
        {
            Contact contact;
            string name, email;
            List<Phone> phoneList;
            Adress adress;

            Console.Clear();
            Console.WriteLine("Digite o nome completo do contato");
            name = Console.ReadLine();

            phoneList = RegisterPhones();

            Console.Clear();
            adress = RegisterAdress();

            Console.Clear();
            Console.WriteLine("\nDigite o email do contato");
            email = Console.ReadLine();

            contact = new(name, phoneList, adress, email);

            contactList.Add(contact);

            Console.Clear();
            Console.WriteLine("\n**Contato Adicionado com sucesso!**");
            Console.ReadKey();
        }

        static List<Phone> RegisterPhones()
        {
            List<Phone> phoneList = new();
            string option = "";

            int cont = 1;
            do
            {
                Console.WriteLine($"\nDigite o Telefone {cont}");
                phoneList.Add(new Phone(Console.ReadLine()));

                Console.WriteLine("\nDeseja adicionar mais um telefone?");
                Console.WriteLine("1 - Sim");
                Console.WriteLine("Qualquer tecla - Não");
                option = Console.ReadLine();

                cont++;
            } while (option.Equals("1"));

            //phoneList.Sort();

            return phoneList;
        }

        static Adress RegisterAdress()
        {
            string cep, locality, state, publicPlace, publicPlaceType, neighborhood, complement;
            int number;

            Console.WriteLine("\nDigite o CEP:");
            cep = Console.ReadLine();

            Console.WriteLine("\nCidade:");
            locality = Console.ReadLine();

            Console.WriteLine("\nEstado:");
            state = Console.ReadLine();

            Console.WriteLine("\nLogradouro:");
            publicPlace = Console.ReadLine();

            Console.WriteLine("\nTipo Logradouro:");
            publicPlaceType = Console.ReadLine();

            Console.WriteLine("\nNumero:");
            number = int.Parse(Console.ReadLine());

            Console.WriteLine("\nBairro:");
            neighborhood = Console.ReadLine();


            Console.WriteLine("\nComplemento:");
            complement = Console.ReadLine();

            return new Adress(cep, locality, state, publicPlace, publicPlaceType, neighborhood, number, complement);
        }

        static void RemoveContact(List<Contact> contactList)
        {
            string name;
            bool find = false;

            Console.Clear();
            Console.WriteLine("Digite o Nome do contato a ser removido:");
            name = Console.ReadLine();


            foreach(Contact contact in contactList)
            {
                if(contact.Name == name)
                {
                    contactList.Remove(contact);
                    Console.WriteLine("\n**Contato removido com sucesso!**");
                    find = true;
                    break;
                }
            }

            if (!find)
            {
                Console.WriteLine("\n**Contato inexistente!**");
            }

            Console.ReadKey();
        }

        static void FindContact(List<Contact> contactList)
        {
            string name;

            Console.Clear();
            Console.WriteLine("Digite o nome do contato a ser buscado:");
            name = Console.ReadLine();

            Console.Clear();
            PrintByName(contactList, name);
            Console.ReadKey();
        }

        static void EditContact(List<Contact> contactList)
        {
            string name;
            Contact? contact = null;

            Console.Clear();
            Console.WriteLine("Digite o nome do usuário a ser editado:");
            name = Console.ReadLine();

            foreach(var item in contactList)
            {
                if(item.Name == name)
                {
                    contact = item;
                }
            }

            if (contact != null)
            {
                switch (MenuEditar()) 
                {
                    case 1:
                        Console.WriteLine($"Editar nome - {name}");
                        contact.Name = Console.ReadLine();
                        break;
                    case 2:
                        Console.WriteLine("Editar telefones");
                        contact.PhoneList = RegisterPhones();
                        break;
                    case 3:
                        Console.WriteLine("Editar endereço");
                        contact.Adress = RegisterAdress();
                        break;
                    case 4:
                        Console.WriteLine($"Editar email - {contact.Email}");
                        contact.Email = Console.ReadLine();
                        break;
                }

                Console.WriteLine("\n**Parâmetros editados com sucesso!**");
                Console.ReadKey();

            }
            else
            {
                Console.WriteLine("\n**Usuário não encontrado!**");
            }
        }

        static int MenuEditar()
        {
            int op;

            do
            {
                Console.WriteLine("\nEditar:");
                Console.WriteLine("1 - Nome");
                Console.WriteLine("2 - Telefone(s)");
                Console.WriteLine("3 - Endereço");
                Console.WriteLine("4 - Email");
                op = int.Parse(Console.ReadLine());
            }while(op < 1 || op > 4);

            Console.Clear();
            return op;
        }

        static void PrintByName(List<Contact> contacts, string name)
        {
            bool find = false;

            foreach (Contact contact in contacts)
            {
                if (contact.Name == name)
                {
                    Console.WriteLine($"Nome: {contact.Name}");
                    Console.WriteLine();
                    Console.WriteLine($"Telefones");

                    int cont = 1;
                    foreach(Phone phone in contact.PhoneList)
                    {
                        Console.WriteLine($"\tT{cont} >> {phone.Number}");
                        cont++;
                    }

                    Adress auxAdress = contact.Adress;
                    Console.WriteLine();
                    Console.WriteLine("Endereço");
                    Console.WriteLine($"\tCEP: {auxAdress.PostalCode}");
                    Console.WriteLine($"\tCidade: {auxAdress.Locality}, {auxAdress.State}");
                    Console.WriteLine($"\tLogradouro: {auxAdress.PublicPlaceType} {auxAdress.PublicPlace}");
                    Console.WriteLine($"\tNumero: {auxAdress.Number}");
                    Console.WriteLine($"\tBairro: {auxAdress.Neighborhood}");
                    Console.WriteLine($"\tComplemento: {auxAdress.Complement}");

                    Console.WriteLine();
                    Console.WriteLine($"Email: {contact.Email}");

                    find = true;
                    break;
                }
            }

            if (!find)
            {
                Console.WriteLine("\n**Usuário não encontrado!**");
            }

        }

        static void PrintAll(List<Contact> contacts)
        {
            bool isEmpty = true;
            Console.Clear();
            foreach (Contact contact in contacts)
            {
                Console.WriteLine("\n====================================\n");
                PrintByName(contacts, contact.Name);
                isEmpty = false;
            }

            if(isEmpty)
            {
                Console.WriteLine("\n**Lista Vazia!**");
            }
            Console.ReadKey();
        }
    }
}
