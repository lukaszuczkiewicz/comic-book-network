import { createApp } from 'vue';
import App from './App.vue';
import router from './router';
import store from './store';
import VueToast from 'vue-toast-notification';
import 'vue-toast-notification/dist/theme-default.css';

require('@/assets/main.scss');

// icons:
import BookReader from './assets/icons/BookReader.vue';
import AlbumsOutline from './assets/icons/AlbumsOutline.vue';
import PlusSquareTwotone from './assets/icons/PlusSquareTwotone.vue';
import MainLoadingSpinner from './components/ui/MainLoadingSpinner.vue';

const app = createApp(App);
app.use(store);
app.use(router);
app.use(VueToast);

app.component('read-icon', BookReader);
app.component('collected-icon', AlbumsOutline);
app.component('wishlist-icon', PlusSquareTwotone);
app.component('main-loading-spinner', MainLoadingSpinner);

app.mount('#app');
