<template>
  <n-form>
    <n-form-item-row label="Username">
      <n-input
        placeholder=""
        maxlength="40"
        v-model:value="username"
      />
    </n-form-item-row>
    <n-form-item-row label="Password">
      <n-input
      placeholder=""
        maxlength="40"
        v-model:value="password1" />
    </n-form-item-row>
    <n-form-item-row label="Reenter Password">
      <n-input
      placeholder=""
        maxlength="40"
        v-model:value="password2" />
    </n-form-item-row>
    <n-button type="primary" block @click="signup">Sign Up</n-button>
  </n-form>
</template>

<script>
import { NForm, NInput, NFormItemRow, NButton } from 'naive-ui';

export default {
  components: {
    NForm,
    NInput,
    NFormItemRow,
    NButton,
  },
  data() {
    return {
      username: '',
      password1: '',
      password2: '',
      formIsValid: true,
    };
  },
  methods: {
    async signup() {
      // this.formIsValid = true;
      // if (
      //   this.email === '' ||
      //   !this.email.includes('@') ||
      //   this.password.length < 6
      // ) {
      //   this.formIsValid = false;
      //   return;
      // }

      // this.isLoading = true;

      if (this.password1.trim() != this.password2.trim()) return;

      const actionPayload = {
        username: this.username.trim(),
        password: this.password1.trim(),
      };

      try {
        // if (this.mode === 'login') {
        //   await this.$store.dispatch('login', actionPayload);
        // } else {
        //   await this.$store.dispatch('signup', actionPayload);
        // }
        await this.$store.dispatch('signup', actionPayload);
        // const redirectUrl = '/' + (this.$route.query.redirect || 'coaches');
        this.$router.replace('/dashboard');
        console.log(actionPayload)


      } catch (err) {
        this.error = err.message || 'Failed to authenticate, try later.';
      }

      // this.isLoading = false;
    },
  },
};
</script>
