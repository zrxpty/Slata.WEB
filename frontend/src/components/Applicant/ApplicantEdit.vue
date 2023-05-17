<template>
  <form @submit.capture="editApplicant">
    <div>
      <div>
        <label for="name">Name</label>
        <input id="name" v-model="applicant.name">
      </div>
      <div>
        <label for="surName">Surname</label>
        <input id="surName" v-model="applicant.surName">
      </div>
      <div>
        <label for="lastName">Lastname</label>
        <input id="lastName" v-model="applicant.lastName">
      </div>
      <div>
        <label for="phoneNumber">Phone</label>
        <input id="phoneNumber" v-model="applicant.phoneNumber">
      </div>
    </div>
    <div>
      <label for="position">Position</label>
      <select id="positionId" v-model="applicant.positionId">
        <option :value="null">Not position</option>
        <option v-for="pos in position" :key="pos.id" :value="pos.id">
          {{ pos.name }}
        </option>
      </select>
    </div>
    <div>
      <label for="employee">TeamLead</label>
      <select id="teamLeadId" v-model="applicant.teamLeadId">
        <option v-for="emp in employee" :key="emp.id" :value="emp.id">
          {{ emp.surName }} {{emp.name}} {{emp.lastName}}
        </option>
      </select>
    </div>
    <div>
      <label for="interview">Interview date</label>
      <input type="date" id="interview" v-model="applicant.interview">
    </div>
    <div>
      <label for="deadLine">Deadline</label>
      <input type="date" id="deadLine" v-model="applicant.deadLine">
    </div>
    <div>
      <button type="submit">
        Edit
      </button>
    </div>
  </form>
</template>

<script>
import axios from "axios";
import config from "@/config/config";
import router from "@/router";



export default {
  name: "ApplicantEditForm",
  data (){
    return{
      applicant: {},
      hr: null,
      employee: [],
      teamLeadId: null,
      position: [],
      positionId: null,
    }
  },
  methods:{
    editApplicant(){
      if ( (sessionStorage.getItem("role") === "hr") || (sessionStorage.getItem("role") == "admin")){
        axios.post(config.apiUrllocal + config.apiPort + "/Applicant/Edit", {
          id: this.$route.params.id,
          hr: this.applicant.hr,
          name: this.applicant.name,
          surName: this.applicant.surName,
          lastName: this.applicant.lastName,
          phoneNumber: this.applicant.phoneNumber,
          teamLeadId: this.applicant.teamLeadId,
          positionId: this.applicant.positionId,
          interview: this.applicant.interview,
          deadLine: this.applicant.deadLine,
        }).then(response => {
          // handle success
          console.log(response.data);

        }).catch(error => {
          // handle error
          console.log(error.response.data);
        });
      }else{
        alert("No rights")
        router.push("/")
      }
    },
    getApplicant: function (id){
      this.id = id
      axios.get(config.apiUrllocal + config.apiPort + "/Applicant/Edit/"+id,
          {
          }).then(response => {
        this.applicant = {
          id: response.data.id,
          name: response.data.name,
          surName: response.data.surName,
          lastName: response.data.lastName,
          phoneNumber: response.data.phoneNumber,
          interview: response.data.interview,
          deadLine: response.data.deadLine,
          teamLead: response.data.teamLeadId,
          position: response.data.positionId
        },
            this.hr = response.data.hr

      })
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
    getPosition: function (){
      axios.get(config.apiUrllocal +config.apiPort +'/Position', {

      }).then(response => {
        this.position = response.data

      }).catch(err => {
        console.log(err.message)
      })
    },
    },

  created() {
    if (sessionStorage.getItem("role") === "hr" || sessionStorage.getItem("role") === "admin"){
      const id = this.$route.params.id;
      this.getAllTeamLead()
      this.getPosition()
      this.getApplicant(id)
    }


  }


}
</script>

<style scoped>

</style>