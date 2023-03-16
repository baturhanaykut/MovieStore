using FluentValidation;
using MovieStore.Models.ViewModels;

namespace MovieStore.Validation
{
    public class StarringValidation : AbstractValidator<StarringVM>
    {
        public StarringValidation()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("First Name cannnot be null")
                .MaximumLength(30).WithMessage("The maxiumum lengt of first name can be 30 characters");
                


            RuleFor(x => x.LastName).NotEmpty().WithMessage("Last Name cannnot be null")
                .MaximumLength(30).WithMessage("The maxiumum lengt of first name can be 30 characters");
               

            
                

        }
    }
}
