<template>
  <form @submit.capture="addApplicant">
    <div>
      <label for="name">Name</label>
      <input id="name" v-model="name">
    </div>
    <div>
      <label for="surName">Surname</label>
      <input id="surName" v-model="surName">
    </div>
    <div>
      <label for="lastName">LastName</label>
      <input id="lastName" v-model="lastName">
    </div>
    <div>
      <label for="phoneNumber">Phone</label>
      <input id="phoneNumber" v-model="phoneNumber">
    </div>
  <div>
    <label for="position">Position</label>
    <select id="positionId" v-model="positionId">
      <option :value="null">Not position</option>
      <option v-for="pos in position" :key="pos.id" :value="pos.id">
        {{ pos.name }}
      </option>
    </select>
  </div>
    <div>
      <label for="employee">TeamLead</label>
      <select id="teamLeadId" v-model="teamLeadId">
        <option v-for="emp in employee" :key="emp.id" :value="emp.id">
          {{ emp.surName }} {{emp.name}} {{emp.lastName}}
        </option>
      </select>
    </div>
    <div>
      <label for="interview">Interview date</label>
      <input type="date" id="interview" v-model="interview">
    </div>
    <div>
      <label for="deadLine">Deadline</label>
      <input type="date" id="deadLine" v-model="deadLine">
    </div>
    <div>
      <button type="submit">
        Add
      </button>
    </div>
  </form>
</template>

<script>
import axios from "axios";
import config from "@/config/config";
import router from "@/router";

export default {
  name: "ApplicantAddForm",
  data (){
    return {
      hr: null,
      name: null,
      surName: null,
      lastName: null,
      phoneNumber: null,
      employee: [],
      teamLeadId: null,
      position: [],
      positionId: null,
      interview: null,
      deadLine: null
    }
  },
  methods:{
    getPosition: function (){
      axios.get(config.apiUrllocal +config.apiPort +'/Position', {

      }).then(response => {
        this.position = response.data
      }).catch(err => {
        console.log(err.message)
      })
    },
    addApplicant() {
      if ( (sessionStorage.getItem("role") === "hr") || (sessionStorage.getItem("role") == "admin")){
        axios.post(config.apiUrllocal + config.apiPort + "/Applicant/AddApplicant", {
          hr: sessionStorage.getItem("id"),
          name: this.name,
          surName: this.surName,
          lastName: this.lastName,
          phoneNumber: this.phoneNumber,
          teamLeadId: this.teamLeadId,
          positionId: this.positionId,
          interview: this.interview,
          deadLine: this.deadLine,
        }).then(response => {
            console.log(response)

        }).catch(error => {

          console.log(error.response.data);
        });
      }else{
        alert("No rights")
        router.push("/")
      }

    },
    getAllTeamLead: function (){
      axios.get(config.apiUrllocal +config.apiPort +'/Employee/getAllTeamLead', {
      }).then(response => {
        this.employee = response.data.value
        console.log(response.data.value)
      }).catch(err => {
        console.log(err.message)
      })
    },
  },
  created() {

    this.getPosition()
    this.getAllTeamLead()
  }
}



</script>

<style scoped>

</style>