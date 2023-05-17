<template>
  <div>
    <h3>Log In</h3>
    <form @submit.prevent>
      <div class="form-group">
        <label>Email</label>
        <br/>
        <input
            v-bind:value="login"
            @input = "login = $event.target.value"
            class="form-control"
            type="text"
            placeholder="Email"
        />
      </div>
      <div class="form-group">
        <label>Password</label>
        <br/>
        <input
            v-bind:value="password"
            @input="password = $event.target.value"
            class="form-control"
            type="password"
            placeholder="Password"
        />
      </div>
      <div class="form-group">
        <button
            @click="loginPost"
            type="submit"
            class="m-2 btn btn-outline-dark"
        >Log In</button>

      </div>
    </form>
  </div>
</template>

<script>
import config from "@/config/config";
import router from "@/router";
import axios from "axios";

export default {
  name: "LoginForm",
  data() {
    return {
      login: "",
      password: "",
    }
  },
  methods: {
    loginPost() {
      axios.post(config.apiUrllocal + config.apiPort + "/Account/login", {
        login: this.login,
        password: this.password,
      })
          .then((response) => {
            console.log(response.data.value);
            const crntUser = response.data.value.crntUser;

            if (crntUser) {
              sessionStorage.setItem("tokenKey", response.data.value.access_token);
              sessionStorage.setItem("email", crntUser.email);
              sessionStorage.setItem("id", crntUser.id);
              sessionStorage.setItem("name", crntUser.name);
              sessionStorage.setItem("surName", crntUser.surName);
              sessionStorage.setItem("lastName", crntUser.lastName);
              sessionStorage.setItem("role", crntUser.role.name);
              sessionStorage.setItem("position", response.data.value.position);
              router.push("/");
            } else {
              console.error("Current user is null or undefined");
              router.push("/")
            }
          })
          .catch((error) => {
            router.push("/")
            console.error(error);
          });
    }
  },

}
</script>