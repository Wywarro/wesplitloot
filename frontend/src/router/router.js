import Vue from 'vue'
import VueRouter from 'vue-router'
// import axios from 'axios'

import Home from '@/views/Home.vue'
import Login from '@/views/Login.vue'
import TokenHandler from '@/views/TokenHandler.vue'

import store from '@/store/store'

Vue.use(VueRouter)

const routes = [
    {
        path: '',
        name: 'home',
        component: Home,
        beforeEnter: (to, from, next) => {
            if(store.getters.isAuthenticated) {
                next();
            } else {
                location.replace('http://localhost:61307/accounts/splitwise/login')
                next();
            }
        }
    },
    {
        path: '/login',
        name: 'login',
        component: Login
    },
    {
        path: '/accounts/splitwise/token-handler',
        name: 'tokenHandler',
        component: TokenHandler
    }
]

const router = new VueRouter({
    mode: 'history',
    base: process.env.BASE_URL,
    routes
})

export default router
