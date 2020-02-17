import store from "@/store/store.js"
import axios from "axios"

const instance = axios.create({});

instance.defaults.headers.common["Authorization"] = `Bearer ${store.getters.getToken}`;

export default instance;