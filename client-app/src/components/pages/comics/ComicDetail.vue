<template>
  <div class="main-container" v-if="!isLoading">
    <div class="info-header">
      <p>
        <span class="publisher">Publisher</span>
        <span> - RELEASED {{ comic.publishDate }}</span>
      </p>
      <h2 class="title is-2">Comic Book Title #{{ comic.issueNumber }}</h2>
    </div>

    <div class="action-container">
      <div class="rating">
        <div>
          <star-outlined class="star"></star-outlined>
          <star-outlined class="star"></star-outlined>
          <star-outlined class="star"></star-outlined>
          <star-outlined class="star"></star-outlined>
          <star-outlined class="star"></star-outlined>
        </div>
        <div>Average User Score: <span>5.0</span></div>
      </div>
      <div class="btns-container">
        <div class="buttons">
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
    </div>

    <div class="main-content">
      <div>
        <p class="description">{{ comic.description }}</p>
        <p><span class="bold">Cover Price: </span>${{ comic.price }}</p>
        <p><span class="bold">Page Count: </span>32</p>
        <p><span class="bold">Writer: </span>Writer Name</p>
        <p><span class="bold">Artist: </span>Artist Name</p>
      </div>
      <img
        class="comic-img"
        :src="require(`../../../assets/covers/`+ comic.photo)"
        alt="comic cover"
      />
    </div>
  </div>
</template>

<script>
import StarOutlined from '../../../assets/icons/StarOutlined.vue';

export default {
  components: {
    StarOutlined,
  },
  data() {
    return {
      comic: null,
      isLoading: true,
    };
  },
  created() {
    this.loadComicDetail();
  },
  methods: {
    async loadComicDetail() {
      this.isLoading = true;

      console.log('id from route: ' + this.$route.params.id);

      try {
        const response = await fetch(
          `https://localhost:5001/api/comic/${this.$route.params.id2}`,
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

        console.log(responseData);

        this.comic = {
          id: responseData.id,
          issueNumber: responseData.issueNumber,
          description: responseData.description,
          price: responseData.price,
          publishDate: responseData.publishDate,
          photo: responseData.photo
        };
      } catch (error) {
        this.error = error.message || 'Something went wrong!';
      }
      this.isLoading = false;
    },
  },
};
</script>

<style scoped>
.main-container {
  max-width: 1000px;
  margin: 2em auto 0 auto;
  padding: 0 1em;
}
.info-header {
  text-align: left;
}
.publisher {
  text-transform: uppercase;
}
.action-container {
  background: black;
  color: white;
  padding: 1em;
  display: flex;
  justify-content: space-between;
  border-radius: 6px;
}
.button {
  color: black;
  width: 4em;
  height: 4em;
  padding: 1em;
}
.comic-img {
  width: 400px;
}
.star {
  width: 2em;
  height: 2em;
}
.main-content {
  display: flex;
  justify-content: space-between;
  margin-top: 1em;
  text-align: left;
}
.description {
  margin-right: 1em;
  margin-bottom: 1em;
}
.bold {
  font-weight: 700;
}
</style>
