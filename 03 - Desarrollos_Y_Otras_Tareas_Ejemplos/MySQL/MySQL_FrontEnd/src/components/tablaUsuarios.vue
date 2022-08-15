<template>
  <div class="tablaUsuarios">
    <v-container fluid>
      <v-row class="mt-4" justify="center">
        <v-col cols="11">
          <v-data-table
            :headers="headers"
            :items="tablaInfo"
            :items-per-page="8"
            class="elevation-1"
          ></v-data-table>
        </v-col>
      </v-row>
    </v-container>
  </div>
</template>

<script>
import { auth, fr } from "../main.js";
export default {
  name: "tablaUsuarios",
  data() {
    return {
      tablaInfo: [],
      userInfo: [],
      strDateTime: "",
      myDate: [],
      headers: [
        {
          text: "Nombre",
          align: "start",
          sortable: false,
          value: "nombreCompleto",
        },
        { text: "Correo Electronico", value: "correo" },
        { text: "Fecha registro", value: "fechaRegistro" },
        { text: "Ultimo Login", value: "fechaLogin" },
      ],
    };
  },
  components: {},
  methods: {
    getUserData() {
      const user = JSON.parse(window.sessionStorage.getItem("user"));
      this.userInfo = user;
      const userDe = auth.currentUser;
      console.log("auth: ", userDe);
    },
    getTableData() {
      const resultados = [];
      fr.collection("users")
        .get()
        .then((snapshot) => {
          snapshot.docs.forEach((resultado) => {
            let appObjet = { ...resultado.data() };
            resultados.push(appObjet);
          });
          this.tablaInfo = resultados;
        });
    },
    getFechaFormato() {
      const strDateTime = this.userInfo;
      const myDate = new Date(strDateTime);
      alert(myDate.toLocaleString());
      console.log("Fecha Cambiada", myDate);
    },
  },
  mounted() {
    this.getUserData();
    this.getTableData();
  },
};
</script>

<style scoped></style>
