import { createRouter, createWebHistory } from 'vue-router';

import Auth from '../components/pages/auth/Auth.vue';
import Dashboard from '../components/pages/dashboard/Dashboard.vue';
import Profile from '../components/pages/profile/Profile.vue';
import Rated from '../components/pages/profile/Rated.vue';
import List from '../components/pages/profile/List.vue';
import Collection from '../components/pages/profile/Collection.vue';
import WishList from '../components/pages/profile/WishList.vue';
import ReadList from '../components/pages/profile/ReadList.vue';
import Comics from '../components/pages/comics/Comics.vue';
import SeriesDetail from '../components/pages/comics/SeriesDetail.vue';
import ComicDetail from '../components/pages/comics/ComicDetail.vue';
import NotFound from '../components/pages/NotFound.vue';
import store from '../store/index.js';

const routes = [
  {
    path: '/',
    redirect: '/dashboard',
  },
  {
    path: '/auth',
    component: Auth,
    meta: { requiresUnauth: true }
  },
  { path: '/dashboard',
    component: Dashboard,
    meta: { requiresAuth: true }
  },
  {
    path: '/profile',
    component: Profile,
    meta: { requiresAuth: true }
  },
  {
    path: '/comics',
    component: Comics,
    meta: { requiresAuth: true }
  },
  {
    path: '/comics/:id',
    component: SeriesDetail,
    meta: { requiresAuth: true }
  },
  {
    path: '/comics/:id/:id2',
    component: ComicDetail,
    meta: { requiresAuth: true }
  },
  {
    path: '/lists',
    component: List,
    meta: { requiresAuth: true },
    children: [
      { path: 'collection', component: Collection },
      { path: 'rated', component: Rated },
      { path: 'wishlist', component: WishList },
      { path: 'read', component: ReadList },
    ]
  },
  { path: '/:notFound(.*)', component: NotFound },
  // {
  //   path: '/about',
  //   name: 'About',
  //   // route level code-splitting
  //   // this generates a separate chunk (about.[hash].js) for this route
  //   // which is lazy-loaded when the route is visited.
  //   component: () => import(/* webpackChunkName: "about" */ '../views/About.vue')
  // }
];

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes,
});

router.beforeEach(function(to, _, next) {
  if (to.meta.requiresAuth && !localStorage.getItem('token')) {
    next('/auth');
  } else if (to.meta.requiresUnauth){
    store.dispatch('logout');
    next();
  }
  else {
    next();
  }
});

export default router;
