
using BlueLight.Web.Models;
using IntelliTect.Coalesce;
using IntelliTect.Coalesce.Api;
using IntelliTect.Coalesce.Api.Behaviors;
using IntelliTect.Coalesce.Api.Controllers;
using IntelliTect.Coalesce.Api.DataSources;
using IntelliTect.Coalesce.Mapping;
using IntelliTect.Coalesce.Mapping.IncludeTrees;
using IntelliTect.Coalesce.Models;
using IntelliTect.Coalesce.TypeDefinition;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace BlueLight.Web.Api
{
    [Route("api/SignUpService")]
    [ServiceFilter(typeof(IApiActionFilter))]
    public partial class SignUpServiceController : Controller
    {
        protected ClassViewModel GeneratedForClassViewModel { get; }
        protected BlueLight.Data.Services.SignUpService Service { get; }
        protected CrudContext Context { get; }

        public SignUpServiceController(CrudContext context, BlueLight.Data.Services.SignUpService service)
        {
            GeneratedForClassViewModel = context.ReflectionRepository.GetClassViewModel<BlueLight.Data.Services.SignUpService>();
            Service = service;
            Context = context;
        }

        /// <summary>
        /// Method: CurrentEvents
        /// </summary>
        [HttpPost("CurrentEvents")]
        [AllowAnonymous]
        public virtual async Task<ItemResult<System.Collections.Generic.ICollection<EventDtoGen>>> CurrentEvents()
        {
            IncludeTree includeTree = null;
            var _mappingContext = new MappingContext(User);
            var _methodResult = await Service.CurrentEvents();
            var _result = new ItemResult<System.Collections.Generic.ICollection<EventDtoGen>>();
            _result.Object = _methodResult?.ToList().Select(o => Mapper.MapToDto<BlueLight.Data.Models.Event, EventDtoGen>(o, _mappingContext, includeTree)).ToList();
            return _result;
        }

        /// <summary>
        /// Method: Register
        /// </summary>
        [HttpPost("Register")]
        [AllowAnonymous]
        public virtual async Task<ItemResult<string>> Register(
            [FromForm(Name = "eventTimeId")] System.Guid eventTimeId,
            [FromForm(Name = "email")] string email,
            [FromForm(Name = "phone")] string phone,
            [FromForm(Name = "quantity")] int quantity,
            [FromForm(Name = "notes")] string notes)
        {
            var _params = new
            {
                eventTimeId = eventTimeId,
                email = email,
                phone = phone,
                quantity = quantity,
                notes = notes
            };

            if (Context.Options.ValidateAttributesForMethods)
            {
                var _validationResult = ItemResult.FromParameterValidation(
                    GeneratedForClassViewModel!.MethodByName("Register"), _params, HttpContext.RequestServices);
                if (!_validationResult.WasSuccessful) return new ItemResult<string>(_validationResult);
            }

            var _methodResult = await Service.Register(
                _params.eventTimeId,
                _params.email,
                _params.phone,
                _params.quantity,
                _params.notes
            );
            var _result = new ItemResult<string>();
            _result.Object = _methodResult;
            return _result;
        }
    }
}
