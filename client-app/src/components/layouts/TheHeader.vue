<template>
  <header>
    <nav class="header-nav">
      <div class="nav-options">
        <router-link to="/" class="logo-link">
          <img
            src="../../assets/logo_small.png"
            alt="Comic Book Network"
            class="logo"
          />
        </router-link>
        <div class="options">
          <router-link to="/dashboard" class="nav-item">Dashboard</router-link>
          <router-link to="/comics" class="nav-item">Browse Comics</router-link>
          <router-link to="/lists/collection" class="nav-item"
            >My Lists</router-link
          >
        </div>
      </div>

      <div class="right-items">
        <div class="profile-button nav-dropdown-container">
          <div class="avatar-container">
            <img
              :src="require('../../assets/defaultAvatar.jpg')"
              class="avatar"
            />
          </div>
          <span>{{ username }}</span>
          <svg
            xmlns="http://www.w3.org/2000/svg"
            aria-hidden="true"
            role="img"
            width="1em"
            height="0.5em"
            preserveAspectRatio="xMidYMid meet"
            viewBox="0 0 64 64"
          >
            <path d="M32 62L62 2H2z" fill="currentColor" />
          </svg>
          <div class="nav-dropdown">
            <router-link to="/profile" class="navbar-item">Profile</router-link>
            <a
              target="_blank"
              rel="noopener noreferrer"
              href="https://github.com/"
              class="navbar-item"
              >Help</a
            >
            <hr class="navbar-divider" />
            <a class="navbar-item" @click="logout">Logout </a>
          </div>
        </div>

        <div class="hamburger-menu">
          <button
            id="menu__toggle"
            @click="isHamburgerOn = !isHamburgerOn"
            :class="isHamburgerOn ? 'open' : ''"
          >
            <div class="menu__btn">
              <span></span>
            </div>
          </button>

          <teleport to="#app">
            <ul
              class="menu__box"
              :class="isHamburgerOn ? 'menu__box-open' : 'menu__box-closed'"
            >
              <li>
                <router-link
                  to="/dashboard"
                  class="menu__item navbar-item"
                  @click="closeMenu()"
                  >Dashboard</router-link
                >
              </li>
              <li>
                <router-link
                  to="/comics"
                  class="menu__item navbar-item"
                  @click="closeMenu()"
                  >Browse Comics</router-link
                >
              </li>
              <li>
                <router-link
                  to="/lists/collection"
                  class="menu__item navbar-item"
                  @click="closeMenu()"
                  >My Lists</router-link
                >
              </li>
              <li>
                <router-link
                  to="/profile"
                  class="menu__item navbar-item"
                  @click="closeMenu()"
                  >Profile</router-link
                >
              </li>
              <li>
                <a
                  target="_blank"
                  rel="noopener noreferrer"
                  href="https://github.com/"
                  class="menu__item navbar-item"
                  >Help</a
                >
              </li>
              <li>
                <a class="menu__item navbar-item" @click="logout()">Logout</a>
              </li>
            </ul>
          </teleport>
        </div>
      </div>
    </nav>
  </header>
</template>

<script>
export default {
  data() {
    return {
      isMenuOpen: false,
      username: localStorage.getItem('username'),
      isHamburgerOn: false,
    };
  },
  methods: {
    logout() {
      this.$store.dispatch('logout');
      this.$router.replace('/auth');
    },
    closeMenu() {
      this.isHamburgerOn = false;
    },
  },
};
</script>

<style lang="scss" scoped>
.logo-link {
  display: flex;
  align-items: center;
}
.header-nav {
  display: flex;
  justify-content: space-between;
  background: rgb(56, 56, 56);
  box-shadow: 2px 2px 6px rgba(0, 0, 0, 0.2);
  color: white;
}
.nav-options {
  display: flex;
  align-items: center;
}
.logo {
  background: orange;
  height: 50px;
  margin-right: 1em;
}
.nav-item {
  padding: 1em;
}
.nav-item:hover,
.nav-item:focus,
.options .router-link-active {
  background: #616161;
}
.profile-button {
  display: flex;
  align-items: center;
  padding: 0 1em;
  cursor: pointer;
}
.right-items {
  display: flex;
}
.nav-dropdown {
  display: none;
}
.profile-button:hover .nav-dropdown {
  display: block;
  position: absolute;
  top: 50px;
  right: 0;
  width: 130px;
  background: white;
  box-shadow: 2px 2px 6px rgba(0, 0, 0, 0.2);
}
.navbar-item {
  text-align: center;
}
.avatar-container {
  display: flex;
  flex-direction: column;
  justify-content: center;
  margin-right: 0.6em;
}
.avatar {
  border-radius: 100%;
  width: 36px;
}

#menu__toggle {
  background: transparent;
  border: none;
  height: 100%;
  width: 5em;
  cursor: pointer;
}
.open .menu__btn > span {
  transform: rotate(45deg);
}
.open .menu__btn > span::before {
  top: 0;
  transform: rotate(0deg);
}
.open .menu__btn > span::after {
  top: 0;
  transform: rotate(90deg);
}
.open .menu__box {
  left: 0 !important;
}
.menu__btn {
  position: absolute;
  top: 20px;
  right: 20px;
  width: 26px;
  height: 26px;
  cursor: pointer;
  z-index: 150;
}
.menu__btn > span,
.menu__btn > span::before,
.menu__btn > span::after {
  display: block;
  position: absolute;
  width: 100%;
  height: 2px;
  background-color: orange;
  transition-duration: 0.25s;
}
.menu__btn > span::before {
  content: '';
  top: -8px;
}
.menu__btn > span::after {
  content: '';
  top: 8px;
}
.menu__box {
  display: none;
}
.menu__item {
  display: block;
  padding: 12px 24px;
  color: #333;
  font-family: 'Roboto', sans-serif;
  font-size: 20px;
  font-weight: 600;
  text-decoration: none;
  transition-duration: 0.25s;
}
.menu__item:hover,
.menu__item:focus,
.menu__item.router-link-active {
  background-color: #cfd8dc;
}

.hamburger-menu {
  display: none;
}

.nav-item {
  height: 70px;
  color: white;
}

@media (max-width: 700px) {
  .nav-dropdown-container,
  .options {
    display: none;
  }
  .hamburger-menu {
    display: block;
  }
  .menu__box {
    display: block;
    position: absolute;
    top: 0;
    left: 0;
    bottom: 0;
    width: 100vw;
    height: 100%;
    margin: 0;
    padding: 80px 0;
    list-style: none;
    background-color: #eceff1;
    transition-duration: 0.25s;
    z-index: 100;
  }
  .menu__box-closed {
  transform: translateX(-100%);
  }
  .menu__box-open {
    transition: translateX(100vw);
  }
}
</style>
