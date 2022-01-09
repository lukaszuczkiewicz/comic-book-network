<template>
  <n-form>
    <n-form-item-row label="Username">
      <n-input
        placeholder="Enter Username"
        maxlength="40"
        v-model.trim="username"
      />
    </n-form-item-row>
    <n-form-item-row label="Password">
      <n-input placeholder="Enter Password"
        maxlength="40"
        v-model.trim="password1" />
    </n-form-item-row>
    <n-form-item-row label="Reenter Password">
      <n-input placeholder="Enter Password"
        maxlength="40"
        v-model.trim="password2" />
    </n-form-item-row>
    <n-button type="primary" block>Sign Up</n-button>
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
    submitForm() {},
  },
};
</script>
