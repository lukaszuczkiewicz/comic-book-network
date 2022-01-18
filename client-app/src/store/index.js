import { createStore } from 'vuex';

import authModule from './modules/auth/index.js';

export default createStore({
  // state() {
  //   return {
  //     token: true
  //   }
  // },
  modules: {
    auth: authModule
  },
  // mutations: {
  //   login(state) {
  //     state.token = true;
  //   }
  // },
  // actions: {

  // },
  // getters: {
  //   isAuthenticated(state) {
  //     return !!state.token;
  //   },
  // }
})
