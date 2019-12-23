<template>
    <div>
        {{ user }}
    </div>
</template>

<script>
import axios from 'axios'

export default {
    data() {
        return {
            user: {},
        }
    },
    created() {
        axios({
            method: "GET",
            url: "https://www.splitwise.com/api/v3.0/get_current_user"
        })
        .then(response => { this.user = response.data })
        .catch()
    }

}
</script>

<style>

</style>