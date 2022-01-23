<template>
  <section class="comment-container">
    <h3 class="title is-3">Latest comments</h3>

    <div>

    <div v-for="comment in comments" :key="comment" class="card comment">
      <div class="comment-header">
        <img
          :src="require('../../../assets/defaultAvatar.jpg')"
          class="avatar"
        />
        <div>
          <p>
            {{comment.username}} <span class="date">{{comment.date}}</span>
          </p>
          <h4 class="title is-4">
            {{comment.comicTitle}}
          </h4>
        </div>
      </div>
      <div class="main-content">
        <img
          :src="require(`../../../assets/${comment.cover}`)"
          alt="Comic Cover"
          class="comic-cover"
        />
        <p class="text-content">{{comment.text}}</p>
      </div>
    </div>
    </div>
  </section>
</template>

<script>
export default {
  data() {
    return {
      comments: [
        {
          avatar: 'deffaultAvatar',
          username: 'Alan',
          date: this.getConvertedDate(),
          text: "This is what I want from this title. This issue is amazing. This issue revolves around an interaction between Leia and Qi'ra of Crimson Dawn as they discuss the alleged dead Han Solo. While this issue has little to no action, the emotional dialogue and interactions between characters carries the story. The emotional moments grab at every Star Wars  fans' hearts and the characters are written spectacularly similar to their characters in the films. This issue is one of the best I have read from this series and I have really high expectations for where this series is to go next. ",
          cover: 'cover1.jpg',
          comicTitle: 'Star Wars #18',
          stars: 5,
        },
        {
          avatar: 'deffaultAvatar',
          username: 'GWComic',
          date: this.getConvertedDate(),
          text: "While I do enjoy Erik Larsen's artwork, stories, and style. This issue felt extremely rushed. The plot was predictable and the story was nothing new. The characters were interesting, but there are too many questions left unanswered that I just do not have an interest in. This issue was much more disappointing than I was expecting. The artwork was one of the biggest let downs. Erik Larsen was one of my favorite comic book writers because of his run with Amazing Spider-Man in the 1990s, but this artwork was boring and dislikable. For a premiere issue, this does little to show anything of importance for the Ant. I probably will not read this series any more, but I may check out a trade paperback if one is released.",
          cover: 'cover2.jpg',
          comicTitle: 'Ant #1',
          stars: 2,
        },
        {
          avatar: 'deffaultAvatar',
          username: 'EJackson',
          date: this.getConvertedDate(),
          text: 'Looks like I wasn’t off the mark in my review of issue #1 when I said that Superior Spidey reminds me of Batman. The start of this issue even jokes about it with the Spider-signal and JJJ playing the part of a more arrogant Jim Gordon.As usual, Otto is a much more efficient and cynical version of Spidey and his showdown with the Vulture is a truly memorable one. The flashback scene hits pretty hard and informs Otto’s actions in a very sympathetic way. Charlie’s subplot continues as her suspicions turn out well-founded and Peter starts worrying for her safety.',
          cover: 'cover3.jpg',
          comicTitle: 'The Superior Spider-Man #3',
          stars: 0,
        },
      ],
    };
  },
  methods: {
    getConvertedDate() {
      const timeElapsed = Date.now();
      return new Date(timeElapsed).toDateString();
    }
  }
};
</script>

<style scoped>
.comment-container {
  display: flex;
  flex-direction: column;
  align-items: center;
}
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
