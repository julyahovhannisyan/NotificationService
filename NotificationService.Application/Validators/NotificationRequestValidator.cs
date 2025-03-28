using FluentValidation;
using NotificationService.Application.DTOs;

namespace NotificationService.Api.Validators
{
    public class NotificationRequestValidator : AbstractValidator<NotificationRequestDto>
    {
        public NotificationRequestValidator()
        {
            RuleFor(x => x.Message)
                .NotEmpty().WithMessage("Message is required.");

            RuleFor(x => x.Type)
                .IsInEnum().WithMessage("Invalid notification type.");
        }
    }
}
