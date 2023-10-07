import * as metadata from './metadata.g'
import { Model, DataSource, convertToModel, mapToModel } from 'coalesce-vue/lib/model'

export interface ApplicationUser extends Model<typeof metadata.ApplicationUser> {
  applicationUserId: number | null
  name: string | null
}
export class ApplicationUser {
  
  /** Mutates the input object and its descendents into a valid ApplicationUser implementation. */
  static convert(data?: Partial<ApplicationUser>): ApplicationUser {
    return convertToModel(data || {}, metadata.ApplicationUser) 
  }
  
  /** Maps the input object and its descendents to a new, valid ApplicationUser implementation. */
  static map(data?: Partial<ApplicationUser>): ApplicationUser {
    return mapToModel(data || {}, metadata.ApplicationUser) 
  }
  
  /** Instantiate a new ApplicationUser, optionally basing it on the given data. */
  constructor(data?: Partial<ApplicationUser> | {[k: string]: any}) {
    Object.assign(this, ApplicationUser.map(data || {}));
  }
}


export interface Event extends Model<typeof metadata.Event> {
  eventId: string | null
  name: string | null
  date: Date | null
  description: string | null
  isActive: boolean | null
  eventTimes: EventTime[] | null
}
export class Event {
  
  /** Mutates the input object and its descendents into a valid Event implementation. */
  static convert(data?: Partial<Event>): Event {
    return convertToModel(data || {}, metadata.Event) 
  }
  
  /** Maps the input object and its descendents to a new, valid Event implementation. */
  static map(data?: Partial<Event>): Event {
    return mapToModel(data || {}, metadata.Event) 
  }
  
  /** Instantiate a new Event, optionally basing it on the given data. */
  constructor(data?: Partial<Event> | {[k: string]: any}) {
    Object.assign(this, Event.map(data || {}));
  }
}


export interface EventRegistration extends Model<typeof metadata.EventRegistration> {
  eventRegistrationId: string | null
  eventTimeId: string | null
  eventTime: EventTime | null
  email: string | null
  phone: string | null
  notes: string | null
  quantity: number | null
}
export class EventRegistration {
  
  /** Mutates the input object and its descendents into a valid EventRegistration implementation. */
  static convert(data?: Partial<EventRegistration>): EventRegistration {
    return convertToModel(data || {}, metadata.EventRegistration) 
  }
  
  /** Maps the input object and its descendents to a new, valid EventRegistration implementation. */
  static map(data?: Partial<EventRegistration>): EventRegistration {
    return mapToModel(data || {}, metadata.EventRegistration) 
  }
  
  /** Instantiate a new EventRegistration, optionally basing it on the given data. */
  constructor(data?: Partial<EventRegistration> | {[k: string]: any}) {
    Object.assign(this, EventRegistration.map(data || {}));
  }
}


export interface EventTime extends Model<typeof metadata.EventTime> {
  eventTimeId: string | null
  eventId: string | null
  event: Event | null
  name: string | null
  eventRegistrations: EventRegistration[] | null
}
export class EventTime {
  
  /** Mutates the input object and its descendents into a valid EventTime implementation. */
  static convert(data?: Partial<EventTime>): EventTime {
    return convertToModel(data || {}, metadata.EventTime) 
  }
  
  /** Maps the input object and its descendents to a new, valid EventTime implementation. */
  static map(data?: Partial<EventTime>): EventTime {
    return mapToModel(data || {}, metadata.EventTime) 
  }
  
  /** Instantiate a new EventTime, optionally basing it on the given data. */
  constructor(data?: Partial<EventTime> | {[k: string]: any}) {
    Object.assign(this, EventTime.map(data || {}));
  }
}


