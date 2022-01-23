<template>
  <div class="container">
    <router-link :to="'/comic/' + comicId" class="link">
    <img
      class="comic-img"
      :src="require(`../../assets/${coverTitle}`)"
      :alt="coverAlt"
    />
    </router-link>
    <div class="btns-container">
      <div class="buttons has-addons">
        <button class="button in-collection-btn">
          <collected-icon class="comic-icon"></collected-icon>
        </button>
        <button class="button in-read-btn">
          <read-icon class="comic-icon"></read-icon>
        </button>
        <button class="button in-wishlist-btn">
          <wishlist-icon class="comic-icon"></wishlist-icon>
        </button>
      </div>
    </div>
    <h6 class="title is-6">{{ title + ' #' + issueNumber }}</h6>
    <p>{{ publisher }}</p>
  </div>
</template>

<script>
export default {
  props: {
    comicId: {
      required: true,
      type: Number
    },
    coverTitle: {
      required: true,
      type: String,
    },
    coverAlt: {
      required: true,
      type: String,
    },
    title: {
      required: true,
      type: String,
    },
    publisher: {
      required: true,
      type: String,
    },
    issueNumber: {
      required: true,
      type: Number,
    },
  },
  methods: {
    async toggleCollected() {
      const actionPayload = {
        comicId: this.comicId
      };

      try {
        await this.$store.dispatch('comic/id', actionPayload);
      } catch (err) {
        console.log(err);
      }
    },
    async toggleRead() {

    },
    async toggleWishlist() {
      
    },
  }
};
</script>

<style scoped>
.container {
  background: white;
  max-width: 170px;
  height: 400px;
}
.btns-container {
  display: flex;
  justify-content: center;
  margin-bottom: 0.4em;
}
.comic-img {
  width: 170px;
  height: 260px;
}
.comic-icon {
  width: 20px;
}
</style>
