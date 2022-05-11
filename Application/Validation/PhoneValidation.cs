using PhoneNumbers;

namespace TravelCompany.Application.Validation
{
    public class PhoneValidation
    {
        public static bool IsValidNumber(string? phoneNumber)
        {
            if (phoneNumber == null)
                return false;

            phoneNumber = phoneNumber[0] == '+' ? phoneNumber : $"+{phoneNumber}";
            bool result;

            try
            {
                var phoneNumberUtil = PhoneNumberUtil.GetInstance();
                var numberProto = phoneNumberUtil.Parse(phoneNumber, null);

                result = phoneNumberUtil.IsPossibleNumberForType(numberProto, PhoneNumberType.FIXED_LINE_OR_MOBILE);
            }
            catch
            {
                return false;
            }
            return result;
        }
    }
}
