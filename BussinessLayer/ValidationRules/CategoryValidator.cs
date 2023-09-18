using EntityLayer.Concrete;
using FluentValidation;

namespace BussinessLayer.ValidationRules
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Kategori Adı Boş Olamaz");
            RuleFor(x => x.Name).MinimumLength(3).WithMessage("Kategori Adı En Az 3 Karakter Olmalıdır");
            RuleFor(x => x.Name).MaximumLength(20).WithMessage("Kategori Adı En Fazla 20 Karakter Olmalıdır");

            RuleFor(x => x.Description).NotEmpty().WithMessage("Kategori Açıklaması Boş Olamaz");
        }
    }
}
