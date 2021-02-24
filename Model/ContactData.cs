using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Text.RegularExpressions;

namespace ProjectAddressbook.Model
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;
        private string allEmails;

        public ContactData()
        {
            //FirstName = firstName;
            //LastName = lastName;
        }

        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return FirstName == other.FirstName
                && LastName == other.LastName;
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return FirstName.CompareTo(other.FirstName);
        }

        public override int GetHashCode()
        {
            return (FirstName + " " + LastName).GetHashCode();
        }

        public override string ToString()
        {
            return "Имя и Фамилия: " + FirstName + " " + LastName;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string WorkPhone { get; set; }
        public string Email { get; set; }
        public string Email2 { get; set; }
        public string Email3 { get; set; }
        public string Id { get; set; }
        public string AllPhones
        {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanIp(HomePhone) + CleanIp(MobilePhone) + CleanIp(WorkPhone)).Trim();
                }
            }
            set
            {
                allPhones = value;
            }
        }

        public string AllEmails
        {
            get
            {
                if (allEmails != null)
                {
                    return allEmails;
                }
                else
                {
                    return (CleanIp(Email) + CleanIp(Email2) + CleanIp(Email3)).Trim();
                }
            }
            set
            {
                allEmails = value;
            }
        }

        private string CleanIp(string symbol)
        {
            if (symbol == null || symbol == "")
            {
                return "";
            }
            return Regex.Replace(symbol, "[ -()]", "") + "\r\n";
        }
    }
}
