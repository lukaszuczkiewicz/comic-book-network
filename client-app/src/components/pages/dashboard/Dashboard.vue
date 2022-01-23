<template>
  <main class="main">
    <section class="block list-section">
      <router-link to="/profile/myid/collection" class="link">
        <div :title="collected" size="small" class="card collected">
          <collected-icon class="comic-icon"></collected-icon>
          <div class="counter">{{ collected }}</div>Collected
        </div>
      </router-link>
      <router-link to="/profile/myid/read" class="link">
        <div :title="read" size="small" class="card read">
          <read-icon class="comic-icon"></read-icon>
          <div class="counter">{{ read }}</div>Read
        </div>
      </router-link>
      <router-link to="/profile/myid/rated" class="link">
        <div :title="rated" size="small" class="card rated">
          <rated-icon class="comic-icon"></rated-icon>
          <div class="counter">{{ rated }}</div>Rated
        </div>
      </router-link>
      <router-link to="/profile/myid/wishlist" class="link">
        <div :title="wishlist" size="small" class="card wishlist">
          <wishlist-icon class="comic-icon"></wishlist-icon>
          <div class="counter">{{ wishlist }}</div>Wishlist
        </div>
      </router-link>
    </section>
    <new-comics></new-comics>
    <new-comments></new-comments>
  </main>
</template>

<script>
import NewComics from './NewComics.vue';
import NewComments from './NewComments.vue';

export default {
  components: {
    NewComics,
    NewComments,
  },
  data() {
    return {
      collected: '0',
      read: '0',
      rated: '0',
      wishlist: '0',
    };
  },
};
</script>

<style scoped>
.main {
  padding: 1rem;
}
.list-section {
  display: flex;
  justify-content: center;
}
.card {
  width: 100px;
  cursor: pointer;
  transition: all 0.5s ease-in;
  padding: 1em;
  margin: 0 0.5em
}
.collected {
  background-color: rgb(129, 210, 212);
}
.read {
  background-color: rgb(154, 214, 119);
}
.rated {
  background-color: rgb(237, 255, 72);
}
.wishlist {
  background-color: #cccccc;
}
.card:hover {
  transform: scale(1.02);
}
.counter {
  font-weight: 900;
  font-size: 2em;
}
</style>
