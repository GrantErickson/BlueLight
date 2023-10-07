import {
  Domain, getEnumMeta, solidify, ModelType, ObjectType,
  PrimitiveProperty, ForeignKeyProperty, PrimaryKeyProperty,
  ModelCollectionNavigationProperty, ModelReferenceNavigationProperty,
  HiddenAreas, BehaviorFlags
} from 'coalesce-vue/lib/metadata'


const domain: Domain = { enums: {}, types: {}, services: {} }
export const ApplicationUser = domain.types.ApplicationUser = {
  name: "ApplicationUser",
  displayName: "Application User",
  get displayProp() { return this.props.name }, 
  type: "model",
  controllerRoute: "ApplicationUser",
  get keyProp() { return this.props.applicationUserId }, 
  behaviorFlags: 7 as BehaviorFlags,
  props: {
    applicationUserId: {
      name: "applicationUserId",
      displayName: "Application User Id",
      type: "number",
      role: "primaryKey",
      hidden: 3 as HiddenAreas,
    },
    name: {
      name: "name",
      displayName: "Name",
      type: "string",
      role: "value",
      rules: {
        required: val => (val != null && val !== '') || "Name is required.",
      }
    },
  },
  methods: {
  },
  dataSources: {
  },
}
export const Event = domain.types.Event = {
  name: "Event",
  displayName: "Event",
  get displayProp() { return this.props.name }, 
  type: "model",
  controllerRoute: "Event",
  get keyProp() { return this.props.eventId }, 
  behaviorFlags: 7 as BehaviorFlags,
  props: {
    eventId: {
      name: "eventId",
      displayName: "Event Id",
      type: "string",
      role: "primaryKey",
      hidden: 3 as HiddenAreas,
    },
    name: {
      name: "name",
      displayName: "Name",
      type: "string",
      role: "value",
      rules: {
        required: val => (val != null && val !== '') || "Name is required.",
      }
    },
    date: {
      name: "date",
      displayName: "Date",
      type: "date",
      dateKind: "datetime",
      noOffset: true,
      role: "value",
    },
    description: {
      name: "description",
      displayName: "Description",
      type: "string",
      role: "value",
      rules: {
        required: val => (val != null && val !== '') || "Description is required.",
      }
    },
    isActive: {
      name: "isActive",
      displayName: "Is Active",
      type: "boolean",
      role: "value",
    },
    eventTimes: {
      name: "eventTimes",
      displayName: "Event Times",
      type: "collection",
      itemType: {
        name: "$collectionItem",
        displayName: "",
        role: "value",
        type: "model",
        get typeDef() { return (domain.types.EventTime as ModelType) },
      },
      role: "collectionNavigation",
      get foreignKey() { return (domain.types.EventTime as ModelType).props.eventId as ForeignKeyProperty },
      get inverseNavigation() { return (domain.types.EventTime as ModelType).props.event as ModelReferenceNavigationProperty },
      dontSerialize: true,
    },
  },
  methods: {
  },
  dataSources: {
  },
}
export const EventRegistration = domain.types.EventRegistration = {
  name: "EventRegistration",
  displayName: "Event Registration",
  get displayProp() { return this.props.eventRegistrationId }, 
  type: "model",
  controllerRoute: "EventRegistration",
  get keyProp() { return this.props.eventRegistrationId }, 
  behaviorFlags: 7 as BehaviorFlags,
  props: {
    eventRegistrationId: {
      name: "eventRegistrationId",
      displayName: "Event Registration Id",
      type: "string",
      role: "primaryKey",
      hidden: 3 as HiddenAreas,
    },
    eventTimeId: {
      name: "eventTimeId",
      displayName: "Event Time Id",
      type: "string",
      role: "foreignKey",
      get principalKey() { return (domain.types.EventTime as ModelType).props.eventTimeId as PrimaryKeyProperty },
      get principalType() { return (domain.types.EventTime as ModelType) },
      get navigationProp() { return (domain.types.EventRegistration as ModelType).props.eventTime as ModelReferenceNavigationProperty },
      hidden: 3 as HiddenAreas,
      rules: {
        required: val => val != null || "Event Time is required.",
        pattern: val => !val || /^\s*[{(]?[0-9A-Fa-f]{8}[-]?(?:[0-9A-Fa-f]{4}[-]?){3}[0-9A-Fa-f]{12}[)}]?\s*$/.test(val) || "Event Time does not match expected format.",
      }
    },
    eventTime: {
      name: "eventTime",
      displayName: "Event Time",
      type: "model",
      get typeDef() { return (domain.types.EventTime as ModelType) },
      role: "referenceNavigation",
      get foreignKey() { return (domain.types.EventRegistration as ModelType).props.eventTimeId as ForeignKeyProperty },
      get principalKey() { return (domain.types.EventTime as ModelType).props.eventTimeId as PrimaryKeyProperty },
      get inverseNavigation() { return (domain.types.EventTime as ModelType).props.eventRegistrations as ModelCollectionNavigationProperty },
      dontSerialize: true,
    },
    email: {
      name: "email",
      displayName: "Email",
      type: "string",
      role: "value",
      rules: {
        required: val => (val != null && val !== '') || "Email is required.",
      }
    },
    phone: {
      name: "phone",
      displayName: "Phone",
      type: "string",
      role: "value",
      rules: {
        required: val => (val != null && val !== '') || "Phone is required.",
      }
    },
    notes: {
      name: "notes",
      displayName: "Notes",
      type: "string",
      role: "value",
    },
    quantity: {
      name: "quantity",
      displayName: "Quantity",
      type: "number",
      role: "value",
    },
  },
  methods: {
  },
  dataSources: {
  },
}
export const EventTime = domain.types.EventTime = {
  name: "EventTime",
  displayName: "Event Time",
  get displayProp() { return this.props.name }, 
  type: "model",
  controllerRoute: "EventTime",
  get keyProp() { return this.props.eventTimeId }, 
  behaviorFlags: 7 as BehaviorFlags,
  props: {
    eventTimeId: {
      name: "eventTimeId",
      displayName: "Event Time Id",
      type: "string",
      role: "primaryKey",
      hidden: 3 as HiddenAreas,
    },
    eventId: {
      name: "eventId",
      displayName: "Event Id",
      type: "string",
      role: "foreignKey",
      get principalKey() { return (domain.types.Event as ModelType).props.eventId as PrimaryKeyProperty },
      get principalType() { return (domain.types.Event as ModelType) },
      get navigationProp() { return (domain.types.EventTime as ModelType).props.event as ModelReferenceNavigationProperty },
      hidden: 3 as HiddenAreas,
      rules: {
        required: val => val != null || "Event is required.",
        pattern: val => !val || /^\s*[{(]?[0-9A-Fa-f]{8}[-]?(?:[0-9A-Fa-f]{4}[-]?){3}[0-9A-Fa-f]{12}[)}]?\s*$/.test(val) || "Event does not match expected format.",
      }
    },
    event: {
      name: "event",
      displayName: "Event",
      type: "model",
      get typeDef() { return (domain.types.Event as ModelType) },
      role: "referenceNavigation",
      get foreignKey() { return (domain.types.EventTime as ModelType).props.eventId as ForeignKeyProperty },
      get principalKey() { return (domain.types.Event as ModelType).props.eventId as PrimaryKeyProperty },
      get inverseNavigation() { return (domain.types.Event as ModelType).props.eventTimes as ModelCollectionNavigationProperty },
      dontSerialize: true,
    },
    name: {
      name: "name",
      displayName: "Name",
      type: "string",
      role: "value",
      rules: {
        required: val => (val != null && val !== '') || "Name is required.",
      }
    },
    eventRegistrations: {
      name: "eventRegistrations",
      displayName: "Event Registrations",
      type: "collection",
      itemType: {
        name: "$collectionItem",
        displayName: "",
        role: "value",
        type: "model",
        get typeDef() { return (domain.types.EventRegistration as ModelType) },
      },
      role: "collectionNavigation",
      get foreignKey() { return (domain.types.EventRegistration as ModelType).props.eventTimeId as ForeignKeyProperty },
      get inverseNavigation() { return (domain.types.EventRegistration as ModelType).props.eventTime as ModelReferenceNavigationProperty },
      dontSerialize: true,
    },
  },
  methods: {
  },
  dataSources: {
  },
}
export const SignUpService = domain.services.SignUpService = {
  name: "SignUpService",
  displayName: "Sign Up Service",
  type: "service",
  controllerRoute: "SignUpService",
  methods: {
    currentEvents: {
      name: "currentEvents",
      displayName: "Current Events",
      transportType: "item",
      httpMethod: "POST",
      params: {
      },
      return: {
        name: "$return",
        displayName: "Result",
        type: "collection",
        itemType: {
          name: "$collectionItem",
          displayName: "",
          role: "value",
          type: "model",
          get typeDef() { return (domain.types.Event as ModelType) },
        },
        role: "value",
      },
    },
    register: {
      name: "register",
      displayName: "Register",
      transportType: "item",
      httpMethod: "POST",
      params: {
        eventTimeId: {
          name: "eventTimeId",
          displayName: "Event Time Id",
          type: "string",
          role: "value",
          rules: {
            pattern: val => !val || /^\s*[{(]?[0-9A-Fa-f]{8}[-]?(?:[0-9A-Fa-f]{4}[-]?){3}[0-9A-Fa-f]{12}[)}]?\s*$/.test(val) || "Event Time Id does not match expected format.",
          }
        },
        email: {
          name: "email",
          displayName: "Email",
          type: "string",
          role: "value",
          rules: {
            required: val => (val != null && val !== '') || "Email is required.",
          }
        },
        phone: {
          name: "phone",
          displayName: "Phone",
          type: "string",
          role: "value",
          rules: {
            required: val => (val != null && val !== '') || "Phone is required.",
          }
        },
        quantity: {
          name: "quantity",
          displayName: "Quantity",
          type: "number",
          role: "value",
        },
        notes: {
          name: "notes",
          displayName: "Notes",
          type: "string",
          role: "value",
        },
      },
      return: {
        name: "$return",
        displayName: "Result",
        type: "string",
        role: "value",
      },
    },
  },
}

interface AppDomain extends Domain {
  enums: {
  }
  types: {
    ApplicationUser: typeof ApplicationUser
    Event: typeof Event
    EventRegistration: typeof EventRegistration
    EventTime: typeof EventTime
  }
  services: {
    SignUpService: typeof SignUpService
  }
}

solidify(domain)

export default domain as unknown as AppDomain
