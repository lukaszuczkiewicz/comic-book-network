<template>
  <div v-if="!isLoading">
    <div>
      <h2 class="title">{{ series.seriesName }}</h2>
      <p>Publisher: {{ series.publisher }}</p>
      <p>Published From: {{ series.startYear }}</p>
      <p>Published To: {{ series.endYear }}</p>
      <p>{{ series.id }}</p>
    </div>

    <comic-grid title="All issues:">
      <comic-card
        v-for="comic in comics"
        :key="comic.id"
        :title="series.seriesName"
        :publisher="series.publisher"
        :comicId="comic.id"
        :issueNumber="comic.issueNumber"
        :coverTitle="comic.photo"
        :coverAlt="'Comic Cover'"
      ></comic-card>
    </comic-grid>
  </div>
</template>

<script>
import ComicGrid from '../../ui/ComicGrid.vue';
import ComicCard from '../../ui/ComicCard.vue';

export default {
  components: {
    ComicGrid,
    ComicCard,
  },
  data() {
    return {
      comics: [],
      series: null,
      isLoading: true,
    };
  },
  created() {
    this.loadSeries();
  },
  methods: {
    async loadSeries() {
      this.isLoading = true;

      console.log('id from route: ' + this.$route.params.id);

      try {
        const response = await fetch(
          'https://localhost:5001/api/comicseries/' + this.$route.params.id,
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

        this.series = {
          id: responseData.id,
          seriesName: responseData.seriesName,
          publisher: responseData.publisher,
          startYear: responseData.startYear,
          endYear: responseData.endYear,
        };

        this.comics = responseData.comics;
      } catch (error) {
        this.error = error.message || 'Something went wrong!';
      }
      this.isLoading = false;
    },
  },
};
</script>
