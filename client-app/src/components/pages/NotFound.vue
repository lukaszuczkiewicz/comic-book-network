<template>
  <div>
    <img :src="require('../../assets/notfound.png')" alt="404 not found">
    <div class="title">Hmmm... There is nothing here.</div>
    <router-link to="/">Go to homepage</router-link>
  </div>
</template>
