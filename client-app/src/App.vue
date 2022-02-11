<template>
  <the-header v-if="$route.path != '/auth'"></the-header>
  <div class="wrapper" id="wrapper">
    <router-view v-slot="slotProps">
      <transition name="route" mode="out-in">
        <component :is="slotProps.Component"></component>
      </transition>
    </router-view>
  </div>
</template>

<script>
import TheHeader from './components/layouts/TheHeader.vue';
export default {
  components: { TheHeader },
};
</script>

<style lang="scss">
body {
  margin: 0;
  background: #f2f4f5;
  position: relative;
  padding: 0;
}
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  position: relative;
  min-height: 100vh;
}
a {
  text-decoration: none;
}
.wrapper {
  max-width: 1000px;
  margin: 0 auto;
  padding: 1.5em 1em;
}

// transitions
.route-leave-to,
.route-enter-from {
  opacity: 0;
}

.route-enter-active,
.route-leave-active {
  transition: all 0.3s ease-out;
}

.route-enter-to,
.route-leave-from {
  opacity: 1;
}
</style>
