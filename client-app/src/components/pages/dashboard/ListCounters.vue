<template>
  <section class="block list-section">
      <router-link to="/lists/rated" class="link">
        <div title="rated" size="small" class="card rated">
          <rated-icon class="comic-icon"></rated-icon>
          <!-- <div class="counter">{{ rated }}</div> -->
          Rated
        </div>
      </router-link>
      <router-link to="/lists/collection" class="link">
        <div title="collected" size="small" class="card collected">
          <collected-icon class="comic-icon"></collected-icon>
          <!-- <div class="counter">{{ collected }}</div> -->
          Collected
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
          Wishlist
        </div>
      </router-link>
    </section>
</template>

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
}
.collected {
  background-color: hsl(171, 100%, 41%);
}
.read {
  background-color: hsl(204, 86%, 53%);
}
.rated {
  background-color: hsl(355, 71%, 53%);
}
.wishlist {
  background-color: hsl(48, 100%, 67%);
}
.card:hover {
  transform: scale(1.02);
}
.counter {
  font-weight: 900;
  font-size: 2em;
}
</style>