<template>
  <comic-grid
    title="Comics from Wish List"
    listType="wishlist"
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