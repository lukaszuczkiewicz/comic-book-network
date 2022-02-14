<template>
  <div class="main-container" v-if="!isLoading">
    <div class="info-header">
      <router-link :to="'/comics/' + comic.comicSeriesId">{{
        comic.seriesName
      }}</router-link>
      <p>
        <span class="publisher">{{ comic.publisher }}</span>
        <span> - RELEASED {{ comic.publishDate }}</span>
      </p>
      <h2 class="title is-2">
        {{ comic.seriesName }} #{{ comic.issueNumber }}
      </h2>
    </div>

    <div class="action-container">
      <div class="rating">
        <div class="flex">
            <star-filled
              v-if="rating >= 1"
              class="star"
              @click="rate(1)"
            ></star-filled>
            <star-outlined v-else class="star" @click="rate(1)"></star-outlined>

            <star-filled
              v-if="rating >= 2"
              class="star"
              @click="rate(2)"
            ></star-filled>
            <star-outlined v-else class="star" @click="rate(2)"></star-outlined>

            <star-filled
              v-if="rating >= 3"
              class="star"
              @click="rate(3)"
            ></star-filled>
            <star-outlined v-else class="star" @click="rate(3)"></star-outlined>

            <star-filled
              v-if="rating >= 4"
              class="star"
              @click="rate(4)"
            ></star-filled>
            <star-outlined v-else class="star" @click="rate(4)"></star-outlined>

            <star-filled
              v-if="rating == 5"
              class="star"
              @click="rate(5)"
            ></star-filled>
            <star-outlined v-else class="star" @click="rate(5)"></star-outlined>

            <remove-icon @click="rate(0)" class="remove"></remove-icon>
        </div>
        <div>Average User Score: <span>{{ averageRating? averageRating : "N/A" }}</span></div>
      </div>
      <div class="btns-container">
        <div class="buttons">
          <button
            class="button in-collection-btn"
            :class="isInCollection ? 'is-success' : ''"
            @click="addToList('collection')"
          >
            <collected-icon class="comic-icon"></collected-icon>
          </button>
          <button
            class="button in-read-btn"
            :class="isRead ? 'is-info' : ''"
            @click="addToList('read')"
          >
            <read-icon class="comic-icon"></read-icon>
          </button>
          <button
            class="button in-wishlist-btn"
            :class="isInWishlist ? 'is-warning' : ''"
            @click="addToList('wishlist')"
          >
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
        <p><span class="bold">Writer: </span>{{ comic.writer }}</p>
        <p><span class="bold">Artist: </span>{{ comic.artist }}</p>
      </div>
      <img
        class="comic-img"
        :src="`https://res.cloudinary.com/dwvenbraf/image/upload/v1644712521/` + comic.photo"
        alt="comic cover"
      />
    </div>

    <comic-comments></comic-comments>
  </div>
  <main-loading-spinner v-else></main-loading-spinner>
</template>

<script>
import StarOutlined from '../../../assets/icons/StarOutlined.vue';
import StarFilled from '../../../assets/icons/StarFilled.vue';
import RemoveIcon from '../../../assets/icons/RemoveIcon.vue';
import ComicComments from '../comics/ComicComments.vue';

export default {
  components: {
    StarOutlined,
    StarFilled,
    ComicComments,
    RemoveIcon
  },
  data() {
    return {
      comic: null,
      isLoading: true,
      rating: 0,
      averageRating: null,
      isInCollection: false,
      isRead: false,
      isInWishlist: false,
    };
  },
  created() {
    this.loadComicDetail();
    this.loadComicSocial();
  },
  methods: {
    async loadComicDetail() {
      this.isLoading = true;

      try {
        const response = await fetch(
          `${process.env.VUE_APP_ROOT_API}/comic/${this.$route.params.id2}`,
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

        this.comic = {
          id: responseData.id,
          publishDate: responseData.publishDate,
          issueNumber: responseData.issueNumber,
          price: responseData.price,
          pageCount: responseData.pageCount,
          photo: responseData.photo,
          description: responseData.description,
          comicSeriesId: responseData.comicSeriesId,
          seriesName: responseData.seriesName,
          publisher: responseData.publisher,
          writer: responseData.writer,
          artist: responseData.artist,
        };
      } catch (error) {
        this.error = error.message || 'Something went wrong!';
      }
      this.isLoading = false;
    },
    async loadComicSocial() {
      try {
        const response = await fetch(
          `${process.env.VUE_APP_ROOT_API}/comic/social/${this.$route.params.id2}`,
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

        this.rating = responseData.rate;
        this.isRead = responseData.isRead;
        this.isInCollection = responseData.isInCollection;
        this.isInWishlist = responseData.isInWishlist;
        this.averageRating = responseData.averageRating;

      } catch (error) {
        this.error = error.message || 'Something went wrong!';
      }
    },
    async rate(rateNumber) {
      if (rateNumber < 0 || rateNumber > 5) return;

      try {
        const response = await fetch(`${process.env.VUE_APP_ROOT_API}/comic/rate`, {
          method: 'POST',
          headers: {
            Authorization: 'Bearer ' + localStorage.getItem('token'),
            'content-type': 'application/json',
          },
          body: JSON.stringify({
            rate: rateNumber,
            comicId: this.comic.id,
          }),
        });

        if (!response.ok) {
          const error = new Error(response.message || 'Failed to rate comic!');
          this.$toast.error('Comic was not rated!');
          throw error;
        }

        this.rating = rateNumber;
        if (rateNumber >= 1) this.isRead = true;
        this.loadComicSocial();

      } catch (error) {
        this.error = error.message || 'Not rated!';
      }
    },
    async addToList(listName) {
      try {
        const response = await fetch(
          `${process.env.VUE_APP_ROOT_API}/comic/add-to-${listName}`,
          {
            method: 'POST',
            headers: {
              Authorization: 'Bearer ' + localStorage.getItem('token'),
              'content-type': 'application/json',
            },
            body: JSON.stringify({
              comicId: this.comic.id,
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
  },
};
</script>

<style scoped>
.main-container {
  max-width: 1000px;
  margin: 0 auto;
  padding: 0 1em 1em;
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
  margin-top: 0.75em;
  text-align: left;
}

.rating {
  display: flex;
  flex-direction: column;
  justify-content: space-between;
}

.button {
  color: black;
  width: 4em;
  height: 4em;
  padding: 1em;
}
.comic-img {
  width: 400px;
  align-self: flex-start;
}
.star {
  width: 2em;
  height: 2em;
  cursor: pointer;
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

.comment-form {
  margin: 4em auto 0 auto;
  max-width: 500px;
}

.add-comment-btn-wrapper {
  display: flex;
  justify-content: flex-end;
  margin-top: 0.5em;
}
.add-comment-btn {
  width: 150px;
}
.flex {
  display: flex;
  align-items: center;
}
.remove {
  cursor: pointer;
  margin-left: 0.6em;
}

@media (max-width: 700px) {
  .comic-img {
    margin: 0 auto 1em auto;
  }
  .main-content {
    flex-direction: column-reverse;
  }
}

@media (max-width: 480px) {
  .action-container {
    flex-direction: column-reverse;
    align-items: center;
  }
  .rating {
    margin-top : 1em;
  }
}

</style>
