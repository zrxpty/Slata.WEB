<template>
  <div>
    <form @submit.prevent>
      <h3>Register</h3>
      <div class="form-group">
        <label>Email:</label>
        <br/>
        <input
            v-bind:value="login"
            @input = "login = $event.target.value"
            class="form-control"
            type="text"
            placeholder="Email"

        />
        <span v-if="loginError" class="error">{{ loginError }}</span>
      </div>
      <div class="form-group">
        <label>Name:</label>
        <br/>
        <input
            v-bind:value="name"
            @input = "name = $event.target.value"
            class="form-control"
            type="text"
            placeholder="Name"

        />

      </div>
      <div class="form-group">
        <label>Surname:</label>
        <br/>
        <input
            v-bind:value="surName"
            @input = "surName = $event.target.value"
            class="form-control"
            type="text"
            placeholder="Surname"

        />

      </div>
      <div class="form-group">
        <label>Lastname:</label>
        <br/>
        <input
            v-bind:value="lastName"
            @input = "lastName = $event.target.value"
            class="form-control"
            type="text"
            placeholder="LastName"

        />

      </div>
      <div class="form-group">
        <label>Password:</label>
        <br/>
        <input
            v-bind:value="password"
            @input="password = $event.target.value"
            class="form-control"
            placeholder="Password"
        />
        <span v-if="passwordError" class="error">{{ passwordError }}</span>
      </div>
      <div class="form-group">
        <label>Confirm password:</label>
        <br/>
        <input
            v-bind:value="confirm"
            @input="confirm = $event.target.value"
            class="form-control"
            placeholder="Confirm password"
        />
        <span v-if="confirmError" class="error">{{ confirmError }}</span>
      </div>
      <div class="form-group">
        <button
            @click="createUser"
            type="submit"
            class="m-2 btn btn-outline-dark"
        >Register</button>
      </div>
    </form>
  </div>
</template>

<script>
import config from "@/config/config";
import router from "@/router";
import axios from "axios";

export default {
  name: "RegisterForm",
  data() {
    return {
      login: "",
      password: "",
      confirm: "",
      name: "",
      surName: "",
      lastName: "",
      loginError: "",
      passwordError: "",
      confirmError: "",
      value: ""
    }
  },
  methods: {
    validateForm() {
      let valid = true;
      this.loginError = "";
      this.passwordError = "";
      this.confirmError = "";

      if (!this.login) {
        this.loginError = "Email is required";
        valid = false;
      } else if (!/\S+@\S+\.\S+/.test(this.login)) {
        this.loginError = "Email is invalid";
        valid = false;
      }

      if (!this.password) {
        this.passwordError = "Password is required";
        valid = false;
      } else if (this.password.length < 6) {
        this.passwordError = "Password must be at least 6 characters long";
        valid = false;
      }

      if (!this.confirm) {
        this.confirmError = "Confirmation is required";
        valid = false;
      } else if (this.confirm !== this.password) {
        this.confirmError = "Passwords do not match";
        valid = false;
      }

      return valid;
    },
    async createUser() {
      if (this.validateForm()) {
        try {
          this.confirm = "";
          await axios.post(config.apiUrllocal+config.apiPort+'/Account', {
            login: this.login,
            password: this.password,
            name: this.name,
            surName: this.surName,
            lastName: this.lastName,
            value: this.value,
          }).then(response =>{
            console.log(response.data)
              if (response.data.value === "Failed to create user")
              {
                alert("The user already exists with this email")
              }
               else {
                this.password = "";
                this.login = "";
                router.push("/login");
              }
              });
        } catch(e) {
          if (e.response && e.response.data === 'User already exists') {
            this.loginError = 'User already exists';
          } else {
            console.log('Error:', e);
          }
        }
      }
    }

  }
}
</script>

<style>
.error {
  color: red;
  font-size: 14px;
  margin-top: 4px;
}
</style>
