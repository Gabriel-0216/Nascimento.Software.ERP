using Domain.Value_Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Client
{
    public class Buyer : Entity
    {

        public bool SetName(string firstName, string? lastName = null) 
        {
            if (string.IsNullOrEmpty(firstName))
            {
                return false;
            }
            if (string.IsNullOrEmpty(lastName)) name = new Name(firstName, null);

            name = new Name(firstName, lastName);

            return true;
        }
        public bool AddCellphone(string Cellphone)
        {
            if (string.IsNullOrEmpty(Cellphone))
            {
                return false;
            }
            CellPhoneNumbers = new List<Number>();
            CellPhoneNumbers.Add(new Number(Cellphone));
            return true;
        }
        public bool AddEmail(string Email)
        {
            if (string.IsNullOrWhiteSpace(Email))
            {
                return false;
            }
            Emails = new List<Email>();
            Emails.Add(new Email(Email));
            return true;
        }
        public bool SetCPF(string CPF)
        {
            if (string.IsNullOrWhiteSpace(CPF))
            {
                return false;
            }
            this.CPF = CPF;
            return true;
        }
        public bool SetAddress(string street, string? number, string? city, string? state, string? zipcode)
        {
            Address = new Address();
            Address.Street = street;
            if(number !=null) Address.Number = number;
            if(city !=null) Address.City = city;
            if(state !=null) Address.State = state;
            if (zipcode != null) Address.ZipCode = zipcode;

            return true;
        }
        public Name name { get; private set; }
        public Address Address { get; set; }
        public string? CPF { get; private set; }
        public List<Number>? CellPhoneNumbers { get; private set; }
        public List<Email>? Emails { get; private set; }

    }

}
