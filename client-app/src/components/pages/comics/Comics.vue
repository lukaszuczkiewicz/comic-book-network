<template>
  <div class="comic-series-container">
    <h2 class="title is-3">Comic Series:</h2>
    <ul class="series-list">
      <li v-for="series of comicSeries" :key="series.id">
        <p class="subtitle is-5">
          <router-link :to="'/comics/'+series.id">
            <span>{{ series.seriesName }}</span>
          </router-link>
          <span>{{ series.publisher }}</span> -<span>{{
            series.startYear == 0 ? 'N/A' : series.startYear
          }}</span>
          -<span>{{ series.endYear == 0 ? 'ongoing' : series.startYear }}</span>
        </p>
      </li>
    </ul>
  </div>
</template>

<script>
export default {
  data() {
    return {
      comicSeries: [],
    };
  },
  created() {
    this.loadSeries();
  },
  methods: {
    async loadSeries() {
      this.isLoading = true;

      try {
        const response = await fetch('https://localhost:5001/api/comicseries', {
          headers: {
            Authorization: 'Bearer ' + localStorage.getItem('token'),
          },
        });
        const responseData = await response.json();

        if (!response.ok) {
          const error = new Error(responseData.message || 'Failed to fetch!');
          throw error;
        }

        this.comicSeries = [];
        for (const key in responseData) {
          const series = {
            id: responseData[key].id,
            seriesName: responseData[key].seriesName,
            publisher: responseData[key].publisher,
            startYear: responseData[key].startYear,
            endYear: responseData[key].endYear,
          };
          this.comicSeries.push(series);
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
.comic-series-container {
  max-width: 900px;
  margin: 2em auto 0 auto;
}
.series-list {
  text-align: left;
}
</style>