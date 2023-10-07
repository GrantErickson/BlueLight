using IntelliTect.Coalesce;
using IntelliTect.Coalesce.Mapping;
using IntelliTect.Coalesce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace BlueLight.Web.Models
{
    public partial class EventRegistrationDtoGen : GeneratedDto<BlueLight.Data.Models.EventRegistration>
    {
        public EventRegistrationDtoGen() { }

        private System.Guid? _EventRegistrationId;
        private System.Guid? _EventTimeId;
        private BlueLight.Web.Models.EventTimeDtoGen _EventTime;
        private string _Email;
        private string _Phone;
        private string _Notes;
        private int? _Quantity;

        public System.Guid? EventRegistrationId
        {
            get => _EventRegistrationId;
            set { _EventRegistrationId = value; Changed(nameof(EventRegistrationId)); }
        }
        public System.Guid? EventTimeId
        {
            get => _EventTimeId;
            set { _EventTimeId = value; Changed(nameof(EventTimeId)); }
        }
        public BlueLight.Web.Models.EventTimeDtoGen EventTime
        {
            get => _EventTime;
            set { _EventTime = value; Changed(nameof(EventTime)); }
        }
        public string Email
        {
            get => _Email;
            set { _Email = value; Changed(nameof(Email)); }
        }
        public string Phone
        {
            get => _Phone;
            set { _Phone = value; Changed(nameof(Phone)); }
        }
        public string Notes
        {
            get => _Notes;
            set { _Notes = value; Changed(nameof(Notes)); }
        }
        public int? Quantity
        {
            get => _Quantity;
            set { _Quantity = value; Changed(nameof(Quantity)); }
        }

        /// <summary>
        /// Map from the domain object to the properties of the current DTO instance.
        /// </summary>
        public override void MapFrom(BlueLight.Data.Models.EventRegistration obj, IMappingContext context, IncludeTree tree = null)
        {
            if (obj == null) return;
            var includes = context.Includes;

            this.EventRegistrationId = obj.EventRegistrationId;
            this.EventTimeId = obj.EventTimeId;
            this.Email = obj.Email;
            this.Phone = obj.Phone;
            this.Notes = obj.Notes;
            this.Quantity = obj.Quantity;
            if (tree == null || tree[nameof(this.EventTime)] != null)
                this.EventTime = obj.EventTime.MapToDto<BlueLight.Data.Models.EventTime, EventTimeDtoGen>(context, tree?[nameof(this.EventTime)]);

        }

        /// <summary>
        /// Map from the current DTO instance to the domain object.
        /// </summary>
        public override void MapTo(BlueLight.Data.Models.EventRegistration entity, IMappingContext context)
        {
            var includes = context.Includes;

            if (OnUpdate(entity, context)) return;

            if (ShouldMapTo(nameof(EventRegistrationId))) entity.EventRegistrationId = (EventRegistrationId ?? entity.EventRegistrationId);
            if (ShouldMapTo(nameof(EventTimeId))) entity.EventTimeId = (EventTimeId ?? entity.EventTimeId);
            if (ShouldMapTo(nameof(Email))) entity.Email = Email;
            if (ShouldMapTo(nameof(Phone))) entity.Phone = Phone;
            if (ShouldMapTo(nameof(Notes))) entity.Notes = Notes;
            if (ShouldMapTo(nameof(Quantity))) entity.Quantity = (Quantity ?? entity.Quantity);
        }

        /// <summary>
        /// Map from the current DTO instance to a new instance of the domain object.
        /// </summary>
        public override BlueLight.Data.Models.EventRegistration MapToNew(IMappingContext context)
        {
            var entity = new BlueLight.Data.Models.EventRegistration();
            MapTo(entity, context);
            return entity;
        }
    }
}
