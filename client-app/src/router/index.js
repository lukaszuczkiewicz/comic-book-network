import { createRouter, createWebHistory } from 'vue-router';

import Auth from '../components/pages/auth/Auth.vue';
import Dashboard from '../components/pages/dashboard/Dashboard.vue';
import Profile from '../components/pages/profile/Profile.vue';
import Rated from '../components/pages/profile/Rated.vue';
import Collection from '../components/pages/profile/Collection.vue';
import WishList from '../components/pages/profile/WishList.vue';
import ReadList from '../components/pages/profile/ReadList.vue';
import Comics from '../components/pages/comics/Comics.vue';
import Search from '../components/pages/search/Search.vue';
import NotFound from '../components/pages/NotFound.vue';
// import store from '../store/index.js';

const routes = [
  {
    path: '/auth',
    component: Auth,
    meta: { requiresUnauth: true }
  },
  {
    path: '/',
    redirect: '/dashboard',
  },
  { path: '/dashboard', component: Dashboard },
  { path: '/search', component: Search },
  {
    path: '/profile/:id',
    component: Profile,
    children: [
      { path: 'collection', component: Collection },
      { path: 'rated', component: Rated },
      { path: 'wishlist', component: WishList },
      { path: 'readlist', component: ReadList },
    ],
  },
  {
    path: '/comics/', //new comics
    component: Comics,
    children: [
      {
        path: 'series/:id',
        component: NotFound,
        children: [{ path: 'edit', component: NotFound }],
      },
    ],
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

// router.beforeEach(function(to, _, next) {
//   if (to.meta.requiresAuth && !store.getters.isAuthenticated) {
//     next('/auth');
//   // } else if (to.meta.requiresUnauth && store.getters.isAuthenticated) {
//   //   next('/dashboard');
//   } else {
//     next();
//   }
// });

export default router;
