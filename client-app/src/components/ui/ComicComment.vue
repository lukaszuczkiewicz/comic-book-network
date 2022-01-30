<template>
  <div class="card comment">
    <img :src="require('../../assets/defaultAvatar.jpg')" class="avatar" />
    <div>
      <p>
        <span class="username">{{ username }}</span>
        <span class="date">{{ date }}</span>
      </p>
      <p class="text-content">{{ description }}</p>
    </div>
  </div>
</template>

<script>
export default {
  props: {
    date: {
      required: true,
      type: String,
    },
    description: {
      required: true,
      type: String,
    },
    username: {
      required: true,
      type: String,
    },
  },
};
</script>

<style scoped>
.comment {
  display: flex;
  margin-bottom: 1em;
  padding: 1em;
  text-align: left;
}
.avatar {
  border-radius: 100%;
  width: 50px;
  margin-right: 0.5em;
}
.username {
  font-weight: bold;
  margin-right: 0.4em;
}
.date {
  color: #999999;
  font-size: 0.75em;
}
</style>
