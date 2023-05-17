<template>
  <div>
    <form @submit.capture="editEmployee">
      <div>
        <label for="name">Name</label>
        <input id="name" v-model="employee.name">
      </div>
      <div>
        <label for="surName">Surname</label>
        <input id="surName" v-model="employee.surName">
      </div>
      <div>
        <label for="lastName">LastName</label>
        <input id="lastName" v-model="employee.lastName">
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
        <label for="role">Role</label>
        <select id="roleId" v-model="roleId">
          <option v-for="r in roles" :key="r.id" :value="r.id">
            {{ r.name }}
          </option>
        </select>
      </div>
      <button type="submit">

        Edit
      </button>
    </form>
  </div>
</template>

<script>
import axios from "axios";
import config from "@/config/config";
import router from "@/router";




export default {
  name: "EmployeeEditForm",
  data() {
    return {
      employee: {},
      role: null,
      roles: [],
      roleId: null,
      position: [],
      positionId: null
    }
  },
  methods:{


    getEmployee: function (id){
      this.id = id
      axios.get(config.apiUrllocal + config.apiPort + "/Employee/Edit/"+id,
          {

          }).then(response => {
        this.employee = response.data.employee
        console.log(response.data)
      })
    },
    editEmployee() {
      console.log(`Sending request to ${config.apiUrllocal}${config.apiPort}/Employee/Edit`);
      console.log(`Sending data: ${JSON.stringify({
        employee:{
          id: this.employee.id,
          name: this.employee.name,
          surName: this.employee.surName,
          lastName: this.employee.lastName,
        },
        positionId: this.positionId,
        roleId: this.roleId
      })}`);

      axios.post(config.apiUrllocal + config.apiPort + "/Employee/Edit", {
        employee:{
          id: this.employee.id,
          name: this.employee.name,
          surName: this.employee.surName,
          lastName: this.employee.lastName,
        },
        positionId: this.positionId,
        roleId: this.roleId
      }).then(response => {
        // handle success
        console.log(response.data);

      }).catch(error => {
        // handle error
        console.log(error.response.data);
      });
    },
    getPosition: function (){
      axios.get(config.apiUrllocal +config.apiPort +'/Position', {

      }).then(response => {
        this.position = response.data
      }).catch(err => {
        console.log(err.message)
      })
    },
    getAllRoles: function () {
      axios.get(config.apiUrllocal + config.apiPort + "/Employee/GetAllRoles", {})
          .then(response => {
            this.roles = response.data.value
            console.log(response.data.value)

          }).catch(err =>{
            console.log(err.message)
      })
    }
  },
  created() {

     if (sessionStorage.getItem("role") !== "admin"){
       router.push("/")
     }else {
      this.getAllRoles();
       this.getPosition();
       this.getEmployee(this.$route.params.id);
       this.id = this.$route.params.id;
     }


  },

}
</script>

<style scoped>

</style>
