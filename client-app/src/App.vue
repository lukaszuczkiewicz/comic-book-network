<template>
  <the-header v-if="$route.path!='/auth'"></the-header>
  <router-view/>
</template>

<script>
import TheHeader from './components/layouts/TheHeader.vue';
export default {
  components: {TheHeader},
}
</script>

<style lang="scss">
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}
body {
  margin: 0;
  background: #f2f4f5;
  min-height: 100vh;
}
a {
  text-decoration: none;
}
</style>
