<template>
  <comic-grid title="New Comics">
    <comic-card
      v-for="comic in comics"
      :key="comic.id"
      :comicId="comic.id"
      :coverTitle="comic.cover"
      :coverAlt="'Comic Cover'"
      :title="comic.title"
      :publisher="comic.publisher"
      :issueNumber="comic.issueNumber"
    ></comic-card>
  </comic-grid>
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
      comics: [
        {
          id: 4,
          title: 'Department Of Truth',
          cover: 'dot15.jpg',
          issueNumber: 15,
          publisher: 'Image Comics',
        },
        {
          id: 2,
          title: 'We Live',
          cover: 'welive1.jpg',
          issueNumber: 1,
          publisher: 'Aftershock',
        },
        {
          id: 3,
          title: 'Basilisk',
          cover: 'welive1.jpg',
          issueNumber: 1,
          publisher: 'BOOM! Studios',
        },
        {
          id: 1,
          title: 'Something is Killing the Children',
          cover: 'welive1.jpg',
          issueNumber: 15,
          publisher: 'BOOM! Studios',
        },
      ],
    };
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
