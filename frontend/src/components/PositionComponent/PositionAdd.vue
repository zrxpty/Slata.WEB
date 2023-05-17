<template>
  <form>
    <label>Name</label>
    <input type="text" v-model="name">

    <button @click.prevent="addPosition">Add Position</button>
  </form>
</template>

<script>
import axios from "axios";
import config from "@/config/config";
import router from "@/router";

export default {
  name: "PositionAdd",
  data() {
    return {
      name: "",
    };
  },
  methods: {
    addPosition() {
      axios.post(config.apiUrllocal +config.apiPort +'/Position/AddPosition', {
        name: this.name,
      })
          .then(response => {
            console.log(response);
            router.push("/position");
          })
          .catch(error => {
            console.log(error);
          });
    }
  }
}
</script>

<style scoped>

</style>