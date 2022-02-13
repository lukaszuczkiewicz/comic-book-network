<template>
  <div class="comic-card">
    <router-link :to="'/comics/1/' + comicId" class="link">
      <img
        class="comic-img"
        :src="`https://res.cloudinary.com/dwvenbraf/image/upload/v1644712521/${coverTitle}`"
        :alt="coverAlt"
      />
    </router-link>
    <div class="btns-container">
      <div class="buttons has-addons">
        <button
          class="button in-collection-btn"
          :class="isInCollectionData ? 'is-success' : ''"
          @click="addToList('collection')"
        >
          <collected-icon class="comic-icon"></collected-icon>
        </button>
        <button
          class="button in-read-btn"
          :class="isReadData ? 'is-info' : ''"
          @click="addToList('read')"
        >
          <read-icon class="comic-icon"></read-icon>
        </button>
        <button
          class="button in-wishlist-btn"
          :class="isInWishlistData ? 'is-warning' : ''"
          @click="addToList('wishlist')"
        >
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
      type: Number,
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
    isInCollection: {
      required: false,
      type: Boolean,
    },
    isRead: {
      required: false,
      type: Boolean,
    },
    isInWishlist: {
      required: false,
      type: Boolean,
    },
  },
  data() {
    return {
      isInCollectionData: this.isInCollection,
      isReadData: this.isRead,
      isInWishlistData: this.isInWishlist
    }
  },
  methods: {
    async addToList(listName) {
      try {
        const response = await fetch(
          `https://localhost:5001/api/comic/add-to-${listName}`,
          {
            method: 'POST',
            headers: {
              Authorization: 'Bearer ' + localStorage.getItem('token'),
              'content-type': 'application/json',
            },
            body: JSON.stringify({
              comicId: this.comicId,
            }),
          }
        );

        if (!response.ok) {
          const error = new Error(response.message || 'Failed to send!');
          this.$toast.error(`Comic was not added to ${listName}!`);
          throw error;
        }

        this.loadComicSocial();
      } catch (error) {
        this.error = error.message || 'Not rated!';
      }
    },
    async loadComicSocial() {
      try {
        const response = await fetch(
          `https://localhost:5001/api/comic/social/${this.comicId}`,
          {
            headers: {
              Authorization: 'Bearer ' + localStorage.getItem('token'),
            },
          }
        );
        const responseData = await response.json();

        if (!response.ok) {
          const error = new Error(responseData.message || 'Failed to fetch!');
          throw error;
        }

        this.isReadData = responseData.isRead;
        this.isInCollectionData = responseData.isInCollection;
        this.isInWishlistData = responseData.isInWishlist;

      } catch (error) {
        this.error = error.message || 'Something went wrong!';
      }
    },
  },
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
