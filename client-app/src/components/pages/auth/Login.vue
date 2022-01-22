<template>
  <form @submit.prevent="login">
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

    <!-- <div class="field">
    <label class="label">Password</label>
    <div class="control has-icons-left has-icons-right">
      <input
        class="input is-success"
        type="text"
        placeholder="Text input"
        value="bulma"
      />
      <span class="icon is-small is-left">
        <i class="fas fa-user"></i>
      </span>
      <span class="icon is-small is-right">
        <i class="fas fa-check"></i>
      </span>
    </div>
    <p class="help is-success">This username is available</p>
  </div>

  <div class="field">
    <label class="label">Email</label>
    <div class="control has-icons-left has-icons-right">
      <input
        class="input is-danger"
        type="email"
        placeholder="Email input"
        value="hello@"
      />
      <span class="icon is-small is-left">
        <i class="fas fa-envelope"></i>
      </span>
      <span class="icon is-small is-right">
        <i class="fas fa-exclamation-triangle"></i>
      </span>
    </div>
    <p class="help is-danger">This email is invalid</p>
  </div> -->

    <div v-if="error" class="error">{{ error }}</div>

    <div class="field is-grouped">
      <!-- <div class="control"> -->
        <button
          type="submit"
          class="button is-primary sign-in-btn"
          :disabled="shouldLoginBtnBeDisabled"
        >
          <span v-if="!isLoading">Sign In</span>
          <loading-spinner v-else></loading-spinner>
        </button>
      <!-- </div> -->
    </div>
  </form>
</template>

<script>
import LoadingSpinner from '../../ui/LoadingSpinner.vue';

export default {
  components: {
    LoadingSpinner,
  },
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
</style>
