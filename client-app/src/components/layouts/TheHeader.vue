<template>
  <header>
    <nav class="navbar" role="navigation" aria-label="main navigation">
      <div class="navbar-brand">
        <router-link class="navbar-item" to="/">
          <img
            src="../../assets/logo.png"
            alt="Comic Book Network"
            class="logo"
          />
        </router-link>

        <a
          role="button"
          class="navbar-burger"
          aria-label="menu"
          aria-expanded="false"
          data-target="navbarBasicExample"
        >
          <span aria-hidden="true"></span>
          <span aria-hidden="true"></span>
          <span aria-hidden="true"></span>
        </a>
      </div>

      <div id="navbarBasicExample" class="navbar-menu">
        <div class="navbar-start">
          <router-link to="/dashboard" class="navbar-item"
            >Dashboard</router-link
          >
          <router-link to="/comics" class="navbar-item">Browse</router-link>
          <router-link to="/profile/myid" class="navbar-item"
            >Lists</router-link
          >
        </div>

        <div class="navbar-end">
          <div class="navbar-item has-dropdown is-hoverable">
            <div class="avatar-container">
              <img :src="require('../../assets/defaultAvatar.jpg')" class="avatar" />
            </div>
            <a class="navbar-link">Profile</a>

            <div class="navbar-dropdown">
              <a class="navbar-item">Profile</a>
              <a class="navbar-item">Settings</a>
              <a class="navbar-item">Help</a>
              <hr class="navbar-divider" />
              <a class="navbar-item" @click="logout">Logout </a>
            </div>
          </div>
        </div>
      </div>
    </nav>
  </header>
</template>

<script>

export default {
  methods: {
    logout() {
      this.$store.dispatch('logout');
      this.$router.replace('/auth');
    }
  }
};
</script>

<style scoped>
.avatar-container {
  display: flex;
  flex-direction: column;
  justify-content: center;
}
.avatar {
  border-radius: 100%;
}
</style>
