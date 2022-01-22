<template>
  <n-form @submit.prevent="login">
    <n-form-item-row label="Username">
      <n-input
        type="text"
        placeholder=""
        maxlength="40"
        v-model:value="username"
      />
    </n-form-item-row>
    <n-form-item-row label="Password">
      <!-- <n-input
        placeholder="Enter Password"
        maxlength="40"
        v-model.trim="password"
      /> -->
      <n-input
        type="password"
        maxlength="40"
        placeholder=""
        v-model:value="password"
      />
    </n-form-item-row>
    <div v-if="error" class="error">{{error}}</div>
    <!-- <n-button type="primary" block @click="login">Sign In</n-button> -->
    <n-button type="primary" @click="login" block :disabled="shouldLoginBtnBeDisabled">
      <span v-if="!isLoading">Sign In</span>
      <loading-spinner v-else></loading-spinner>
    </n-button>
  </n-form>
  <!-- <div v-else class="spinner-background">
  </div> -->
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
      formIsValid: true,
      isLoading: false,
      error: ""
    }    
  },
  computed: {
    shouldLoginBtnBeDisabled() {
      return this.isLoading || this.username.length <= 0 || this.password.length <= 0;
    }
  },
  watch: {
    username() {
      this.error = '';
    },
    password() {
      this.error = '';
    }
  },
  methods: {
    async login() {
      this.formIsValid = true;
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
        this.formIsValid = false;
        this.password = '';
        this.error = 'Failed to authenticate. Login or password is not correct.'; 
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
}
</style>