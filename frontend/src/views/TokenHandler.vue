<template>
    <div>
    </div>
</template>

<script>
export default {
    created() {
        this.$store.dispatch("login", { token: this.$route.query.t, isAuthenticated: true });
        return location.replace("http://localhost:8080");
    }
}
</script>

<style>

</style>