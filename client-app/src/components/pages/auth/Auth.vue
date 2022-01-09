<template>
  <div class="background">
  <n-card class="card">
    <template #cover>
      <img src="../../../assets/logo.png" alt="Comic Book Network">
    </template>
    <n-tabs default-value="signin" size="large" justify-content="space-evenly">
      <n-tab-pane name="signin" tab="Sign in">
        <login></login>
      </n-tab-pane>
      <n-tab-pane name="signup" tab="Sign Up">
        <register></register>
      </n-tab-pane>
    </n-tabs>
    <p>Go to help page</p>
  </n-card>
  </div>
</template>

<script>
import { NCard, NTabs, NTabPane } from 'naive-ui';
import Login from './Login.vue';
import Register from './Register.vue';

export default {
  components: {
    NCard, NTabs, NTabPane, Login, Register
  }
}
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
.card {
  max-width: 500px;
  box-shadow: rgba(0, 0, 0, 0.3) 0px 19px 38px, rgba(0, 0, 0, 0.22) 0px 15px 12px;
}
</style>