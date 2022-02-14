<template>
  <div v-if="!isLoading">

    <div class="series-header">
      <h2 class="title is-1">{{ series.seriesName }}</h2>
      <div class="header-box">

      <p>Publisher: <span class="bold">{{ series.publisher }}</span></p>
      <p>Published From: <span class="bold">{{ series.startYear }}</span></p>
      <p>Published To: <span class="bold">{{ series.endYear? series.endYear : "ongoing" }}</span></p>
      </div>
    </div>
    <comic-grid title="Comics" :listType="'from-series/' + this.$route.params.id"></comic-grid>
  </div>
  <main-loading-spinner v-else></main-loading-spinner>
</template>

<script>
import ComicGrid from '../../ui/ComicGrid.vue';

export default {
  components: {
    ComicGrid
  },
  data() {
    return {
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

      try {
        const response = await fetch(
          `${process.env.VUE_APP_ROOT_API}/comicseries/` + this.$route.params.id,
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

        this.series = {
          id: responseData.id,
          seriesName: responseData.seriesName,
          publisher: responseData.publisher,
          startYear: responseData.startYear,
          endYear: responseData.endYear,
        };
      } catch (error) {
        this.error = error.message || 'Something went wrong!';
      }
      this.isLoading = false;
    },
  },
};
</script>

<style scoped>
.header-box {
  background: white;
  color: black;
  padding: 1em;
  border-radius: 6px;
  margin-bottom: 2em;
}
.bold {
  font-weight: bold;
}
</style>