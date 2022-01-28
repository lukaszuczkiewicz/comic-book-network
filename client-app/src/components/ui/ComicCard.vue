<template>
  <div class="comic-card">
    <router-link :to="'/comics/1/' + comicId" class="link">
    <img
      class="comic-img"
      :src="require(`../../assets/covers/${coverTitle}`)"
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
    <div class="text-container">
      <p class="publisher">{{ publisher }}</p>
      <h6 class="title is-6">{{ title + ' #' + issueNumber }}</h6>
    </div>
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
        await this.$store.dispatch('toggle-collected', actionPayload);
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
.comic-card {
  background: white;
  max-width: 170px;
  height: 400px;
  margin: 0 0.5em 1em 0.5em;
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
.text-container {
  padding: 0 0.5em;
  text-align: left;
}
.publisher {
  font-size: 0.8em;
}
</style>
