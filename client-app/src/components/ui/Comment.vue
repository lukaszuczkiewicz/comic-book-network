<template>
  <router-link :to="`/comics/${comicSeriesId}/${comicId}`">
    <div class="card comment">
      <div>
        <div class="comment-header">
          <img
            :src="require('../../assets/defaultAvatar.jpg')"
            class="avatar"
          />
          <div>
            <p>
              {{ username }} <span class="date">{{ date }}</span>
            </p>
            <h4 class="title is-4">{{ comicTitle }} #{{ issueNumber }}</h4>
          </div>
        </div>
        <p class="text-content" data-test="comment-description">{{ description }}</p>
      </div>
      <img
        v-if="coverTitle"
        :src="`https://res.cloudinary.com/dwvenbraf/image/upload/v1644712521/${coverTitle}`"
        alt="Comic Cover"
        class="comic-cover"
      />
    </div>
  </router-link>
</template>

<script>
export default {
  props: {
    comicId: {
      required: true,
      type: Number,
    },
    comicSeriesId: {
      required: true,
      type: Number,
    },
    coverTitle: {
      required: true,
      type: String,
    },
    date: {
      required: true,
      type: String,
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
      type: String,
    },
  },
};
</script>

<style scoped>
.comment {
  margin-bottom: 1em;
  padding: 1em;
  text-align: left;
  display: flex;
  align-items: flex-start;
  justify-content: space-between;
}
.comment-header {
  display: flex;
  margin-bottom: 0.5em;
}
.comic-cover {
  width: 100px;
}
.avatar {
  border-radius: 100%;
  width: 50px;
  margin-right: 0.5em;
  align-self: flex-start;
}
.date {
  color: #999999;
  font-size: 0.75em;
}
</style>