import { createStore } from 'vuex'

export default createStore({
  state() {
    return {
      token: true
    }
  },
  modules: {
  },
  mutations: {
    login(state) {
      state.token = true;
    }
  },
  actions: {
    login(context) {
      context.commit('login');
    }
  },
  getters: {
    isAuthenticated(state) {
      return !!state.token;
    },
  }
})
