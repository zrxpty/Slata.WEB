<template>
  <div class="container">
    <table>
      <thead>
      <tr>
        <th>Name</th> |
        <th>Surname</th> |
        <th>Lastname</th> |
        <th>Position</th> |
        <th>Interview</th> |
        <th>Deadline</th> |
        <th>Completed</th>
        <th></th>
      </tr>
      </thead>
      <tbody>
      <tr v-for="task in filteredTasks" :key="task" :class="{ 'completed-row': !task.isCompleted }">
        <td>{{ task.applicant.name }}</td> |
        <td>{{ task.applicant.surName }}</td> |
        <td>{{ task.applicant.lastName }}</td> |
        <td>{{ task.position.name }}</td> |
        <td>{{ formattedDate(task.applicant.interview) }}</td> |
        <td>{{ formattedDate(task.applicant.deadLine) }}</td> |
        <td>{{ task.isCompleted }}</td>
        <td>
          <button v-if="!task.isCompleted" @click="sendRequest(task.id)">Done</button>
          <button v-if="task.isCompleted" @click="sendRequest(task.id)">not done</button>
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
  name: "TasksIndex",

  data() {
    return {
      tasks: [],
      positionFilter: sessionStorage.getItem("position"),
    };
  },

  methods: {
    getAllTask() {
      axios
          .get(config.apiUrllocal + config.apiPort + "/Task")
          .then((response) => {
            this.tasks = response.data;
            console.log(response.data);
          })
          .catch((err) => {
            console.log(err.message);
          });
    },
    sendRequest(id) {
      axios.get(config.apiUrllocal + config.apiPort + "/Task/IsComplited/"+id)
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

    filteredTasks() {
      return this.tasks.filter((task) => task.position.name === this.positionFilter);
    },
  },

  created() {
    if (
        sessionStorage.getItem("role") === "admin" ||
        sessionStorage.getItem("role") === "hr" ||
        sessionStorage.getItem("role") === "teamlead"
    ) {
      console.log(this.positionFilter);
      this.getAllTask();
    } else {
      router.push("/");
    }
  },
};
</script>

<style scoped>
.container {
  max-width: 90%;
  margin: 0 auto;
  text-align: center;
  margin-right: -10%;
}

.completed-row {
  background-color: rgba(255, 0, 0, 0.5);
}
</style>
