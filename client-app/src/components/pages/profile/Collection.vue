<template>
  <comic-grid
    title="Comics from Collection"
    listType="collection"
  ></comic-grid>
</template>

<script>
import ComicGrid from '../../ui/ComicGrid.vue';

export default {
  components: {
    ComicGrid
  }
}
</script>