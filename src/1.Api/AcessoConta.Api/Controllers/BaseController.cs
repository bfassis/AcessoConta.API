using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcessoConta.Api.Controllers
{
    public abstract class BaseController : ControllerBase
    {
    //    private readonly INotification _notification;

    //    protected BaseController(INotification notification)
    //    {
    //        _notification = notification;
    //    }

    //    private bool IsValidOperation()
    //    {
    //        return (!_notification.HasNotifications);
    //    }

    //    protected new ActionResult Response(BaseResponse response)
    //    {
    //        if (IsValidOperation())
    //        {
    //            if (response == null)
    //                return NoContent();

    //            return Ok(response);
    //        }
    //        else
    //        {
    //            response.Success = false;
    //            response.Errors = _notification.Notifications.Select(error => error);
    //            switch (_notification.Notifications.LastOrDefault().NotificationType)
    //            {
    //                case ENotificationType.InternalServerError:
    //                    return StatusCode((int)HttpStatusCode.InternalServerError, response);
    //                case ENotificationType.BusinessRules:
    //                    return Conflict(response);
    //                default:
    //                    return BadRequest(response);
    //            }
    //        }
    //    }

    //    /// <summary>
    //    /// Retorna URL consulta item criado
    //    /// </summary>
    //    /// <param name="response"></param>
    //    /// <returns></returns>
    //    protected new IActionResult Response(object response = null)
    //    {

    //        if (IsValidOperation())
    //        {
    //            if (response == null)
    //                return NoContent();

    //            return Ok(new
    //            {
    //                success = true,
    //                data = response
    //            });
    //        }

    //        return BadRequest(new
    //        {
    //            success = false,
    //            errors = _notification.Notifications.Select(error => error)
    //        });

    //    }

    //    /// <summary>
    //    /// Retorna URL consulta item criado
    //    /// </summary>
    //    /// <param name="id"></param>
    //    /// <param name="response"></param>
    //    /// <returns></returns>
    //    protected new IActionResult Response(int? id = null, object response = null)
    //    {
    //        if (IsValidOperation())
    //        {
    //            if (id == null)
    //                return Ok(new
    //                {
    //                    success = true,
    //                    data = response
    //                });

    //            return CreatedAtAction("Get", new { id },
    //                new
    //                {
    //                    success = true,
    //                    data = response ?? new object()
    //                });
    //        }

    //        return BadRequest(new
    //        {
    //            success = false,
    //            errors = _notification.Notifications.Select(error => error)
    //        });

    //    }
    }
}
