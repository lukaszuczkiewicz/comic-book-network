<template>
  <comic-grid
    title="New Comics"
    listType="latest"
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