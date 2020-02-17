import Vue from 'vue'
import App from './App.vue'
import router from './router/router'
import store from './store/store'
import vuetify from './plugins/vuetify';
import axios from 'axios'
import vuelidate from 'vuelidate'
import VueAuthenticate from 'vue-authenticate'

Vue.config.productionTip = false

axios.defaults.baseURL = "http://localhost:61308/api/v1/"
Vue.prototype.$http = axios;

Vue.use(vuelidate);
Vue.use(VueAuthenticate, {
    providers: {
        github: {
            clientId: '',
            redirectUri: 'http://localhost:8080/oauth/callback' // Your client app URL
        }
    }
})

export const eventBus = new Vue();

new Vue({
  router,
  store,
  vuetify,
  render: h => h(App)
}).$mount('#app')
