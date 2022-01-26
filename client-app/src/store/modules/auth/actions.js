let timer;

export default {
  async login(context, payload) {
    return context.dispatch('auth', {
      ...payload,
      mode: 'login'
    });
  },
  async signup(context, payload) {
    return context.dispatch('auth', {
      ...payload,
      mode: 'signup'
    });
  },
  async auth(context, payload) {
    const mode = payload.mode;
    let url =
      'https://localhost:5001/api/account/login';

    if (mode === 'signup') {
      url =
        'https://localhost:5001/api/account/register';
    }

    const response = await fetch(url, {
      method: 'POST',
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify({
        username: payload.username,
        password: payload.password,
        // returnSecureToken: true
      })
    });

    const responseData = await response.json();
    
    if (!response.ok) {
      const error = new Error(
        responseData.title || 'Failed to authenticate.'
      );
      throw error;
    }

    // const expiresIn = +responseData.expiresIn * 1000;
    const expiresIn = 1200000;
    const expirationDate = new Date().getTime() + expiresIn;

    localStorage.setItem('token', responseData.token);
    localStorage.setItem('username', responseData.username);
    localStorage.setItem('tokenExpiration', expirationDate);

    timer = setTimeout(function() {
      context.dispatch('autoLogout');
    }, expiresIn);

    context.commit('setUser', {
      token: responseData.idToken,
      userId: responseData.localId
    });
  },
  tryLogin(context) {
    const token = localStorage.getItem('token');
    const userId = localStorage.getItem('username');
    const tokenExpiration = localStorage.getItem('tokenExpiration');

    const expiresIn = +tokenExpiration - new Date().getTime();

    if (expiresIn < 0) {
      return;
    }

    timer = setTimeout(function() {
      context.dispatch('autoLogout');
    }, expiresIn);

    if (token && userId) {
      context.commit('setUser', {
        token: token,
        userId: userId
      });
    }
  },
  logout(context) {
    localStorage.removeItem('token');
    localStorage.removeItem('username');
    localStorage.removeItem('tokenExpiration');

    clearTimeout(timer);

    context.commit('setUser', {
      token: null,
      userId: null
    });
  },
  autoLogout(context) {
    context.dispatch('logout');
    context.commit('setAutoLogout');
  }
};
