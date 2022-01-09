<template>
  <n-form @submit.prevent="submitForm">
    <n-form-item-row label="Username">
      <n-input
        placeholder="Enter Username"
        maxlength="40"
        v-model.trim="username"
      />
    </n-form-item-row>
    <n-form-item-row label="Password">
      <n-input
        placeholder="Enter Password"
        maxlength="40"
        v-model.trim="password"
      />
    </n-form-item-row>
    <n-button type="primary" block @click="submitForm">Sign In</n-button>
  </n-form>
</template>


<script>
import { NForm, NInput, NFormItemRow, NButton } from 'naive-ui';

export default {
  components: {
    NForm, NInput, NFormItemRow, NButton
  },
  data() {
    return {
      username: '',
      password: '',
      formIsValid: true,
    }    
  },
  methods: {
    submitForm() {
      const redirectUrl = '/dashboard'
        this.$router.replace(redirectUrl);
    }
  }
}
</script>