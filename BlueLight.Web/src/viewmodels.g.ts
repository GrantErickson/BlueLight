import * as $metadata from './metadata.g'
import * as $models from './models.g'
import * as $apiClients from './api-clients.g'
import { ViewModel, ListViewModel, ServiceViewModel, DeepPartial, defineProps } from 'coalesce-vue/lib/viewmodel'

export interface ApplicationUserViewModel extends $models.ApplicationUser {
  applicationUserId: number | null;
  name: string | null;
}
export class ApplicationUserViewModel extends ViewModel<$models.ApplicationUser, $apiClients.ApplicationUserApiClient, number> implements $models.ApplicationUser  {
  
  constructor(initialData?: DeepPartial<$models.ApplicationUser> | null) {
    super($metadata.ApplicationUser, new $apiClients.ApplicationUserApiClient(), initialData)
  }
}
defineProps(ApplicationUserViewModel, $metadata.ApplicationUser)

export class ApplicationUserListViewModel extends ListViewModel<$models.ApplicationUser, $apiClients.ApplicationUserApiClient, ApplicationUserViewModel> {
  
  constructor() {
    super($metadata.ApplicationUser, new $apiClients.ApplicationUserApiClient())
  }
}


export interface EventViewModel extends $models.Event {
  eventId: string | null;
  name: string | null;
  date: Date | null;
  description: string | null;
  eventTimes: EventTimeViewModel[] | null;
}
export class EventViewModel extends ViewModel<$models.Event, $apiClients.EventApiClient, string> implements $models.Event  {
  
  
  public addToEventTimes(initialData?: DeepPartial<$models.EventTime> | null) {
    return this.$addChild('eventTimes', initialData) as EventTimeViewModel
  }
  
  constructor(initialData?: DeepPartial<$models.Event> | null) {
    super($metadata.Event, new $apiClients.EventApiClient(), initialData)
  }
}
defineProps(EventViewModel, $metadata.Event)

export class EventListViewModel extends ListViewModel<$models.Event, $apiClients.EventApiClient, EventViewModel> {
  
  constructor() {
    super($metadata.Event, new $apiClients.EventApiClient())
  }
}


export interface EventRegistrationViewModel extends $models.EventRegistration {
  eventRegistrationId: string | null;
  eventTimeId: string | null;
  eventTime: EventTimeViewModel | null;
  email: string | null;
  notes: string | null;
  quantity: number | null;
}
export class EventRegistrationViewModel extends ViewModel<$models.EventRegistration, $apiClients.EventRegistrationApiClient, string> implements $models.EventRegistration  {
  
  constructor(initialData?: DeepPartial<$models.EventRegistration> | null) {
    super($metadata.EventRegistration, new $apiClients.EventRegistrationApiClient(), initialData)
  }
}
defineProps(EventRegistrationViewModel, $metadata.EventRegistration)

export class EventRegistrationListViewModel extends ListViewModel<$models.EventRegistration, $apiClients.EventRegistrationApiClient, EventRegistrationViewModel> {
  
  constructor() {
    super($metadata.EventRegistration, new $apiClients.EventRegistrationApiClient())
  }
}


export interface EventTimeViewModel extends $models.EventTime {
  eventTimeId: string | null;
  eventId: string | null;
  event: EventViewModel | null;
  name: string | null;
  eventRegistrations: EventRegistrationViewModel[] | null;
}
export class EventTimeViewModel extends ViewModel<$models.EventTime, $apiClients.EventTimeApiClient, string> implements $models.EventTime  {
  
  
  public addToEventRegistrations(initialData?: DeepPartial<$models.EventRegistration> | null) {
    return this.$addChild('eventRegistrations', initialData) as EventRegistrationViewModel
  }
  
  constructor(initialData?: DeepPartial<$models.EventTime> | null) {
    super($metadata.EventTime, new $apiClients.EventTimeApiClient(), initialData)
  }
}
defineProps(EventTimeViewModel, $metadata.EventTime)

export class EventTimeListViewModel extends ListViewModel<$models.EventTime, $apiClients.EventTimeApiClient, EventTimeViewModel> {
  
  constructor() {
    super($metadata.EventTime, new $apiClients.EventTimeApiClient())
  }
}


const viewModelTypeLookup = ViewModel.typeLookup = {
  ApplicationUser: ApplicationUserViewModel,
  Event: EventViewModel,
  EventRegistration: EventRegistrationViewModel,
  EventTime: EventTimeViewModel,
}
const listViewModelTypeLookup = ListViewModel.typeLookup = {
  ApplicationUser: ApplicationUserListViewModel,
  Event: EventListViewModel,
  EventRegistration: EventRegistrationListViewModel,
  EventTime: EventTimeListViewModel,
}
const serviceViewModelTypeLookup = ServiceViewModel.typeLookup = {
}

