using System.ComponentModel.DataAnnotations;

namespace SecurityConcerns.Attributes;

public class NotInFutureDateAttribute : ValidationAttribute {
    // used when no custom error message is used when attribute is used
    public NotInFutureDateAttribute() : base("The {0} cannot be in the future!") 
    {
    }
    

    public NotInFutureDateAttribute(string errorMessage) : base(errorMessage) 
    {
    }

    public override bool IsValid(object? value) {
        if (value == null) {
            return true; // Let [Required] handle null validation
        }

        if (value is DateTime dateTime) {
            return dateTime <= DateTime.Now;
        }
        return false; // Invalid is not a datetime
    }

    public override FormatErrorMessage(string message) {
        return string.Format(ErrorMessageString, message);
    }
}