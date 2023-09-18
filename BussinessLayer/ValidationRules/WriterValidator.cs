using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.ValidationRules
{
    public class WriterValidator:AbstractValidator<Writer>
    {
        public WriterValidator() {

            RuleFor(x => x.Name).NotEmpty().WithMessage("Yazar Adı Boş Olamaz");
            RuleFor(x => x.Name).MinimumLength(2).WithMessage("Yazar Adı En Az 2 Karakter Olmalıdır");
            RuleFor(x => x.Name).MaximumLength(50).WithMessage("Yazar Adı En Fazla 50 Karakter Olmalıdır");

            RuleFor(x => x.Surname).NotEmpty().WithMessage("Yazar Soyadı Boş Olamaz");
            RuleFor(x => x.Surname).MinimumLength(3).WithMessage("Yazar Soyadı En Az 3 Karakter Olmalıdır");
            RuleFor(x => x.Surname).MaximumLength(50).WithMessage("Yazar Soyadı En Fazla 50 Karakter Olmalıdır");

            RuleFor(x => x.Email).NotEmpty().WithMessage("Yazar E Posta Adresi Boş Olamaz");
            RuleFor(x => x.Email).MinimumLength(7).WithMessage("Yazar E Posta Adresi En Az 7 Karakter Olmalıdır");
            RuleFor(x => x.Email).MaximumLength(50).WithMessage("Yazar E Posta Adresi En Fazla 50 Karakter Olmalıdır");

            RuleFor(x => x.Title).NotEmpty().WithMessage("Yazar Ünvanı Boş Olamaz");
            RuleFor(x => x.Title).MinimumLength(3).WithMessage("Yazar Ünvanı En Az 3 Karakter Olmalıdır");
            RuleFor(x => x.Title).MaximumLength(50).WithMessage("Yazar Ünvanı En Fazla 50 Karakter Olmalıdır");

        }
    }
}
