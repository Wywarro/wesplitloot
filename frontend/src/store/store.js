import Vue from 'vue'
import Vuex from 'vuex'

import axios from 'axios'

Vue.use(Vuex)

export default new Vuex.Store({
    state: {
        token: null,
        userName: null
    },
    mutations: {
        authUser(state, userData) {
            state.token = userData.token
            state.userName = userData.userName
        }
    },
    actions: {
        signup({ commit }, authData) {
            axios({
                url: 'accounts/register',
                method: 'post',
                data: {
                    email: authData.email,
                    password: authData.password,
                    confirmPassword: authData.confirmPassword,
                    firstName: authData.firstName,
                    lastName: authData.lastName,
                }
                .then(response => {
                    // eslint-disable-next-line no-console
                    console.log(response);
                    commit('authUser', {
                        token: response.data.token,
                        useName: response.data.userName,
                    })
                })
                // eslint-disable-next-line no-console
                .catch(error => console.log(error))
            })
        },
        login({ commit }, authData) {
            axios({
                url: 'accounts/login',
                method: 'post',
                data: {
                    email: authData.email,
                    password: authData.password,
                }
                .then(response => {
                    // eslint-disable-next-line no-console
                    console.log(response);
                    commit('authUser', {
                        token: response.data.token,
                        useName: response.data.userName,
                    })
                })
                // eslint-disable-next-line no-console
                .catch(error => console.log(error))
            });
        },
    },
    modules: {
    }
})
