using CTrack.Client.Models;
using FluentValidation;

namespace CTrack.Client.Validators
{
    public class RegisterFormModelValidator : AbstractValidator<RegisterFormModel>
    {
        public RegisterFormModelValidator()
        {
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Password).NotEmpty()
                .MinimumLength(8).WithMessage("Password must be at least 8 characters long.")
                .Matches(@"[A-Z]+").WithMessage("must contain at leas one uppercase letter.")
                .Matches(@"[a-z]+").WithMessage("must contain at least one lowercase letter.")
                .Matches(@"[0-9]+")
                .Matches(@"[\@\!\?\=\*\.\-\^\°\:\.\,\;]").WithMessage("must contain at least one of the following characters (@!?=*.-^°:.,;)");
            RuleFor(x => x.Password2).NotEmpty().MinimumLength(8)
            .Equal(_ => _.Password).WithMessage("Password and Confirm Password have to Match");
        }

        public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
        {
            var result = await ValidateAsync(ValidationContext<RegisterFormModel>.CreateWithOptions((RegisterFormModel)model, x => x.IncludeProperties(propertyName)));
            Console.WriteLine($"ISVALID {result.IsValid}");
            if (result.IsValid)
                return Array.Empty<string>();
            var tmp = result.Errors.Select(e => e.ErrorMessage);
            foreach (var x in tmp)
            {
                Console.WriteLine(x);
            }
            return result.Errors.Select(e => e.ErrorMessage);
        };

    }
}
