<template>
  <v-container>
    <v-row>
      <v-col cols="12">
        <v-card v-for="event in events" :key="event.eventId!">
          <v-card-title> {{ event.name }} on {{ event.date }} </v-card-title>
          <v-card-subtitle>
            {{ event.description }}
          </v-card-subtitle>
          <v-card
            v-for="eventTime in event.eventTimes"
            :key="eventTime.eventTimeId!"
          >
            <v-card-title>
              <v-row>
                <v-col>{{ eventTime.name }}</v-col>
                <v-col>
                  <v-btn
                    @click="openRegister(eventTime!)"
                    class="float-right"
                    color="blue"
                    >Register</v-btn
                  >
                </v-col>
              </v-row>
            </v-card-title>
            <v-card-subtitle>
              Total Servings:
              {{
                eventTime.eventRegistrations?.reduce(
                  (a, b) => a + b.quantity!,
                  0
                )
              }}
            </v-card-subtitle>
            <v-card-text>
              <v-row
                v-for="eventRegistration in eventTime.eventRegistrations"
                :key="eventRegistration.eventRegistrationId!"
              >
                <v-col>
                  {{ eventRegistration.email }}
                </v-col>
                <v-col>
                  {{ eventRegistration.phone }}
                </v-col>
                <v-col> Servings: {{ eventRegistration.quantity }} </v-col>
                <v-col>
                  {{ eventRegistration.notes }}
                </v-col>
              </v-row>
            </v-card-text>
          </v-card>
        </v-card>
      </v-col>
    </v-row>
  </v-container>

  <v-dialog
    v-model="showRegister"
    width="600"
    transition="dialog-bottom-transition"
  >
    <v-card>
      <v-card-title>
        Registering for
        {{ registeringEventTime?.name }}
      </v-card-title>
      <v-card-text>
        <v-text-field label="Email" v-model="email"></v-text-field>
        <v-text-field label="Phone" v-model="phone"></v-text-field>
        <v-select
          label="Quantity"
          v-model="quantity"
          :items="[1, 2, 3, 4, 5, 6, 7, 8, 9, 10]"
        ></v-select>
        <v-text-field label="Notes" v-model="notes"></v-text-field>
      </v-card-text>
      <v-card-actions>
        <v-spacer></v-spacer>
        <v-btn color="primary" @click="register"> Register </v-btn>
        <v-btn color="red" @click="showRegister = false"> Cancel </v-btn>
      </v-card-actions>
    </v-card>
  </v-dialog>
</template>

<script setup lang="ts">
import { SignUpServiceViewModel } from "@/viewmodels.g";
import * as $models from "@/models.g";
import { Ref } from "vue";
// Create a SignUpService
let sus = new SignUpServiceViewModel();
let showRegister = ref(false);
let registeringEventTime: $models.EventTime;
let email = ref("");
let phone = ref("");
let quantity = ref(2);
let notes = ref("");

const events: Ref<$models.Event[] | null> = ref([]);

load();

function load() {
  sus.currentEvents.invoke().then((result) => {
    console.log(result);
    events.value = sus.currentEvents.result;
  });
}

function openRegister(eventTimeId: $models.EventTime) {
  showRegister.value = true;
  registeringEventTime = eventTimeId;
}

function register() {
  if (registeringEventTime == null) return;
  console.log(`register clicked for ${registeringEventTime.eventTimeId}`);
  sus.register
    .invoke(
      registeringEventTime.eventTimeId,
      email.value,
      phone.value,
      quantity.value,
      notes.value
    )
    .then((result) => {
      console.log(result);
      if (!result.data.wasSuccessful) {
        alert(result.data.message);
        // Leave the window open.
      } else {
        load();
        alert(result.data.object);
        // Close the window
        showRegister.value = false;
      }
    })
    .catch((error) => {
      console.log(error);
      alert(error.response.data.message);
    });
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped lang="scss"></style>
