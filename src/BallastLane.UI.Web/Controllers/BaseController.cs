﻿using BallastLane.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BallastLane.UI.Web.Controllers;

public class BaseController : Controller
{
    private readonly DomainNotificationHandler _notifications;

    public BaseController(INotificationHandler<DomainNotification> notifications)
    {
        _notifications = (DomainNotificationHandler)notifications;
    }

    public bool IsValidOperation()
    {
        return (!_notifications.HasNotifications());
    }
}
