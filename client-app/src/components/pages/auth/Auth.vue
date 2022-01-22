<template>
  <div class="background">
    <div class="card auth-card">
      <div class="card-image">
        <figure class="image is-4by3">
          <img src="../../../assets/logo.png" alt="Comic Book Network" />
        </figure>
      </div>
      <div class="card-content">

        <div class="tabs is-centered">
          <ul>
            <li @click="goToLoginTab" :class="isLoginMode ? 'is-active' : ''"><a>Log in</a></li>
            <li @click="goToRegisterTab" :class="!isLoginMode ? 'is-active' : ''"><a>Register</a></li>
          </ul>
        </div>

        <div class="content">
          <login v-if="isLoginMode" :isNavigatedFromRegistration="wasRegistrationSuccessful"></login>
          <register v-else @registered="registered"></register>
          <a target="_blank" rel="noopener noreferrer" href="https://github.com/" class="help">Go to help page</a>
        </div>
      </div>
    </div>

  </div>
</template>

<script>
import Login from './Login.vue';
import Register from './Register.vue';

export default {
  components: {
    Login,
    Register
  },
  data() {
    return {
      isLoginMode: true,
      wasRegistrationSuccessful: false
    }
  },
  methods: {
    registered() {
      this.isLoginMode = true;
      this.wasRegistrationSuccessful = true;
    },
    goToRegisterTab() {
      this.isLoginMode=false
      this.wasRegistrationSuccessful = false;
    },
    goToLoginTab() {
      this.isLoginMode=true
    }
  }
};
</script>

<style scoped>
.background {
  position: absolute;
  top: 0;
  left: 0;
  width: 100%;
  background: black;
  height: 100vh;
  display: flex;
  justify-content: center;
  align-items: center;
  background-image: url('../../../assets/authBackground.jpg');
}
.auth-card {
  width: 500px;
  height: 900px;
  box-shadow: rgba(0, 0, 0, 0.3) 0px 19px 38px,
    rgba(0, 0, 0, 0.22) 0px 15px 12px;
}

.help {
  margin-top: 2em;
  display: inline-block;
}
</style>
