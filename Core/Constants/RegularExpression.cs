namespace oc.TSB.Core.Constants;

public static class RegularExpression : object
{
    static RegularExpression()
    {
    }

    public const string NationalCode = @"^\d{10}$";

    public const string PostalCode = @"^\d{10}$";

    public const string PhoneNumber = @"^@@\d{11}$";

    public const string CellPhoneNumber = @"^00\d{11,12}$"; // برای سایت‌های چند ملیتی
   //public const string CellPhoneNumber = @"^00\d{12}$"; // برای ایران

    public const string Password = @"^[a-zA-Z0-9_!@#$%^&]{8,20}$";

    public const string EmailAddress =
              @"^[a-zA-Z0-9_.-]+@[a-zA-Z0-9_.-]+$";

    public const string Iban = @"^(?:IR)(?=.{24}$)[0-9]*$";

    public const string SpecialCode = @"^\d+$"; //be a number

    public const string BranchCode = @"^\d+$";  //be a number

    //public const string AToZDigitsUnderline = @"^[a-zA-Z0-9_]*$";
    public const string AToZDigitsUnderline = @"^[a-zA-Z][a-zA-Z0-9_]*$";

    public const string IP =
    @"^((25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$";
}
