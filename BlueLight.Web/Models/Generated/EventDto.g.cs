using IntelliTect.Coalesce;
using IntelliTect.Coalesce.Mapping;
using IntelliTect.Coalesce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace BlueLight.Web.Models
{
    public partial class EventDtoGen : GeneratedDto<BlueLight.Data.Models.Event>
    {
        public EventDtoGen() { }

        private System.Guid? _EventId;
        private string _Name;
        private System.DateTime? _Date;
        private string _Description;
        private System.Collections.Generic.ICollection<BlueLight.Web.Models.EventTimeDtoGen> _EventTimes;

        public System.Guid? EventId
        {
            get => _EventId;
            set { _EventId = value; Changed(nameof(EventId)); }
        }
        public string Name
        {
            get => _Name;
            set { _Name = value; Changed(nameof(Name)); }
        }
        public System.DateTime? Date
        {
            get => _Date;
            set { _Date = value; Changed(nameof(Date)); }
        }
        public string Description
        {
            get => _Description;
            set { _Description = value; Changed(nameof(Description)); }
        }
        public System.Collections.Generic.ICollection<BlueLight.Web.Models.EventTimeDtoGen> EventTimes
        {
            get => _EventTimes;
            set { _EventTimes = value; Changed(nameof(EventTimes)); }
        }

        /// <summary>
        /// Map from the domain object to the properties of the current DTO instance.
        /// </summary>
        public override void MapFrom(BlueLight.Data.Models.Event obj, IMappingContext context, IncludeTree tree = null)
        {
            if (obj == null) return;
            var includes = context.Includes;

            this.EventId = obj.EventId;
            this.Name = obj.Name;
            this.Date = obj.Date;
            this.Description = obj.Description;
            var propValEventTimes = obj.EventTimes;
            if (propValEventTimes != null && (tree == null || tree[nameof(this.EventTimes)] != null))
            {
                this.EventTimes = propValEventTimes
                    .OrderBy(f => f.Name)
                    .Select(f => f.MapToDto<BlueLight.Data.Models.EventTime, EventTimeDtoGen>(context, tree?[nameof(this.EventTimes)])).ToList();
            }
            else if (propValEventTimes == null && tree?[nameof(this.EventTimes)] != null)
            {
                this.EventTimes = new EventTimeDtoGen[0];
            }

        }

        /// <summary>
        /// Map from the current DTO instance to the domain object.
        /// </summary>
        public override void MapTo(BlueLight.Data.Models.Event entity, IMappingContext context)
        {
            var includes = context.Includes;

            if (OnUpdate(entity, context)) return;

            if (ShouldMapTo(nameof(EventId))) entity.EventId = (EventId ?? entity.EventId);
            if (ShouldMapTo(nameof(Name))) entity.Name = Name;
            if (ShouldMapTo(nameof(Date))) entity.Date = (Date ?? entity.Date);
            if (ShouldMapTo(nameof(Description))) entity.Description = Description;
        }

        /// <summary>
        /// Map from the current DTO instance to a new instance of the domain object.
        /// </summary>
        public override BlueLight.Data.Models.Event MapToNew(IMappingContext context)
        {
            var entity = new BlueLight.Data.Models.Event();
            MapTo(entity, context);
            return entity;
        }
    }
}
