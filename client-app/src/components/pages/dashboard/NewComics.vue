<template>
  <section class="block">
    <h3 class="title is-3">New Comics</h3>
    
    <div class="card-container">
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
    </div>
  </section>
</template>

<script>
import ComicCard from '../../ui/ComicCard.vue';

export default {
  components: {
    ComicCard
  },
  data() {
    return {
      comics: [
        {
          id: 34561,
          title: 'Department Of Truth',
          cover: 'cover1.jpg',
          issueNumber: 15,
          publisher: 'Image Comics',
        },
        {
          id: 2456,
          title: 'We Live',
          cover: 'cover2.jpg',
          issueNumber: 1,
          publisher: 'Aftershock',
        },
        {
          id: 33456,
          title: 'Basilisk',
          cover: 'cover3.jpg',
          issueNumber: 1,
          publisher: 'BOOM! Studios',
        },
        {
          id: 46434,
          title: 'Something is Killing the Children #1',
          cover: 'cover4.jpg',
          issueNumber: 15,
          publisher: 'BOOM! Studios',
        },
      ],
    };
  },
};
</script>

<style scoped>
.card-container {
  display: flex;

}
.comic {
  width: 190px;
}
comic-card {
  flex: 1;
}
</style>
