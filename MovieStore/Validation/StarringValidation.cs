using FluentValidation;
using MovieStore_Application.Models.DTOs.StarringDTOS;

namespace MovieStore.Validation
{
    public class StarringValidation : AbstractValidator<CreateStarringDTO>
    {
        //public StarringValidation()
        //{
        //    RuleFor(x => x.FirstName).NotEmpty().WithMessage("first name cannnot be null")
        //        .MaximumLength(30).WithMessage("the maxiumum lengt of first name can be 30 characters");



        //    RuleFor(x => x.LastName).NotEmpty().WithMessage("last name cannnot be null")
        //        .MaximumLength(30).WithMessage("the maxiumum lengt of first name can be 30 characters");

        //}
    } 
    public class StarringValidation1 : AbstractValidator<UpdateStarringDTO>
    {
        //public StarringValidation1()
        //{
        //    RuleFor(x => x.FirstName).NotEmpty().WithMessage("first name cannnot be null")
        //        .MaximumLength(30).WithMessage("the maxiumum lengt of first name can be 30 characters");



        //    RuleFor(x => x.LastName).NotEmpty().WithMessage("last name cannnot be null")
        //        .MaximumLength(30).WithMessage("the maxiumum lengt of first name can be 30 characters");

        //}
    }
}
