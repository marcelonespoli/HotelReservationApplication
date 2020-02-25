using FluentValidation.Results;
using HR.Domain.Core.Notifications;
using HR.Domain.Interfaces;
using MediatR;

namespace HR.Domain.Handlers
{
    public abstract class CommandHandler
    {
        private readonly IUnitOfWork _uow;
        private readonly IMediatorHandler _mediator;
        private readonly DomainNotificationHandler _notifications;

        public CommandHandler(
            IUnitOfWork uow,
            IMediatorHandler mediator,
            INotificationHandler<DomainNotification> notifications)
        {
            _uow = uow;
            _mediator = mediator;
            _notifications = (DomainNotificationHandler)notifications;
        }

        protected void NotifyValidationError(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                _mediator.PublishEvent(new DomainNotification(error.PropertyName, error.ErrorMessage));
            }
        }

        protected bool Commit()
        {
            if (_notifications.HasNotifications()) return false;
            if (_uow.Commit()) return true;

            _mediator.PublishEvent(new DomainNotification("Commit", "Occurred an error to save the data in the database"));
            return false;
        }
    }
}
