using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectAddressbook.Model
{
    public class GroupData
    {
        public string gName;
        public string gHeader;
        public string gFooter;

        public GroupData(string gName, string gHeader, string gFooter)
        {
            this.gName = gName;
            this.gHeader = gHeader;
            this.gFooter = gFooter;

        }

        public string GroupName
        {
            get
            {
                return gName;
            }
            set
            {
                gName = value;
            }
        }

        public string GroupHeader
        {
            get
            {
                return gHeader;
            }
            set
            {
                gHeader = value;
            }
        }

        public string GroupFooter
        {
            get
            {
                return gFooter;
            }
            set
            {
                gFooter = value;
            }
        }
    }
}
