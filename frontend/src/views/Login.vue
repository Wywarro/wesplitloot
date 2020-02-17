<template>
    <div>
        <v-btn 
            @click="splitwiseSignIn()"
        >
            Login with Splitwise
        </v-btn>
    </div>
</template>

<script>
export default {
    data() {
        return {
            
        }
    },
    methods: {
        splitwiseSignIn() {
            var url = `${process.env.VUE_APP_API_URL}/accounts/splitwise/login`
            return location.replace(url);
        },
    },
}
</script>

<style>

</style>