using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootTrap.Common
{
    public static class ModelValidationConstants
    {
        public static class UserConstants
        {
            public const int FirstNameMinLength = 3;
            public const int FirstNameMaxLength = 30;

            public const int LastNameMinLength = 3;
            public const int LastNameMaxLength = 30;

            public const int CountryMaxLength = 100;
            public const int CountryMinLength = 3;

            public const int CityMaxLength = 200;
            public const int CityMinLength = 3;

            public const int AddressMaxLength = 200;
            public const int AddressMinLength = 5;

            public const int EmailMaxLength = 50;
            public const int EmailMinLength = 5;

            public const int PasswordMaxLength = 20;
            public const int PasswordMinLength = 5;

        }

        public static class CategoryConstants
        {
            public const int NameMaxLength = 50;
            public const int NameMinLength = 3;
        }

        public static class ShoeConstants
        {
            public const int NameMaxLength = 50;
            public const int NameMinLength = 3;

            public const int DescriptionMaxLength = 250;
            public const int DescriptionMinLength = 3;
        }

        public static class OrderConstants
        {
            public const int DeliveryAddressMaxLength = 100;
            public const int DelicaryAddressMinLength = 3;
        }

        public static class PaymentConstants
        {
            public const int CardNumberMinLength = 4;
            public const int CardNumberMaxLength = 25;

            public const int CardHolderMinLength = 3;
            public const int CardHolderMaxLength = 20;

            public const int SecurityCodeMinLength = 3;
            public const int SecurityCodeMaxLength = 8;
        }
    }
}
