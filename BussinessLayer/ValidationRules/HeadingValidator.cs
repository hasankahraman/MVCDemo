using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.ValidationRules
{
    public class HeadingValidator : AbstractValidator<Heading>
    {
        public HeadingValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Başlık Adı Boş Olamaz");
            RuleFor(x => x.Name).MinimumLength(2).WithMessage("Başlık Adı En Az 2 Karakter Olmalıdır");
            RuleFor(x => x.Name).MaximumLength(50).WithMessage("Başlık Adı En Fazla 50 Karakter Olmalıdır");
        }
    }
}
