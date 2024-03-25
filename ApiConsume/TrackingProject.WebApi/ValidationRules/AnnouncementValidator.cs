using FluentValidation;
using TrackingProject.EntityLayer.Concrete;

namespace TrackingProject.WebApi.ValidationRules
{
    public class AnnouncementValidator:AbstractValidator<Announcement>
    {
        public AnnouncementValidator()
        {
            RuleFor(x => x.Content)
                .NotEmpty().WithMessage("İçerik boş olamaz.")
                .MaximumLength(250).WithMessage("İçerik en fazla 250 karakter olabilir.")
                .MinimumLength(20).WithMessage("İçerik en az 20 karakter uzunluğunda olmalıdır.");

            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Başlık boş olamaz.")
                .MaximumLength(100).WithMessage("Başlık en fazla 100 karakter olabilir.")
                .MinimumLength(5).WithMessage("Başlık en az 5 karakter uzunluğunda olmalıdır.");

            RuleFor(x => x.Date)
                .NotEmpty().WithMessage("Tarih boş olamaz.");

            RuleFor(x => x.TypeID)
                .NotEmpty().WithMessage("Tip ID boş olamaz.");

        }
    }
}
