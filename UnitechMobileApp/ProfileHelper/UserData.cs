using System;
using System.Collections.Generic;
using System.Text;

namespace UnitechMobileApp.ProfileHelper
{
    public class UserData
    {
        public string FirstName
        {
            get
            {
                return FirstName;
            }
            set
            {
                if(FirstName != value)
                {
                    FirstName = value;
                }
            }
        }

        public string SecondName
        {
            get
            {
                return SecondName;
            }
            set
            {
                if (SecondName != value)
                {
                    SecondName = value;
                }
            }
        }
        public string ThirdName
        {
            get
            {
                return ThirdName;
            }
            set
            {
                if (ThirdName != value)
                {
                    ThirdName = value;
                }
            }
        }
    }
}
