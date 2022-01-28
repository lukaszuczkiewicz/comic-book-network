<template>
    <section>
    <h3 class="title is-3">{{title}}</h3>
    <div class="comic-card-container">
      <slot></slot>
    </div>
  </section>
</template>

<script>
export default {
  props: ['title']
}
</script>

<style scoped>
.comic-card-container {
  display: flex;
  justify-content: center;
  flex-wrap: wrap;
}
</style>