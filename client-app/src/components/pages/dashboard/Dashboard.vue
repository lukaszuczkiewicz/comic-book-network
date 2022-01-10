<template>
  <main class="main">
  <section>
    <n-space justify="center">
      <router-link to="/profile/myid/collection" class="link">
        <n-card :title="collected" size="small" class="card collected">Collected<collected-icon></collected-icon></n-card>
      </router-link>
      <router-link to="/profile/myid/read" class="link">
        <n-card :title="read" size="small" class="card read">Read<read-icon></read-icon></n-card>
      </router-link>
      <router-link to="/profile/myid/rated" class="link">
        <n-card :title="rated" size="small" class="card rated">Rated<rated-icon></rated-icon></n-card>
      </router-link>
      <router-link to="/profile/myid/wishlist" class="link">
       <n-card :title="wishlist" size="small" class="card wishlist">WishList<wishlist-icon></wishlist-icon></n-card>
      </router-link>
    </n-space>
  </section>
  <new-comics></new-comics>
  <new-comments></new-comments>
  </main>
</template>

<script>
import { NCard, NSpace } from 'naive-ui';
import NewComics from './NewComics.vue';
import NewComments from './NewComments.vue';

export default {
  components: {
    NCard, NSpace, NewComics, NewComments
  },
  data() {
    return {
      collected: "0",
      read: "0",
      rated: "0",
      wishlist: "0"
    }
  }
}
</script>

<style scoped>
.main {
  padding: 1rem;
}
.card {
  width: 100px;
  cursor: pointer;
  transition: all 0.5s ease-in;
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
</style>