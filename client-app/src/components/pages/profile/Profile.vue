<template>
  <div class="profile-container">
    <h2 class="title is-3">Your Profile</h2>
    <div v-if="!isLoading">
      <form @submit.prevent="save">

        <div class="field">
          <label class="label">Username</label>
          <p data-test="username">{{userName}}</p>
        </div>

        <div class="field">
          <label class="label">Country</label>
          <div class="control">
            <input class="input" type="text" v-model="country" data-test="country"/>
          </div>
        </div>

        <div class="field">
          <label class="label">About me</label>
          <div class="control">
            <textarea class="textarea" v-model="introduction" data-test="about-me"></textarea>
          </div>
        </div>
      
        <button type="submit" class="button is-link">Save Changes</button>
      </form>
    </div>
    <main-loading-spinner v-else></main-loading-spinner>
  </div>
</template>

<script>
export default {
  data() {
    return {
      isLoading: false,
      country: "",
      introduction: "",
      userName: ""
    };
  },
  created() {
    this.loadProfile();
  },
  methods: {
    async loadProfile() {
      this.isLoading = true;
      try {
        const response = await fetch(
          `${process.env.VUE_APP_ROOT_API}/users/${localStorage.getItem('username')}`,
          {
            headers: {
              Authorization: 'Bearer ' + localStorage.getItem('token'),
            },
          }
        );
        const responseData = await response.json();

        if (!response.ok) {
          const error = new Error(responseData.message || 'Failed to fetch!');
          throw error;
        }

        const m = {
          id: responseData.id,
          userName: responseData.userName,
          introduction: responseData.introduction,
          country: responseData.country,
        };

        this.userName = m.userName;
        this.introduction = m.introduction;
        this.country = m.country;

      } catch (error) {
        this.error = error.message || 'Something went wrong!';
      }
      this.isLoading = false;
    },
    async save() {
      this.isLoading = true;

      try {
        await fetch(
          `${process.env.VUE_APP_ROOT_API}/users`,
          {
            method: 'PUT',
            headers: {
              Authorization: 'Bearer ' + localStorage.getItem('token'),
              "content-type": "application/json"
            },
            body: JSON.stringify({
              country: this.country,
              introduction: this.introduction,
            })
          }
        );
        this.$toast.success('Saved successfully.');

      } catch (error) {
        this.error = error.message || 'Something went wrong!';
      }
      this.isLoading = false;
    },
  },
};
</script>

<style scoped>
.profile-container {
  max-width: 450px;
  margin: 0 auto;
}
</style>