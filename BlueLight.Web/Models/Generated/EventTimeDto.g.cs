using IntelliTect.Coalesce;
using IntelliTect.Coalesce.Mapping;
using IntelliTect.Coalesce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace BlueLight.Web.Models
{
    public partial class EventTimeDtoGen : GeneratedDto<BlueLight.Data.Models.EventTime>
    {
        public EventTimeDtoGen() { }

        private System.Guid? _EventTimeId;
        private System.Guid? _EventId;
        private BlueLight.Web.Models.EventDtoGen _Event;
        private string _Name;
        private System.Collections.Generic.ICollection<BlueLight.Web.Models.EventRegistrationDtoGen> _EventRegistrations;

        public System.Guid? EventTimeId
        {
            get => _EventTimeId;
            set { _EventTimeId = value; Changed(nameof(EventTimeId)); }
        }
        public System.Guid? EventId
        {
            get => _EventId;
            set { _EventId = value; Changed(nameof(EventId)); }
        }
        public BlueLight.Web.Models.EventDtoGen Event
        {
            get => _Event;
            set { _Event = value; Changed(nameof(Event)); }
        }
        public string Name
        {
            get => _Name;
            set { _Name = value; Changed(nameof(Name)); }
        }
        public System.Collections.Generic.ICollection<BlueLight.Web.Models.EventRegistrationDtoGen> EventRegistrations
        {
            get => _EventRegistrations;
            set { _EventRegistrations = value; Changed(nameof(EventRegistrations)); }
        }

        /// <summary>
        /// Map from the domain object to the properties of the current DTO instance.
        /// </summary>
        public override void MapFrom(BlueLight.Data.Models.EventTime obj, IMappingContext context, IncludeTree tree = null)
        {
            if (obj == null) return;
            var includes = context.Includes;

            this.EventTimeId = obj.EventTimeId;
            this.EventId = obj.EventId;
            this.Name = obj.Name;
            if (tree == null || tree[nameof(this.Event)] != null)
                this.Event = obj.Event.MapToDto<BlueLight.Data.Models.Event, EventDtoGen>(context, tree?[nameof(this.Event)]);

            var propValEventRegistrations = obj.EventRegistrations;
            if (propValEventRegistrations != null && (tree == null || tree[nameof(this.EventRegistrations)] != null))
            {
                this.EventRegistrations = propValEventRegistrations
                    .OrderBy(f => f.EventRegistrationId)
                    .Select(f => f.MapToDto<BlueLight.Data.Models.EventRegistration, EventRegistrationDtoGen>(context, tree?[nameof(this.EventRegistrations)])).ToList();
            }
            else if (propValEventRegistrations == null && tree?[nameof(this.EventRegistrations)] != null)
            {
                this.EventRegistrations = new EventRegistrationDtoGen[0];
            }

        }

        /// <summary>
        /// Map from the current DTO instance to the domain object.
        /// </summary>
        public override void MapTo(BlueLight.Data.Models.EventTime entity, IMappingContext context)
        {
            var includes = context.Includes;

            if (OnUpdate(entity, context)) return;

            if (ShouldMapTo(nameof(EventTimeId))) entity.EventTimeId = (EventTimeId ?? entity.EventTimeId);
            if (ShouldMapTo(nameof(EventId))) entity.EventId = (EventId ?? entity.EventId);
            if (ShouldMapTo(nameof(Name))) entity.Name = Name;
        }

        /// <summary>
        /// Map from the current DTO instance to a new instance of the domain object.
        /// </summary>
        public override BlueLight.Data.Models.EventTime MapToNew(IMappingContext context)
        {
            var entity = new BlueLight.Data.Models.EventTime();
            MapTo(entity, context);
            return entity;
        }
    }
}
