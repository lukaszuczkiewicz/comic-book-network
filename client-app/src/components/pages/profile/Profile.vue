<template>
  <div>
    <div v-if="!isLoading">

      <form @submit.prevent="save">

        <div class="field">
          <label class="label">Username</label>
          <p>{{userName}}</p>
  
        </div>

        <div class="field">
          <label class="label">Country</label>
          <div class="control">
            <input class="input" type="text" v-model="country" />
          </div>
        </div>

        <div class="field">
          <label class="label">About me</label>
          <div class="control">
            <input class="input" type="text" v-model="introduction" />
          </div>
        </div>
      
        <button type="submit" class="button is-link">Save Changes</button>
      </form>

    </div>
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
          'https://localhost:5001/api/users/' +
            localStorage.getItem('username'),
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

        console.log(responseData);

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
        const response = await fetch(
          'https://localhost:5001/api/users',
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
        const responseData = await response.json();

        if (!response.ok) {
          const error = new Error(responseData.message || 'Failed to update!');
          throw error;
        }

        console.log(responseData);

      } catch (error) {
        this.error = error.message || 'Something went wrong!';
      }
      this.isLoading = false;
    },
  },
};
</script>
