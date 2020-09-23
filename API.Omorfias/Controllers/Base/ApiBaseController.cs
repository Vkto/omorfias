using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Omorfias.AppServices.Dto.Base;
using API.Omorfias.Domain.Base.Events;
using API.Omorfias.Domain.Base.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Omorfias.Controllers.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiBaseController : ControllerBase
    {
        private IHandler<DomainNotification> _notifications { get; set; }

        public ApiBaseController(IHandler<DomainNotification> notifications)
        {
            _notifications = notifications;
        }

        public DataResultsDto<TEntity> ResponseResult<TEntity>(TEntity entity)
        {
            var results = new DataResultsDto<TEntity>() { Entity = entity };

            if (!_notifications.HasNotifications()) return results;

            ErrosHandle(results);

            return results;
        }

        public DataResultsDto<TEntity> ResponseResult<TEntity>(IEnumerable<TEntity> data)
        {
            var results = new DataResultsDto<TEntity>() { Data = data };

            results.Count = data != null ? data.Count() : 0;

            if (!_notifications.HasNotifications()) return results;

            ErrosHandle(results);

            return results;
        }

        private void ErrosHandle<TEntity>(DataResultsDto<TEntity> results)
        {
            foreach (var error in _notifications.GetValues())
            {
                results.Add(error.Value);
            }
        }
    }
}
