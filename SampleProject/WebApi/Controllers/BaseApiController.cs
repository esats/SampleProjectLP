using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    public abstract class BaseApiController : ApiController
    {
        public HttpResponseMessage Found(object obj)
        {
            return ControllerContext.Request.CreateResponse(HttpStatusCode.OK, obj);
        }

        public HttpResponseMessage Found()
        {
            return ControllerContext.Request.CreateResponse(HttpStatusCode.OK);
        }

        public HttpResponseMessage DoesNotExist()
        {
            return ControllerContext.Request.CreateResponse(HttpStatusCode.NotFound);
        }

        public HttpResponseMessage DoesNotExistWithMessage(string message)
        {
            return ControllerContext.Request.CreateResponse(HttpStatusCode.NotFound, new { message });
        }

        public HttpResponseMessage AlreadyExists()
        {
            return ControllerContext.Request.CreateResponse(HttpStatusCode.Conflict);
        }

        public HttpResponseMessage ValidationFailed()
        {
            var errors = ModelState
                .Where(x => x.Value.Errors.Count > 0)
                .ToDictionary(
                    x => x.Key,
                    x => x.Value.Errors.Select(e => e.ErrorMessage).ToList()
                );

            return ControllerContext.Request.CreateResponse(HttpStatusCode.BadRequest, new { errors });
        }
    }
}