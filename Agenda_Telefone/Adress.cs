using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda_Telefone
{
    internal class Adress
    {
        public string PostalCode { get; set; }
        public string Locality { get; set; }
        public string State { get; set; }
        public string PublicPlace { get; set; }
        public string PublicPlaceType { get; set; }
        public string Neighborhood { get; set; }
        public int Number { get; set; }
        public string Complement { get; set; }

        public Adress(string postalCode, string locality, string state, string publicPlace, string publicPlaceType, string neighborhood, int number, string complement)
        {
            this.PostalCode = postalCode;
            this.Locality = locality;
            this.State = state;
            this.PublicPlace = publicPlace;
            this.PublicPlaceType = publicPlaceType;
            this.Neighborhood = neighborhood;
            this.Number = number;
            this.Complement = complement;
        }

        public override string? ToString()
        {
            /*string valor = "\n* Endereço\n" +
                    $"CEP............: {cep}\n" +
                    $"Localidade.....: {locality}\n" +
                    $"UF.............: {state}\n" +
                    $"Logradouro.....: {publicPlaceType} {publicPlace}\n" +
                    $"Numero.........: {number}\n" +
                    $"Bairro.........: {neighborhood}\n";
            if (complement != "")
            {
                valor += $"Complemento.......: {complement}";
            }*/

            return $"{PostalCode};{Locality};{State};{PublicPlaceType};{PublicPlace};{Number};{Neighborhood}";
        }
    }
}
