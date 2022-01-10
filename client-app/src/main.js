import { createApp } from 'vue';
import App from './App.vue';
import router from './router';
import store from './store';

// icons:
import IosStar from './assets/icons/IosStar.vue';
import BookReader from './assets/icons/BookReader.vue';
import AlbumsOutline from './assets/icons/AlbumsOutline.vue';
import PlusSquareTwotone from './assets/icons/PlusSquareTwotone.vue';

const app = createApp(App);
app.use(store);
app.use(router);

app.component('rated-icon', IosStar);
app.component('read-icon', BookReader);
app.component('collected-icon', AlbumsOutline);
app.component('wishlist-icon', PlusSquareTwotone);

app.mount('#app');
