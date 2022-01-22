<template>
  <form @submit.prevent="login">
    <div v-if="isNavigatedFromRegistration" class="notification is-success">
      Successfully registered. You can now log in.
    </div>
    <div v-if="error && isLoading" class="notification is-danger">{{ error }}</div>
    <div class="field">
      <label class="label">Username</label>
      <div class="control">
        <input
          class="input"
          type="text"
          placeholder="Username"
          maxlength="20"
          v-model="username"
        />
      </div>
    </div>

    <div class="field">
      <label class="label">Password</label>
      <div class="control">
        <input
          class="input"
          type="password"
          placeholder="Password"
          maxlength="20"
          v-model="password"
        />
      </div>
    </div>


    <div class="field is-grouped">
      <button
        type="submit"
        class="button is-primary sign-in-btn"
        :disabled="shouldLoginBtnBeDisabled"
      >
        <span v-if="!isLoading">Log In</span>
        <loading-spinner v-else></loading-spinner>
      </button>
    </div>
    <a target="_blank" rel="noopener noreferrer" href="https://github.com/" class="help">Go to help page</a>
  </form>
</template>

<script>
import LoadingSpinner from '../../ui/LoadingSpinner.vue';

export default {
  components: {
    LoadingSpinner,
  },
  props: ['isNavigatedFromRegistration'],
  data() {
    return {
      username: '',
      password: '',
      isLoading: false,
      error: '',
    };
  },
  computed: {
    shouldLoginBtnBeDisabled() {
      return (
        this.isLoading || this.username.length <= 0 || this.password.length <= 0
      );
    },
  },
  methods: {
    async login() {
      this.error = '';
      const usernameValue = this.username.trim();
      const passwordValue = this.password.trim();

      this.isLoading = true;

      const actionPayload = {
        username: usernameValue,
        password: passwordValue,
      };

      try {
        await this.$store.dispatch('login', actionPayload);

        this.$router.replace('/dashboard');
      } catch (err) {
        this.password = '';
        this.error = 'Your username or password is incorrect.';
      }

      this.isLoading = false;
    },
  },
};
</script>

<style scoped>
.error {
  background: red;
  color: white;
  margin-bottom: 1em;
  padding: 0.25em 1em;
}

.sign-in-btn {
  width: 100%;
}
.help {
  margin-top: 2em;
  display: inline-block;
}
</style>
