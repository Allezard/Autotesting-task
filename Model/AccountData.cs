﻿using System;
using System.Text;

namespace ProjectAddressbook.Model
{
    public class AccountData
    {
        public string username;
        public string userpassword;

        public AccountData(string username, string userpassword)
        {
            this.username = username;
            this.userpassword = userpassword;
        }

        public string Username
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
            }
        }
        public string Userpassword
        {
            get
            {
                return userpassword;
            }
            set
            {
                userpassword = value;
            }
        }

    }
}

