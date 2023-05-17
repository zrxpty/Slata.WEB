<template>
  <div>
    <div>
      <input type="text" v-model="searchQuery" placeholder="Search">
    </div>

    <router-link to="/applicantAdd">Add</router-link>
    <div class="container">
      <table>
        <thead>
        <tr>
          <th>Name</th>
          <th>Surname</th>
          <th>Lastname</th>
          <th>Phone</th>
          <th>Interview</th>
          <th>Deadline</th>
          <th>Position</th>
          <th></th>
        </tr>
        </thead>
        <tbody>
        <tr v-for="applicantItem in filteredApplicants" :key="applicantItem.id">
          <td>{{ applicantItem.name }}</td>
          <td>{{ applicantItem.surname }}</td>
          <td>{{ applicantItem.lastName }}</td>
          <td>{{ applicantItem.phoneNumber }}</td>
          <td>{{ formattedDate(applicantItem.interview) }}</td>
          <td>{{ formattedDate(applicantItem.deadLine) }}</td>
          <td>{{ applicantItem.position }}</td>
          <td>
            <button v-if="rulesEdit()" @click="edit(applicantItem.id)">Edit</button>
          </td>
        </tr>
        </tbody>
      </table>
    </div>
  </div>
</template>

<script>
import axios from "axios";
import config from "@/config/config";
import router from "@/router";

export default {
  name: "ApplicantIndex",
  data() {
    return {
      applicant: [],
      searchQuery: "",
    };
  },
  methods: {
    getAllApplicant() {
      axios
          .get(config.apiUrllocal + config.apiPort + "/Applicant")
          .then((response) => {
            this.applicant = response.data;
            console.log(response.data);
          })
          .catch((err) => {
            console.log(err.message);
          });
    },
    rulesEdit() {
      return (
          sessionStorage.getItem("role") === "admin" ||
          sessionStorage.getItem("role") === "hr"
      );
    },
    edit(id) {
      if (sessionStorage.getItem("role") === "admin" || sessionStorage.getItem("role") === "hr") {
        router.push("applicantEdit/"+id );
      } else {
        alert("No rights");
      }
    },

  },
  computed: {
    formattedDate() {
      return function (dateStr) {
        const date = new Date(dateStr);
        const day = date.getDate();
        const month = date.getMonth() + 1;
        const year = date.getFullYear();
        return `${day < 10 ? "0" + day : day}.${month < 10 ? "0" + month : month}.${year}`;
      };
    },
    filteredApplicants() {
      const query = this.searchQuery.toLowerCase();
      return this.applicant.filter((applicant) => {
        return (
            applicant.name.toLowerCase().includes(query) ||
            applicant.surName.toLowerCase().includes(query) ||
            applicant.lastName.toLowerCase().includes(query) ||
            applicant.position.toLowerCase().includes(query)

        );
      });
    },
  },
  created() {
    console.log(sessionStorage.getItem("role"));
    this.getAllApplicant();
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