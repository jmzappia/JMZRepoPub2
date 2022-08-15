<template>
  <div class="Usuarios">
    <navbar></navbar>
    <tablaUsuarios></tablaUsuarios>
  </div>
</template>

<script>
import { fr } from "../main.js";
import navbar from "@/components/navbar.vue";
import tablaUsuarios from "@/components/tablaUsuarios.vue";
export default {
  name: "Usuarios",
  components: {
    navbar,
    tablaUsuarios,
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
};
</script>

<style scoped></style>
