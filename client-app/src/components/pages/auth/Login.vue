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
        type="text"
        maxlength="40"
        placeholder=""
        v-model:value="password"
      />
    </n-form-item-row>
    <!-- <n-button type="primary" block @click="login">Sign In</n-button> -->
    <n-button type="primary" @click="login" block :disabled="isLoading">
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
      isLoading: false
    }    
  },
  methods: {
    async login() {
      // this.formIsValid = true;
      // if (
      //   this.email === '' ||
      //   !this.email.includes('@') ||
      //   this.password.length < 6
      // ) {
      //   this.formIsValid = false;
      //   return;
      // }

      this.isLoading = true;

      const actionPayload = {
        // email: this.email,
        username: this.username.trim(),
        password: this.password.trim(),
      };

      try {
        // if (this.mode === 'login') {
        //   await this.$store.dispatch('login', actionPayload);
        // } else {
        //   await this.$store.dispatch('signup', actionPayload);
        // }
        await this.$store.dispatch('login', actionPayload);
        // const redirectUrl = '/' + (this.$route.query.redirect || 'coaches');
        this.$router.replace('/dashboard');
        console.log(actionPayload)


      } catch (err) {
        this.error = err.message || 'Failed to authenticate, try later.';
      }

      this.isLoading = false;
    }
  }
}
</script>