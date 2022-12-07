using FluentValidation;

namespace lesson10_validation.Models.Validators
{
    public class ShowDataViewModelValidator : AbstractValidator<ShowDataViewModel>
    {
        public ShowDataViewModelValidator()
        {
            RuleFor(m => m.Year).Must(IsCurrentOrPastYear)
                .WithMessage("Year must be from 1 to current!");
        }

        private bool IsCurrentOrPastYear(int year)
        {
            var currentYear = DateTime.Now.Year;
            return year <= currentYear;
        }
    }
}
