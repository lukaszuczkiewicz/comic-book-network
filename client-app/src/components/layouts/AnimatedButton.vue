<template>
  <router-link :to="to" class="link-container link-one" :class="mode">
    <slot></slot>
  </router-link>
</template>

<script>
export default {
  props: {
    mode: {
      type: String,
      required: false,
      default: null
    },
    link: {
      type: Boolean,
      required: false,
      default: false
    },
    to: {
      type: String,
      required: false,
      default: '/'
    }
  }
}
</script>


<style scoped>
@import url('https://fonts.googleapis.com/css2?family=Bungee&display=swap');

.link-container {
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
  height: 100%;
  position: relative;
  z-index: 0;
  cursor: pointer;
}

.link-one {
  background-color: #151515;
  font-family: "Bungee", cursive;
  font-size: 1.5em;
  color: #53d9d1;
  transition: color 0.5s cubic-bezier(0.32, 0, 0.67, 0);
  line-height: 1em;
  padding: 0.5em 1em;
}

.link-one:hover,
a.router-link-active {
  color: #111;
  transition: color 0.5s cubic-bezier(0.33, 1, 0.68, 1);
}

.link-one::before {
  content: "";
  position: absolute;
  z-index: -1;
  width: 100%;
  height: 100%;
  top: 0;
  right: 0;
  background-color: #53d9d1;

  clip-path: circle(0% at 50% calc(50%));
  transition: clip-path 0.5s cubic-bezier(0.65, 0, 0.35, 1);
}

.link-one:hover::before,
a.router-link-active::before {
  clip-path: circle(100% at 50% 50%);
}

.link-one:hover::after,
a.router-link-active::after {
  clip-path: polygon(
    40% 10%,
    60% 10%,
    60% 35%,
    40% 35%,
    40% 90%,
    60% 90%,
    60% 65%,
    40% 65%
  );
}
</style>