<template>
    <div>
        {{ user }}
        {{ getToken }}
    </div>
</template>

<script>
import axios from '@/splitloot_axios'
import { mapGetters } from 'vuex'

export default {
    data() {
        return {
            user: {},
        }
    },
    computed: {
        ...mapGetters(["getToken", "isAuthenticated"]),
    },
    created() {
        if (this.isAuthenticated) {
            axios({
                method: "get",
                url: "api/v1/splitwise/user",
            })
            .then(response => { console.log(response.data); this.user = response.data })
            .catch(error => { console.log(error); })
        }
    }

}
</script>

<style>

</style>