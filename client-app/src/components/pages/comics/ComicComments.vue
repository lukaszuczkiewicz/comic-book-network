<template>
  <section class="comments-container">
    <form class="comment-form" @submit.prevent="addComment">
      <div>
        <label class="label">Comments</label>
        <div class="control">
          <textarea
            class="textarea"
            placeholder="Add your comment"
            maxlength="200"
            v-model="comment"
            :disabled="isLoading"
          ></textarea>
        </div>
      </div>
      <div class="add-comment-btn-wrapper">
        <button
          type="submit"
          :disabled="isLoading || comment.length===0"
          class="button is-dark add-comment-btn"
        >
          Add comment
        </button>
      </div>
    </form>

    <comic-comment
      @refresh="updateComments(c.id)"
      v-for="c in comments"
      :key="c.id"
      :id="c.id"
      :date="this.getConvertedDate(c.date)"
      :description="c.textContent"
      :username="c.username"
      :displayDeleteBtn="savedUsername === c.username"
    >
    </comic-comment>
  </section>
</template>

<script>
import ComicComment from '../../ui/ComicComment.vue';

export default {
  components: {
    ComicComment
  },
  data() {
    return {
      isLoading: true,
      comment: '',
      comments: [],
      savedUsername: localStorage.getItem('username')
    };
  },
  created() {
    this.loadComments();
  },
  methods: {
    updateComments(deletedCommentId) {
      this.comments = this.comments.filter(c => c.id != deletedCommentId);
    },
    async loadComments() {
      this.isLoading = true;

      try {
        const response = await fetch(
          `${process.env.VUE_APP_ROOT_API}/comiccomment/${this.$route.params.id2}`,
          {
            headers: {
              Authorization: 'Bearer ' + localStorage.getItem('token'),
            },
          }
        );
        const responseData = await response.json();

        if (!response.ok) {
          const error = new Error(
            responseData.message || 'Failed to fetch comments!'
          );
          throw error;
        }

        this.comments = [];

        for (const key in responseData) {
          const comment = {
            id: responseData[key].id,
            date: responseData[key].date,
            textContent: responseData[key].textContent,
            username: responseData[key].userName
          };
          this.comments.push(comment);
        }

      } catch (error) {
        this.error = error.message || 'Something went wrong!';
      }
      this.isLoading = false;
    },
    async addComment() {
      this.isLoading = true;

      try {
        const response = await fetch(
          `${process.env.VUE_APP_ROOT_API}/comiccomment`,
          {
            method: 'POST',
            headers: {
              Authorization: 'Bearer ' + localStorage.getItem('token'),
              "content-type": "application/json"
            },
            body: JSON.stringify({
              textContent: this.comment,
              comicId: this.$route.params.id2,
            })
          }
        );

        if (!response.ok) {
          const error = new Error(
            response.message || 'Failed to fetch comments!'
          );
          this.$toast.error('Comment was not added!');
          throw error;
        }

        this.$toast.success('Comment added successfully.');

      } catch (error) {
        this.error = error.message || 'Comment was not added!';
      }
      await this.loadComments();
      this.isLoading = false;
      this.comment = '';
    },
    getConvertedDate(sourceDate) {
      return new Date(sourceDate).toLocaleDateString() + " " + new Date(sourceDate).toLocaleTimeString();
    },
  },
};
</script>

<style scoped>
 .comments-container {
  max-width: 600px;
  margin: 2em auto 0 auto;
  padding: 0 1em;
}
.comment-form {
  margin: 4em auto 2em auto;
}
.add-comment-btn-wrapper {
  display: flex;
  justify-content: flex-end;
  margin-top: 0.5em;
}
</style>
