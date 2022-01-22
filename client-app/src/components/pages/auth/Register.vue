<template>
<form @submit.prevent="signup">
    <div class="field">
      <label class="label">Username</label>
      <div class="control">
        <input
          :class="isUsernameLengthOk? '' :'is-danger'"
          class="input"
          type="text"
          placeholder="Username"
          maxlength="20"
          v-model="username"
        />
        <p v-if="!isUsernameLengthOk" class="is-danger help">Username must be at least 6 characters long.</p>
      </div>
    </div>

    <div class="field">
      <label class="label">Password</label>
      <div class="control">
        <input
          :class="isPasswordLengthOk? '' :'is-danger'"
          class="input"
          type="password"
          placeholder="Password"
          maxlength="20"
          v-model="password1"
        />
        <p v-if="!isPasswordLengthOk" class="is-danger help">Password must be at least 6 characters long.</p>
      </div>
    </div>

    <div class="field">
      <label class="label">Repeat Password</label>
      <div class="control">
        <input
          :class="isPasswordValid? '' :'is-danger'"
          class="input"
          type="password"
          placeholder="Repeat Password"
          maxlength="20"
          v-model="password2"
        />
        <p v-if="!isPasswordValid" class="is-danger help">Passwords are not the same</p>
      </div>
    </div>

    <div v-if="error" class="error">{{ error }}</div>

    <div class="field is-grouped">
        <button
          type="submit"
          class="button is-primary sign-up-btn"
          :disabled="shouldRegisterBtnBeDisabled"
        >
          <span v-if="!isLoading">Register</span>
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
    LoadingSpinner
  },
  emits: ['registered'],
  data() {
    return {
      username: '',
      password1: '',
      password2: '',
      isLoading: false,
      error: ''
    };
  },
  computed: {
    shouldRegisterBtnBeDisabled() {
      return this.isLoading || this.username.length < 6 || this.password1.length < 6 || (this.password1 != this.password2);
    },
    isPasswordValid() {
      return (this.password1.length===0 || this.password2.length===0) //don't show error message when user didn't enter anything
        || (this.password1.length >= 6
        && this.password2.length >= 6
        && this.password1 === this.password2)
    },
    isPasswordLengthOk() {
      return this.password1.length===0 || this.password1.length >= 6
    },
    isUsernameLengthOk() {
      return this.username.length===0 || this.username.length >= 6
    }
  },
  methods: {
    async signup() {
      const usernameValue = this.username;
      const password1Value = this.password1;
      const password2Value = this.password2;

      this.isLoading = true;

      if (password1Value != password2Value) return;

      const actionPayload = {
        username: usernameValue,
        password: password1Value
      };

      try {
        await this.$store.dispatch('signup', actionPayload);
        this.$emit('registered');
      } catch (err) {
        'Username already exists';
      }

      this.isLoading = false;
    }
  },
};
</script>

<style scoped>
.sign-up-btn {
  width: 100%;
}
.help {
  margin-top: 2em;
  display: inline-block;
}
</style>