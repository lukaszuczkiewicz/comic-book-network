<template>
  <section>
    <h3>New Comics</h3>
    <n-space justify="center">
      <n-card
        v-for="comic in comics"
        :key="comic"
        class="comic"
        :title="comic.title"
        embedded
      >
        <template #cover>
          <img :src="require(`../../../assets/${comic.cover}`)" alt="Comic Cover" />
        </template>
        {{ comic.publisher }}
      </n-card>
    </n-space>
  </section>
</template>

<script>

export default {
  data() {
    return {
      comics: [
        {
          title: 'Department Of Truth #15',
          cover: 'cover1.jpg',
          publisher: 'Image Comics',
        },
        {
          title: 'We Live #1',
          cover: 'cover2.jpg',
          publisher: 'Aftershock',
        },
        {
          title: 'Basilisk #1',
          cover: 'cover3.jpg',
          publisher: 'BOOM! Studios',
        },
        {
          title: 'Something is Killing the Children #1',
          cover: 'cover4.jpg',
          publisher: 'BOOM! Studios',
        },
      ],
    };
  },
};
</script>

<style scoped>
.comic {
  width: 190px;
}
</style>
