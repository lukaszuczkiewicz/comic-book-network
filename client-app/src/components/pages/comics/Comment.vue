<template>
  <div>
    <div class="comment-header">
      <img :src="require('../../../assets/defaultAvatar.jpg')" class="avatar" />
      <div>
        <p>
          {{ username }} <span class="date">{{ date }}</span>
        </p>
        <h4 class="title is-4">
          {{ comicTitle }} #{{issueNumber}}
        </h4>
      </div>
    </div>
    <div class="main-content">
      <img
        :src="require(`../../../assets/${coverTitle}`)"
        alt="Comic Cover"
        class="comic-cover"
      />
      <p class="text-content">{{ description }}</p>
    </div>
  </div>
</template>

<script>
export default {
  props: {
    comicId: {
      required: true,
      type: Number
    },
    coverTitle: {
      required: true,
      type: String,
    },
    date: {
      required: true,
      type: Date,
    },
    comicTitle: {
      required: true,
      type: String,
    },
    issueNumber: {
      required: true,
      type: Number,
    },
    description: {
      required: true,
      type: String,
    },
    username: {
      required: true,
      type: String
    }
  },
}
</script>

<style scoped>
.comment {
  max-width: 900px;
  margin-bottom: 1em;
  padding: 1em;
  text-align: left;
}
.comment-header {
  display: flex;
  margin-bottom: 0.5em;
}
.main-content {
  display: flex;
}
.comic-cover {
  width: 120px;
  align-self: start;
}
.text-content {
  margin-left: 0.5em;
}
.avatar {
  border-radius: 100%;
  width: 50px;
  margin-right: 0.5em;
}
.date {
  color: #999999;
  font-size: 0.75em;
}
</style>