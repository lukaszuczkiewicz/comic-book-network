<template>
  <main class="main">
    <n-form @submit.prevent="submitForm" class="form">
      <n-form-item-row>
        <n-input
          placeholder="Enter Name"
          maxlength="40"
          v-model.trim="enteredName"
        />
        <n-select v-model:value="selectValue" :options="options" />
      </n-form-item-row>
      <n-button type="primary" block @click="submitForm">Search</n-button>
    </n-form>
  </main>
</template>

<script>

export default {
  data() {
    return {
      enteredName: '',
      selectValue: 'Series',
      formIsValid: true,
      options: [
        {
          label: 'Series',
          value: 'Series',
        },
        {
          label: 'Comics',
          value: 'Comics',
        },
      ],
    };
  },
  methods: {
    submitForm() {},
  },
};
</script>
<style scoped>
.main {
  display: flex;
  justify-content: center;
}
</style>
