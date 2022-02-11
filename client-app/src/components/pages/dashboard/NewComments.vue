<template>
  <section class="comment-container">
    <h3 class="title is-3">Latest comments</h3>

    <div class="comments" v-if="!isLoading">
      <comment
        v-for="c in comments"
        :key="c.Id"
        :comicId="c.comicId"
        :comicSeriesId="c.comicSeriesId"
        :coverTitle="c.photo"
        :date="this.getConvertedDate(c.date)"
        :comicTitle="c.seriesName"
        :description="c.textContent"
        :issueNumber="c.issueNumber"
        :username="c.username"
      >
      </comment>
    </div>
    <main-loading-spinner v-else></main-loading-spinner>
  </section>
</template>

<script>
import Comment from '../../ui/Comment.vue';

export default {
  components: {
    Comment,
  },
  data() {
    return {
      comments: [],
      isLoading: true,
    };
  },
  created() {
    this.loadLatestComments();
  },
  methods: {
    async loadLatestComments() {
      this.isLoading = true;
      try {
        const response = await fetch(
          'https://localhost:5001/api/comiccomment/latest',
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

        for (const key in responseData) {
          const comment = {
            id: responseData[key].id,
            textContent: responseData[key].textContent,
            date: responseData[key].date,
            appUserId: responseData[key].appUserId,
            comicId: responseData[key].comicId,
            username: responseData[key].userName,
            issueNumber: responseData[key].issueNumber,
            photo: responseData[key].photo,
            comicSeriesId: responseData[key].comicSeriesId,
            seriesName: responseData[key].seriesName,
          };
          this.comments.push(comment);
        }

      } catch (error) {
        this.error = error.message || 'Something went wrong!';
      }
      this.isLoading = false;
    },
    getConvertedDate(sourceDate) {
      return new Date(sourceDate).toLocaleDateString() + " " + new Date(sourceDate).toLocaleTimeString();
    },
  }
};
</script>

<style scoped>
.comment-container {
  display: flex;
  flex-direction: column;
  align-items: center;
  max-width: 600px;
  margin: 2em auto 0 auto;
}
.comments {
  width: 100%;
}
</style>
