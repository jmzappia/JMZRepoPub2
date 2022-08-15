<template>
  <div class="Home">
    <navbar></navbar>
    <cartasHome></cartasHome>
  </div>
</template>

<script>
import { fr } from "../main.js";
import navbar from "@/components/navbar.vue";
import cartasHome from "@/components/cartasHome.vue";

export default {
  name: "Home",
  components: {
    navbar,
    cartasHome,
  },
  data() {
    return {};
  },
  methods: {
    async validate() {
      const key = window.sessionStorage.getItem("key");
      if (key == null) {
        this.$router.push({ name: "Login" });
      } else {
        const snapshot = await fr.collection("users").doc(key).get();
        console.log("La respoiestra:", snapshot);
        if (!snapshot.exists) {
          this.$router.push({ name: "Login" });
        }
      }
    },
  },
  mounted() {
    this.validate();
  },
  created() {},
};
</script>

<style scoped></style>
