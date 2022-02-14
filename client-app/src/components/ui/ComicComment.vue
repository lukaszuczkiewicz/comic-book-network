<template>
  <div class="card comment">
    <img :src="require('../../assets/defaultAvatar.jpg')" class="avatar" />
    <div class="main-content">
      <div class="header">
        <div>
          <span class="username">{{ username }}</span>
          <span class="date">{{ date }}</span>
        </div>
        <button
          v-if="displayDeleteBtn"
          @click="deleteComment"
          class="button is-danger is-small is-outlined delete-btn">Delete
        </button>
      </div>
      <p class="text-content">{{ description }}</p>
    </div>
  </div>
</template>

<script>
export default {
  props: {
    id: {
      required: true,
      type: Number,
    },
    date: {
      required: true,
      type: String,
    },
    description: {
      required: true,
      type: String,
    },
    username: {
      required: true,
      type: String,
    },
    displayDeleteBtn: {
      default: false,
      type: Boolean,
    },
  },
  emits: ['refresh'],
  methods: {
    async deleteComment() {
      this.isLoading = true;

      try {
        const response = await fetch(
          `${process.env.VUE_APP_ROOT_API}/comiccomment/${this.id}`,
          {
            method: 'DELETE',
            headers: {
              Authorization: 'Bearer ' + localStorage.getItem('token'),
              'content-type': 'application/json',
            },
          }
        );

        if (!response.ok) {
          const error = new Error(
            response.message || 'Failed to delete comment!'
          );
          this.$toast.error('Comment was not deleted!');
          throw error;
        }

        this.$toast.success('Comment deleted successfully.');
        this.$emit('refresh');
      } catch (error) {
        this.error = error.message || 'Comment was not deleted!';
      }
    },
  },
};
</script>

<style scoped>
.comment {
  display: flex;
  margin-bottom: 1em;
  padding: 1em;
  text-align: left;
}
.avatar {
  border-radius: 100%;
  width: 50px;
  margin-right: 0.5em;
  align-self: flex-start;
}
.main-content {
  width: 100%;
}
.header {
  display: flex;
  justify-content: space-between;
}
.username {
  font-weight: bold;
  margin-right: 0.4em;
}
.date {
  color: #999999;
  font-size: 0.75em;
}
</style>
