
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
    [Route("api/Event")]
    [Authorize]
    [ServiceFilter(typeof(IApiActionFilter))]
    public partial class EventController
        : BaseApiController<BlueLight.Data.Models.Event, EventDtoGen, BlueLight.Data.AppDbContext>
    {
        public EventController(CrudContext<BlueLight.Data.AppDbContext> context) : base(context)
        {
            GeneratedForClassViewModel = context.ReflectionRepository.GetClassViewModel<BlueLight.Data.Models.Event>();
        }

        [HttpGet("get/{id}")]
        [Authorize]
        public virtual Task<ItemResult<EventDtoGen>> Get(
            System.Guid id,
            DataSourceParameters parameters,
            IDataSource<BlueLight.Data.Models.Event> dataSource)
            => GetImplementation(id, parameters, dataSource);

        [HttpGet("list")]
        [Authorize]
        public virtual Task<ListResult<EventDtoGen>> List(
            ListParameters parameters,
            IDataSource<BlueLight.Data.Models.Event> dataSource)
            => ListImplementation(parameters, dataSource);

        [HttpGet("count")]
        [Authorize]
        public virtual Task<ItemResult<int>> Count(
            FilterParameters parameters,
            IDataSource<BlueLight.Data.Models.Event> dataSource)
            => CountImplementation(parameters, dataSource);

        [HttpPost("save")]
        [Authorize]
        public virtual Task<ItemResult<EventDtoGen>> Save(
            [FromForm] EventDtoGen dto,
            [FromQuery] DataSourceParameters parameters,
            IDataSource<BlueLight.Data.Models.Event> dataSource,
            IBehaviors<BlueLight.Data.Models.Event> behaviors)
            => SaveImplementation(dto, parameters, dataSource, behaviors);

        [HttpPost("bulkSave")]
        [Authorize]
        public virtual Task<ItemResult<EventDtoGen>> BulkSave(
            [FromBody] BulkSaveRequest dto,
            [FromQuery] DataSourceParameters parameters,
            [FromServices] IDataSourceFactory dataSourceFactory,
            [FromServices] IBehaviorsFactory behaviorsFactory)
            => BulkSaveImplementation(dto, parameters, dataSourceFactory, behaviorsFactory);

        [HttpPost("delete/{id}")]
        [Authorize]
        public virtual Task<ItemResult<EventDtoGen>> Delete(
            System.Guid id,
            IBehaviors<BlueLight.Data.Models.Event> behaviors,
            IDataSource<BlueLight.Data.Models.Event> dataSource)
            => DeleteImplementation(id, new DataSourceParameters(), dataSource, behaviors);
    }
}
