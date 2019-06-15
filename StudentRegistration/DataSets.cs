using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistration
{
    class DataSets
    {
        public class Users
        {
            public string userName, password, fName, lName, pNo;
        }
        public class intake
        {
            public string code;
            public DateTime date;
        }
        public class student
        {
            public string id, intake, fname, lname, pno, address;
            public DateTime bd;
        }
    }
}
