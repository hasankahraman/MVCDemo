using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.ValidationRules
{
    public class MessageValidator : AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(x => x.ReceiverMail).NotEmpty().WithMessage("Alıcı Adı Boş Olamaz");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu Adı Boş Olamaz");
            RuleFor(x => x.Content).NotEmpty().WithMessage("Mesaj İçeriği Boş Olamaz");

            RuleFor(x => x.ReceiverMail).EmailAddress();
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("Konu Başlığı En Az 3 Karakter Olmalıdır");
            RuleFor(x => x.Content).MinimumLength(3).WithMessage("Kategori Adı En Az 3 Karakter Olmalıdır");

        }
    }
}
