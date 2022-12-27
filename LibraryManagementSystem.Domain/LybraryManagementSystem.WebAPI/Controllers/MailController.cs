using LybraryManagementSystem.Application.Interface;
using LybraryManagementSystem.Application.Models.Notification;
using Microsoft.AspNetCore.Mvc;

namespace LybraryManagementSystem.WebAPI.Controllers
{
    public class MailController : Controller
    {
        private readonly INotificationService _notificationService;

        public MailController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpPost]
        public async Task<IActionResult> SendMail(NotificationModel notificationModel)
        {
            try
            {
                await _notificationService.SendEmailAsync(notificationModel);
                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
