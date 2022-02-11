<template>
  <main>
    <list-counters></list-counters>
    <new-comics></new-comics>
    <new-comments></new-comments>
  </main>
</template>

<script>
import NewComics from './NewComics.vue';
import NewComments from './NewComments.vue';
import ListCounters from './ListCounters.vue';

export default {
  components: {
    NewComics,
    NewComments,
    ListCounters
  }
};
</script>
