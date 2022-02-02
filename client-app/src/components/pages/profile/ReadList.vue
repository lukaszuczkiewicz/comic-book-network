<template>
<div>
  <list-counters></list-counters>
  <comic-grid title="Read Comics">
    <comic-card
      v-for="comic in comics"
      :key="comic.id"
      :comicId="comic.id"
      :coverTitle="comic.photo"
      :coverAlt="`Cover of '${comic.title} #${comic.issueNumber}`"
      :title="comic.title"
      :publisher="comic.publisher"
      :issueNumber="comic.issueNumber"
    ></comic-card>
  </comic-grid>
</div>
</template>

<script>
import ComicGrid from '../../ui/ComicGrid.vue';
import ComicCard from '../../ui/ComicCard.vue';
import ListCounters from '../dashboard/ListCounters.vue';

export default {
  components: {
    ComicGrid,
    ComicCard,
    ListCounters
  },
  data() {
    return {
      comics: []
    };
  },
  created() {
    this.loadLatestComics();
  },
  methods: {
    async loadLatestComics() {
      this.isLoading = true;
      try {
        const response = await fetch(
          'https://localhost:5001/api/comic/read',
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
.comic-card-container {
  display: flex;
  justify-content: center;
  flex-wrap: wrap;
}
</style>
