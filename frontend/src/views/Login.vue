<template>
    <div>
        <v-btn 
            target="popup" 
            @click="open()">
            Login
        </v-btn>
    </div>
</template>

<script>
import { eventBus } from '@/main.js'

export default {
    data() {
        return {
            loginWindow: null
        }
    },
    methods: {
        open() {
            var url = location.origin + "/api/v1/oauth/login"
            this.loginWindow = window.open(
                url,
                'popup',
                'width=1600,height=800'); 
            return false;
        },
        close() {
            this.loginWindow.close();
        },
    },
    created() {
        eventBus.$on("loggedIn", home => {
            // eslint-disable-next-line no-console
            console.log("Hi")
            this.close()
            this.$router.push({ name: home })
        });
    }
}
</script>

<style>

</style>