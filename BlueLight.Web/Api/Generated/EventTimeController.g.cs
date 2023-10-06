
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
    [Route("api/EventTime")]
    [Authorize]
    [ServiceFilter(typeof(IApiActionFilter))]
    public partial class EventTimeController
        : BaseApiController<BlueLight.Data.Models.EventTime, EventTimeDtoGen, BlueLight.Data.AppDbContext>
    {
        public EventTimeController(CrudContext<BlueLight.Data.AppDbContext> context) : base(context)
        {
            GeneratedForClassViewModel = context.ReflectionRepository.GetClassViewModel<BlueLight.Data.Models.EventTime>();
        }

        [HttpGet("get/{id}")]
        [Authorize]
        public virtual Task<ItemResult<EventTimeDtoGen>> Get(
            System.Guid id,
            DataSourceParameters parameters,
            IDataSource<BlueLight.Data.Models.EventTime> dataSource)
            => GetImplementation(id, parameters, dataSource);

        [HttpGet("list")]
        [Authorize]
        public virtual Task<ListResult<EventTimeDtoGen>> List(
            ListParameters parameters,
            IDataSource<BlueLight.Data.Models.EventTime> dataSource)
            => ListImplementation(parameters, dataSource);

        [HttpGet("count")]
        [Authorize]
        public virtual Task<ItemResult<int>> Count(
            FilterParameters parameters,
            IDataSource<BlueLight.Data.Models.EventTime> dataSource)
            => CountImplementation(parameters, dataSource);

        [HttpPost("save")]
        [Authorize]
        public virtual Task<ItemResult<EventTimeDtoGen>> Save(
            [FromForm] EventTimeDtoGen dto,
            [FromQuery] DataSourceParameters parameters,
            IDataSource<BlueLight.Data.Models.EventTime> dataSource,
            IBehaviors<BlueLight.Data.Models.EventTime> behaviors)
            => SaveImplementation(dto, parameters, dataSource, behaviors);

        [HttpPost("bulkSave")]
        [Authorize]
        public virtual Task<ItemResult<EventTimeDtoGen>> BulkSave(
            [FromBody] BulkSaveRequest dto,
            [FromQuery] DataSourceParameters parameters,
            [FromServices] IDataSourceFactory dataSourceFactory,
            [FromServices] IBehaviorsFactory behaviorsFactory)
            => BulkSaveImplementation(dto, parameters, dataSourceFactory, behaviorsFactory);

        [HttpPost("delete/{id}")]
        [Authorize]
        public virtual Task<ItemResult<EventTimeDtoGen>> Delete(
            System.Guid id,
            IBehaviors<BlueLight.Data.Models.EventTime> behaviors,
            IDataSource<BlueLight.Data.Models.EventTime> dataSource)
            => DeleteImplementation(id, new DataSourceParameters(), dataSource, behaviors);
    }
}
