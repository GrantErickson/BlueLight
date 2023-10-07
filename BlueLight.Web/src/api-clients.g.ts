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


export class SignUpServiceApiClient extends ServiceApiClient<typeof $metadata.SignUpService> {
  constructor() { super($metadata.SignUpService) }
  public currentEvents($config?: AxiosRequestConfig): AxiosPromise<ItemResult<$models.Event[]>> {
    const $method = this.$metadata.methods.currentEvents
    const $params =  {
    }
    return this.$invoke($method, $params, $config)
  }
  
  public register(eventTimeId: string | null, email: string | null, phone: string | null, quantity: number | null, notes: string | null, $config?: AxiosRequestConfig): AxiosPromise<ItemResult<string>> {
    const $method = this.$metadata.methods.register
    const $params =  {
      eventTimeId,
      email,
      phone,
      quantity,
      notes,
    }
    return this.$invoke($method, $params, $config)
  }
  
}


