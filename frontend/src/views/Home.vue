<template>
    <div class="home">
        <app-user></app-user>
    </div>
</template>

<script>
// @ is an alias to /src
import User from '@/components/user/User'

export default {
    name: 'home',
    components: {
        appUser: User,
    }
}
</script>
