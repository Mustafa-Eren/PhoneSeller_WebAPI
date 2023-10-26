using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PhoneSeller_WebAPI.Controllers
{

    public class BaseController : ControllerBase
    {
        private IMediator _mediator;

        protected IMediator Mediator
        {
            get
            {
                return _mediator ?? (_mediator = HttpContext.RequestServices.GetService<IMediator>());
            }
        }
    }
}
