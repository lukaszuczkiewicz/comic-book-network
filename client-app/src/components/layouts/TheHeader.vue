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
          <animated-button link to="/auth">Logout</animated-button>
        </li>
        <!-- <li v-if="isLoggedIn">
          <base-button @click="logout">Logout</base-button>
        </li> -->
        <animated-button></animated-button>
      </ul>
    </nav>
  </header>
</template>

<script>
import AnimatedButton from './AnimatedButton.vue';

export default {
  components: {
    AnimatedButton
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