<template>
  <header>
    <nav>
      <router-link to="/">
        <img src="../../assets/logo.png" alt="Comic Book Network" class="logo">
      </router-link>
      <ul>
        <li>
          <animated-button link to="/dashboard">Dashboard</animated-button>
        </li>
        <li>
          <animated-button link to="/profile/myid/">My profile</animated-button>
        </li>
        <li>
          <animated-button link to="/comics">Browse</animated-button>
        </li>
        <li>
          <animated-button link to="/search">Search</animated-button>
        </li>
        <li>
          <animated-button @click="logout">Logout</animated-button>
        </li>
        <!-- <li v-if="isLoggedIn">
          <base-button @click="logout">Logout</base-button>
        </li> -->
        <n-avatar
          round
          size="large"
          :src="require('../../assets/defaultAvatar.jpg')"
        />
      </ul>
    </nav>
  </header>
</template>

<script>
import AnimatedButton from './AnimatedButton.vue';
import { NAvatar } from 'naive-ui';

export default {
  components: {
    AnimatedButton,
    NAvatar
  },
  methods: {
    logout() {
      this.$store.dispatch('logout');
      this.$router.replace('/auth');
    }
  }
}
</script>

<style scoped>
.logo {
  width: 100px;
}
header {
  width: 100%;
  background-color: #368176;
  display: flex;
  justify-content: center;
  align-items: center;
  box-shadow: 0px 4px 21px -6px rgba(66, 68, 90, 1);
}

header a {
  text-decoration: none;
  color: #f391e3;
  display: inline-block;
  padding: 0.75rem 1.5rem;
  border: 1px solid transparent;
}

/* a:active,
a:hover,
a.router-link-active {
  border: 1px solid #f391e3;
} */

h1 {
  margin: 0;
}

h1 a {
  color: white;
  margin: 0;
}

h1 a:hover,
h1 a:active,
h1 a.router-link-active {
  border-color: transparent;
}

header nav {
  width: 90%;
  margin: auto;
  display: flex;
  justify-content: space-between;
  align-items: center;
}

header ul {
  list-style: none;
  margin: 0;
  padding: 0;
  display: flex;
  justify-content: center;
  align-items: center;
}

li {
  margin: 0 0.5rem;
}
</style>