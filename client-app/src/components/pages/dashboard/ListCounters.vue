<template>
  <section class="block list-section">
      <router-link to="/lists/collection" class="link">
        <div title="collected" size="small" class="card collected">
          <collected-icon class="comic-icon"></collected-icon>
          <!-- <div class="counter">{{ collected }}</div> -->
          Collected
        </div>
      </router-link>
      <router-link to="/lists/rated" class="link">
        <div title="rated" size="small" class="card rated">
          <star-outlined class="comic-icon"></star-outlined>
          <!-- <div class="counter">{{ rated }}</div> -->
          Rated
        </div>
      </router-link>
      <router-link to="/lists/read" class="link">
        <div title="read" size="small" class="card read">
          <read-icon class="comic-icon"></read-icon>
          <!-- <div class="counter">{{ read }}</div> -->
          Read
        </div>
      </router-link>
      <router-link to="/lists/wishlist" class="link">
        <div title="wishlist" size="small" class="card wishlist">
          <wishlist-icon class="comic-icon"></wishlist-icon>
          <!-- <div class="counter">{{ wishlist }}</div> -->
          Wish List
        </div>
      </router-link>
    </section>
</template>

<script>
import StarOutlined from '../../../assets/icons/StarOutlined.vue';
export default {
  components: {
    StarOutlined
  }
}
</script>

<style scoped>
.list-section {
  display: flex;
  justify-content: center;
}
.card {
  width: 100px;
  cursor: pointer;
  transition: all 0.5s ease-in;
  padding: 1em;
  margin: 0 0.5em;
  color: white;
  background: #7c7c7c;
}
.comic-icon {
  width: 100%;
  height: 100%;
}
.router-link-active .collected {
  background-color: #48c78e;
}
.router-link-active .read {
  background-color: #3e8ed0;
}
.router-link-active .rated {
  background-color: hsl(355, 71%, 53%);
}
.router-link-active .wishlist {
  background-color: #ffe08a;
}
.card:hover {
  transform: scale(1.02);
}
.counter {
  font-weight: 900;
  font-size: 2em;
}
</style>