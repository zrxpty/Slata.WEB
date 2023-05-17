import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/HomeView.vue'

import EmployeeIndex from "@/components/EmployeeComponent/EmployeeIndex.vue";
import PositionIndex from "@/components/PositionComponent/PositionIndex.vue";
import PositionAdd from "@/components/PositionComponent/PositionAdd.vue";
import Login from "@/components/Account/Login.vue";
import Register from "@/components/Account/Register.vue";
import EmployeeEdit from "@/components/EmployeeComponent/EmployeeEdit.vue";
import ApplicantIndex from "@/components/Applicant/ApplicantIndex.vue";
import ApplicantAdd from "@/components/Applicant/ApplicantAdd.vue";
import ApplicantEdit from "@/components/Applicant/ApplicantEdit.vue";
import TasksIndex from "@/components/Task/TasksIndex.vue";



const routes = [
  {
    path: '/',
    name: 'home',
    component: HomeView,
    meta: {
      title: 'Home'
    },
    beforeEnter: (to, from, next) => {
      document.title = to.meta.title
      next()
    }
  },
  {
    path: "/employee",
    name: 'employee',
    component: EmployeeIndex,
    meta: {
      title: 'Employee List'
    },
    beforeEnter: (to, from, next) => {
      document.title = to.meta.title
      next()
    }
  },
  {
    path: "/employeeEdit/:id",
    name: "employeeEdit",
    component: EmployeeEdit,
    meta: {
      title: 'Employee Edit'
    },
    beforeEnter: (to, from, next) => {
      document.title = to.meta.title
      next()
    }

  },
  {
    path: "/position",
    name: 'position',
    component: PositionIndex,
    meta: {
      title: 'Position List'
    },
    beforeEnter: (to, from, next) => {
      document.title = to.meta.title
      next()
    }
  },
  {
    path: "/positionAdd",
    name: 'positionAdd',
    component: PositionAdd,
    meta: {
      title: 'Position Add'
    },
    beforeEnter: (to, from, next) => {
      document.title = to.meta.title
      next()
    }
  },
  {
    path: "/login",
    name: "login",
    component: Login,
    meta: {
      title: 'Login'
    },
    beforeEnter: (to, from, next) => {
      document.title = to.meta.title
      next()
    }
  },
  {
    path: "/register",
    name: "register",
    component: Register,
    meta: {
      title: 'Register'
    },
    beforeEnter: (to, from, next) => {
      document.title = to.meta.title
      next()
    }
  },
  {
    path: "/applicant",
    name: "applicant",
    component: ApplicantIndex,
    meta: {
      title: 'Applicant List'
    },
    beforeEnter: (to, from, next) => {
      document.title = to.meta.title
      next()
    }
  },
  {
    path: "/applicantAdd",
    name: "applicantAdd",
    component: ApplicantAdd,
    meta: {
      title: 'Applicant Add'
    },
    beforeEnter: (to, from, next) => {
      document.title = to.meta.title
      next()
    }

  },
  {
    path: "/applicantEdit/:id",
    name: "applicantEdit",
    component: ApplicantEdit,
    meta: {
      title: 'Applicant Edit'
    },
    beforeEnter: (to, from, next) => {
      document.title = to.meta.title
      next()
    }
  },
  {
    path: "/task",
    name: "task",
    component: TasksIndex,
    meta: {
      title: 'Task list'
    },
    beforeEnter: (to, from, next) => {
      document.title = to.meta.title
      next()
    }
  }



]

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes
})

export default router
