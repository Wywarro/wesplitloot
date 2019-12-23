import Vue from 'vue'
import App from './App.vue'
import router from './router/router'
import store from './store/store'
import vuetify from './plugins/vuetify';
import axios from 'axios'
import Vuelidate from 'vuelidate'

Vue.config.productionTip = false

axios.defaults.baseURL = "http://localhost:61308/api/v1/"
Vue.prototype.$http = axios;

Vue.use(Vuelidate);

export const eventBus = new Vue();

new Vue({
  router,
  store,
  vuetify,
  render: h => h(App)
}).$mount('#app')
