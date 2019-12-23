<template>
    <div>
    </div>
</template>

<script>
import axios from 'axios'
import { eventBus } from '@/main.js'

export default {
    created() {
        var code = this.$route.query.code

        axios({
            method: "POST",
            url: "oauth/token",
            data: {
                code: code,
            }
        })
        // eslint-disable-next-line no-console
        .then(response => {
            this.$store.dispatch("login", { token: response.data, isAuthenticated: true });
            window.close()
        })
        // eslint-disable-next-line no-console
        .catch(error => console.log('error', error));
    }
}
</script>

<style>

</style>