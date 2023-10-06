import * as $metadata from './metadata.g'
import * as $models from './models.g'
import { AxiosClient, ModelApiClient, ServiceApiClient, ItemResult, ListResult } from 'coalesce-vue/lib/api-client'
import { AxiosPromise, AxiosResponse, AxiosRequestConfig } from 'axios'

export class ApplicationUserApiClient extends ModelApiClient<$models.ApplicationUser> {
  constructor() { super($metadata.ApplicationUser) }
}


export class EventApiClient extends ModelApiClient<$models.Event> {
  constructor() { super($metadata.Event) }
}


export class EventRegistrationApiClient extends ModelApiClient<$models.EventRegistration> {
  constructor() { super($metadata.EventRegistration) }
}


export class EventTimeApiClient extends ModelApiClient<$models.EventTime> {
  constructor() { super($metadata.EventTime) }
}


