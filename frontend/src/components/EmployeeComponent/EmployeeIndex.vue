<template>
  <div>
    <input type="text" v-model="searchQuery" placeholder="Search">
  </div>
  <div class="container">


    <table>
      <thead>
      <tr>
        <th>Full Name</th>
        <th>UserName</th>
        <th>Position</th>
        <th>Role</th>
      </tr>
      </thead>
      <tbody>
      <tr v-for="employee in filteredEmployees" :key="employee.id">
        <td>{{ employee.name }} {{ employee.surName }} {{ employee.lastName }}</td>
        <td>{{ employee.userName }}</td>
        <td>{{ employee.position ? employee.position.name : '???' }}</td>
        <td>{{ employee.role ? employee.role.name : '???' }}</td>
        <td>
          <button @click="edit(employee.id)">Edit</button>
        </td>
      </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
import axios from "axios";
import config from "@/config/config";
import router from "@/router";

export default {
  data() {
    return {
      message: [],
      searchQuery: "",
    };
  },
  methods: {
    getAll() {
      const params = {
        search: this.searchQuery,
      };

      axios
          .get(config.apiUrllocal + config.apiPort + "/Employee", { params })
          .then((response) => {
            this.message = response.data.value;
          })
          .catch((err) => {
            console.log(err.message);
          });
    },
    edit(id) {
      if (sessionStorage.getItem("role") === "admin") {
        router.push("employeeEdit/" + id);
      } else {
        alert("No rights");
      }
    },
  },
  computed: {
    filteredEmployees() {
      const query = this.searchQuery.toLowerCase();
      return this.message.filter((employee) => {
        return (
            employee.name.toLowerCase().includes(query) ||
            employee.surName.toLowerCase().includes(query) ||
            employee.lastName.toLowerCase().includes(query) ||
            employee.userName.toLowerCase().includes(query) ||
            (employee.position && employee.position.name.toLowerCase().includes(query)) ||
            (employee.role && employee.role.name.toLowerCase().includes(query))
        );
      });
    },
  },
  created() {
    if (sessionStorage.getItem("role") == "hr" ||
        sessionStorage.getItem("role") == "admin" ||
        sessionStorage.getItem("role") == "teamlead" ){
      this.getAll();
    }else{
      router.push("/")
    }

  },
};
</script>

<style scoped>
.container {
  max-width: 90%;
  margin: 0 auto;
  text-align: center;
  margin-right: -20%;
}
</style>
