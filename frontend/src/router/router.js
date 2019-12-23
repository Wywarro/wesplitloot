import Vue from 'vue'
import VueRouter from 'vue-router'
// import axios from 'axios'

import Home from '@/views/Home.vue'
import Login from '@/views/Login.vue'
import Callback from '@/components/Callback.vue'

import store from '@/store/store'

Vue.use(VueRouter)

const routes = [
    {
        path: '',
        name: 'home',
        component: Home
    },
    {
        path: '/login',
        name: 'login',
        component: Login
    },
    {
        path: '/oauth/callback',
        name: 'callbeck',
        component: Callback
    }
]

const router = new VueRouter({
    mode: 'history',
    base: process.env.BASE_URL,
    routes
})

router.beforeEach((to, from, next) => {
    if(!store.getters.isAuthenticated) {
        next();
    } else {
        next()
    }
});

export default router
