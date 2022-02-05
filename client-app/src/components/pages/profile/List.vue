<template>
  <div>
    <list-counters></list-counters>
    <router-view></router-view>
  </div>
</template>

<script>
import ListCounters from '../dashboard/ListCounters.vue';

export default {
  components: {
    ListCounters,
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
