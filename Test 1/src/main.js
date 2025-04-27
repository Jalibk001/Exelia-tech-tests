import { createApp } from "vue";
import "bootstrap/dist/css/bootstrap.min.css";
import "vue-loaders/dist/vue-loaders.css";
import "bootstrap/dist/js/bootstrap.bundle.min.js";
import App from "./App.vue";
import VueLoaders from "vue-loaders";

createApp(App).use(VueLoaders).mount("#app");
