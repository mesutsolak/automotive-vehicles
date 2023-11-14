namespace AutomotiveBrands.Lib.Validation.Infrastructure.Validators
{
    public class AutomotiveBrandsApiValidator<TValidator> : AbstractValidator<TValidator>
    {
        protected bool ValidateChassis(string chassis)
        {
            if (string.IsNullOrWhiteSpace(chassis))
                return false;

            return RegularExpressions.Chassis.IsMatch(chassis);
        }
        protected bool ValidatePlate(string plate)
        {
            if (string.IsNullOrWhiteSpace(plate))
                return false;

            return RegularExpressions.Plate.IsMatch(plate);
        }
        protected bool ValidateEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            return RegularExpressions.Email.IsMatch(email);
        }
        protected bool ValidateAttachmentFile(byte[] attachmentFile)
        {
            return attachmentFile.Length > 0;
        }
        protected bool ValidateTcNumber(string tcNumber)
        {
            if (string.IsNullOrWhiteSpace(tcNumber))
                return false;

            return RegularExpressions.TcNumber.IsMatch(tcNumber);
        }
        protected bool ValidatePassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                return false;

            return RegularExpressions.Password.IsMatch(password);
        }
        protected bool ValidateEmails(string contactFormAuthorizedMails)
        {
            if (!contactFormAuthorizedMails.Contains(';'))
                return ValidateEmail(contactFormAuthorizedMails);

            var emailAddresss = contactFormAuthorizedMails.Split(';');
            foreach (var email in emailAddresss)
            {
                if (!ValidateEmail(email))
                    return false;
            }

            return true;
        }
        protected bool ValidatePhoneNumber(string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
                return false;

            return RegularExpressions.PhoneNumber.IsMatch(phoneNumber);
        }
    }
}
