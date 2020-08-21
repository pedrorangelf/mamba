using Mamba.Domain.Interfaces;
using Mamba.Domain.Notifications;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Linq;

namespace Mamba.API.Controllers
{
    [ApiController]
    public class MainController : ControllerBase
    {
        private readonly INotificator _notificator;
        private readonly IUser _user;

        protected MainController(INotificator notificator, IUser user)
        {
            _notificator = notificator;
            _user = user;

            UsuarioId = user.GetUserId();
            UsuarioAutenticado = user.IsAuthenticated();
        }

        protected int? UsuarioId { get; set; }
        protected bool UsuarioAutenticado { get; set; }


        protected IActionResult CustomResponse(object result = null)
        {
            if (!OperacaoValida())
            {
                return BadRequest(new
                {
                    success = false,
                    errors = _notificator.GetNotifications().Select(n => n.Message)
                });
            }

            return Ok(new
            {
                success = true,
                data = result
            });
        }

        protected IActionResult CustomResponse(ModelStateDictionary modelState)
        {
            if (!modelState.IsValid) NotificarErroModelState(modelState);

            return CustomResponse();
        }


        protected bool OperacaoValida()
        {
            return !_notificator.HasNotification();
        }

        protected void NotificarErroModelState(ModelStateDictionary modelState)
        {
            foreach (var erro in modelState.Values.SelectMany(m => m.Errors))
                NotificarErro(erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message);
        }

        protected void NotificarErro(string mensagem)
        {
            _notificator.Handle(new Notification(mensagem));
        }

    }
}
