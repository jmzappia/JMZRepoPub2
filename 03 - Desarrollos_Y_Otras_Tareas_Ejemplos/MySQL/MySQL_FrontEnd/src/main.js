import Vue from "vue";
import App from "./App.vue";
import router from "./router/index.js";
import store from "./store";
import vuetify from "./plugins/vuetify";
import VueSweetalert2 from "vue-sweetalert2";

import axios from "axios";
import firebase from "firebase/compat/app";
import "firebase/compat/firestore";
import "firebase/compat/auth";

Vue.use(VueSweetalert2);

Vue.prototype.$axios = axios;
Vue.config.productionTip = false;

const firebaseConfig = {
  apiKey: "AIzaSyAuX9FWlSC7kbW02q8m9FyVbE92jML1x1Q",
  authDomain: "prueba-bwl.firebaseapp.com",
  projectId: "prueba-bwl",
  storageBucket: "prueba-bwl.appspot.com",
  messagingSenderId: "819358342089",
  appId: "1:819358342089:web:7bc5b440e2253879b26618",
  measurementId: "G-DN9LTTWC72",
};

Vue.config.productionTip = false;

new Vue({
  router,
  store,
  vuetify,

  render: function (h) {
    return h(App);
  },
}).$mount("#app");

firebase.initializeApp(firebaseConfig);
const fr = firebase.firestore();
const auth = firebase.auth();

export { fr, auth, firebase };
