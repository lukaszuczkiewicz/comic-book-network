<template>
  <n-form @submit.prevent="login">
    <n-form-item-row label="Username">
      <n-input
        type="text"
        placeholder=""
        maxlength="20"
        v-model:value="username"
      />
    </n-form-item-row>
    <n-form-item-row label="Password">
      <n-input
        type="password"
        maxlength="20"
        placeholder=""
        v-model:value="password"
      />
    </n-form-item-row>
    <div v-if="error" class="error">{{error}}</div>
    <n-button type="primary" attr-type="submit" block :disabled="shouldLoginBtnBeDisabled">
      <span v-if="!isLoading">Sign In</span>
      <loading-spinner v-else></loading-spinner>
    </n-button>
  </n-form>
</template>


<script>
import { NForm, NFormItemRow, NButton, NInput } from 'naive-ui';
import LoadingSpinner from '../../ui/LoadingSpinner.vue';

export default {
  components: {
    NForm, NFormItemRow, NButton, NInput, LoadingSpinner
  },
  data() {
    return {
      username: '',
      password: '',
      isLoading: false,
      error: ""
    }    
  },
  computed: {
    shouldLoginBtnBeDisabled() {
      return this.isLoading || this.username.length <= 0 || this.password.length <= 0;
    }
  },
  methods: {
    async login() {
      this.error="";
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
    }
  }
}
</script>

<style scoped>
.error {
  background: red;
  color: white;
  margin-bottom: 1em;
}
</style>