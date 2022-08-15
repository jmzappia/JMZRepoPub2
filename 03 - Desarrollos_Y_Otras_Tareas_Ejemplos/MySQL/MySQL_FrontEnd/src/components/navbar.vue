<template>
  <div class="navbar">
    <v-app-bar color="cyan" height="100px" fixed elevate-on-scroll class="">
      <v-row class="mx-auto">
        <v-btn x-large text color="white" depressed plain href="/Home">
          Home
        </v-btn>
        <v-btn x-large text color="white" depressed plain href="/Usuarios">
          Usuarios
        </v-btn>
        <v-spacer></v-spacer>
        <v-avatar class="mt-1" :color="getColorBack()" size="42">
          <span class="white--text text-h8">
            {{ inicialNombres }}
          </span>
        </v-avatar>
        <v-menu
          offset-y
          bottom
          origin="center center"
          transition="scale-transition"
        >
          <template v-slot:activator="{ on, attrs }">
            <v-btn color="white" x-large text v-bind="attrs" v-on="on">
              {{ userInfo.nombreCompleto }}
            </v-btn>
          </template>
          <v-list light>
            <v-list-item>
              <v-list-item-title>
                <v-btn plain text class="tab" @click="logOut()">
                  Cerrar Sesion
                </v-btn>
              </v-list-item-title>
            </v-list-item>
          </v-list>
        </v-menu>
      </v-row>
    </v-app-bar>
  </div>
</template>

<script>
export default {
  name: "navbar",
  data() {
    return {
      texto: "",
      userInfo: [],
      inicialNombres: "",
    };
  },
  components: {},
  methods: {
    getUserData() {
      const user = JSON.parse(window.sessionStorage.getItem("user"));
      this.userInfo = user;
      console.log(this.userInfo);
    },
    logOut() {
      window.sessionStorage.removeItem("key");
      window.sessionStorage.removeItem("user");
      this.$router.push({ name: "Login" });
    },
    nombreAvatar() {
      let a = [];
      let resultado = [];
      let cadena = this.userInfo.nombreCompleto,
        separador = " ",
        arregloDeSubcadenas = cadena.split(separador);

      for (let x = 0; x < arregloDeSubcadenas.length; x++) {
        resultado = arregloDeSubcadenas[x].substring(0, 1);
        a[x] = resultado;
        console.log("nomrbe avatar: ", a);
      }
      let text = a[0].toString() + a[1].toString();
      this.inicialNombres = text;
    },
    getColorBack() {
      let a = 1;
      let b = 6;
      let numeroAleatorio = a + Math.floor(Math.random() * b);
      if (numeroAleatorio == 1) return "#E91E63";
      else if (numeroAleatorio == 2) return "#7E57C2";
      else if (numeroAleatorio == 3) return "#82b1ff";
      else if (numeroAleatorio == 4) return "#64DD17";
      else if (numeroAleatorio == 5) return "#FF9800";
      else if (numeroAleatorio == 6) return "#BA68C8";
    },
  },
  mounted() {
    this.getUserData();
    this.nombreAvatar();
  },
};
</script>

<style>
@import url("https://fonts.googleapis.com/css2?family=Poppins:wght@500&display=swap");
.navbar {
  display: block;
  height: 100px;
  width: 100%;
}
</style>

<style scoped>
.btn-selected {
  color: #000000 !important;
}
.tab {
  color: #000000;
  font-weight: 400;
  font-family: "Poopins", sans-serif;
}
</style>
