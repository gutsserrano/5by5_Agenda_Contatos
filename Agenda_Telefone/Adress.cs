using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda_Telefone
{
    internal class Adress
    {
        string cep;
        string locality;
        string state;
        string publicPlace;
        string publicPlaceType;
        string neighborhood;
        int number;
        string complement;

        public Adress(string cep, string locality, string state, string publicPlace, string publicPlaceType, string neighborhood, int number, string complement)
        {
            this.cep = cep;
            this.locality = locality;
            this.state = state;
            this.publicPlace = publicPlace;
            this.publicPlaceType = publicPlaceType;
            this.neighborhood = neighborhood;
            this.number = number;
            this.complement = complement;
        }

        public string GetCep()
        {
            return cep;
        }

        public string GetLocality()
        {
            return locality;
        }

        public string GetState()
        {
            return state;
        }

        public string GetPublicPlace()
        {
            return publicPlace;
        }

        public string GetPublicPlaceType()
        {
            return publicPlaceType;
        }

        public string GetNeighborhood()
        {
            return neighborhood;
        }

        public int GetNumber()
        {
            return number;
        }

        public string GetComplement()
        {
            return complement;
        }

        public override string? ToString()
        {
            string valor = "\n* Endereço\n" +
                    $"CEP............: {cep}\n" +
                    $"Localidade.....: {locality}\n" +
                    $"UF.............: {state}\n" +
                    $"Logradouro.....: {publicPlaceType} {publicPlace}\n" +
                    $"Numero.........: {number}\n" +
                    $"Bairro.........: {neighborhood}\n";
            if (complement != "")
            {
                valor += $"Complemento.......: {complement}";
            }

            return valor;
        }
    }
}
