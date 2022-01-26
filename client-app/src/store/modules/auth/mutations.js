export default {
  setUser(state, payload) {
    state.token = payload.token;
    state.username = payload.userId;
    state.didAutoLogout = false;
  },
  setAutoLogout(state) {
    state.didAutoLogout = true;
  }
};