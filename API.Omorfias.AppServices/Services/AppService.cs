using API.Omorfias.Data.Interfaces;
using API.Omorfias.Domain.Base.Events;
using API.Omorfias.Domain.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.Omorfias.AppServices.Services
{
    public class AppService
    {
        private readonly IUnitOfWork _unitOfWork;

        protected readonly IHandler<DomainNotification> _notifications;

        public AppService(IUnitOfWork unitOfWork, IHandler<DomainNotification> notificacao)
        {
            _unitOfWork = unitOfWork;

            _notifications = notificacao;
        }
        public bool Commit()
        {
            if (_notifications.HasNotifications()) return false;

            _unitOfWork.Commit();

            return true;
        }
    }
}
