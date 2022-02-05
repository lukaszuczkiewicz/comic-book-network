<template>
  <section class="outer-container">
    <h3 class="title is-3">{{ title }}</h3>
    <div class="comic-card-container" v-if="!isLoading">
      <p v-if="comics.length === 0">There are no comics.</p>
      <comic-card
        v-else
        v-for="comic in comics"
        :key="comic.id"
        :comicId="comic.id"
        :coverTitle="comic.photo"
        :coverAlt="`Cover of '${comic.title} #${comic.issueNumber}`"
        :title="comic.title"
        :publisher="comic.publisher"
        :issueNumber="comic.issueNumber"
        :isRead="comic.isRead"
        :isInCollection="comic.isInCollection"
        :isInWishlist="comic.isInWishlist"
      ></comic-card>
    </div>
  </section>
</template>

<script>
import ComicCard from './ComicCard.vue';

export default {
  components: {
    ComicCard,
  },
  props: {
    title: {
      required: true,
      type: String,
    },
    listType: {
      required: true,
      type: String,
    },
  },
  data() {
    return {
      isLoading: true,
      comics: [],
    };
  },
  created() {
    this.loadComics();
  },
  methods: {
    async loadComics() {
      this.isLoading = true;
      try {
        const response = await fetch(
          `https://localhost:5001/api/comic/${this.listType}`,
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
          const comic = {
            id: responseData[key].id,
            title: responseData[key].seriesName,
            publisher: responseData[key].publisher,
            issueNumber: responseData[key].issueNumber,
            photo: responseData[key].photo,
            isInCollection: responseData[key].isInCollection,
            isRead: responseData[key].isRead,
            isInWishlist: responseData[key].isInWishlist,
          };
          this.comics.push(comic);
        }
      } catch (error) {
        this.error = error.message || 'Something went wrong!';
      }
      this.isLoading = false;
    },
  },
};
</script>

<style scoped>
.outer-container {
  margin: 0 auto;
  max-width: 1000px;
}
.comic-card-container {
  display: flex;
  justify-content: center;
  flex-wrap: wrap;
}
</style>
