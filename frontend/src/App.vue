<template>
  <nav>
    <router-link to="/">Home</router-link> |
    <router-link to="/applicant">Applicant</router-link> |
    <router-link to="/task">Tasks</router-link> |
    <router-link to="/employee">Employee</router-link> |
    <router-link to="/position">Position</router-link> |
    <template v-if="!isAuth">
      <router-link to="/login">Log In</router-link> |
      <router-link to="/register">Register</router-link> |
    </template>
    <template v-else>
      <a> {{getUser}} </a> |
      <button @click="logout"> Logout</button>
    </template>
  </nav>
  <router-view/>
</template>
<script>


import router from "@/router";

export default{
  data() {
    return {
      user: "",
      role: "No role"
    }
  },
  methods:{
    logout(){
      sessionStorage.removeItem("tokenKey");
      sessionStorage.removeItem("email");
      sessionStorage.removeItem("name");
      sessionStorage.removeItem("surName");
      sessionStorage.removeItem("lastName");
      sessionStorage.removeItem("role");
      router.push("/login")

    },

  },
  computed:{
    isAuth(){
      console.log(sessionStorage.getItem("tokenKey"))
      return !!sessionStorage.getItem("tokenKey")
    },
    getUser(){

      return sessionStorage.getItem("email")
    }

  }

}

</script>
<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}

nav {
  padding: 30px;
}

nav a {
  font-weight: bold;
  color: #2c3e50;
}

nav a.router-link-exact-active {
  color: #42b983;
}



</style>
