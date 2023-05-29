using BY.Store.Application.Dtos.Custom.Basket;
using FluentValidation;

namespace BY.Store.Application.Validations.Fluent
{
    public class AddProductToBasketDtoValidator : AbstractValidator<AddProductToBasketDto>
    {
        public AddProductToBasketDtoValidator()
        {
            RuleFor(item => item.ProductId)
                .NotEmpty().WithMessage("{PropertyName} boş olamaz.")
                .NotNull().WithMessage("{PropertyName} boş olamaz.")
                .GreaterThan(0).WithMessage("{PropertyName} alanı 0'dan büyük olmalıdır.");

            RuleFor(item => item.Quantity)
                .NotEmpty().WithMessage("{PropertyName} boş olamaz.")
                .NotNull().WithMessage("{PropertyName} boş olamaz.")
                .GreaterThan(0).WithMessage("{PropertyName} alanı 0'dan büyük olmalıdır.");
        }
    }
}
