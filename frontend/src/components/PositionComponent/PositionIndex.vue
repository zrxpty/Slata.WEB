<template>
  <router-link to="/positionAdd">Add</router-link>
  <div class="container">

    <table>
      <thead>
      <tr>

        <th>Title</th>

      </tr>
      </thead>
      <tbody>
      <tr v-for="position in data" :key="position">
        <td>{{ position.name }}</td>
      </tr>
      </tbody>
    </table>
  </div>

</template>

<script>
import axios from "axios";
import config from "@/config/config";


export default {
  name: "PositionIndex",
  data() {
    return {
      data: []
    }
  },
  methods:{
    getAll: function (){
      axios.get(config.apiUrllocal +config.apiPort +'/Position', {

      }).then(response => {
        this.data = response.data

      }).catch(err => {
        console.log(err.message)
      })

    },

  },

  created() {
    this.getAll()
  }
}
</script>

<style scoped>
.container {
  max-width: 90%;
  margin: 0 auto;
  text-align: center;
  margin-right: -30%;
}

</style>