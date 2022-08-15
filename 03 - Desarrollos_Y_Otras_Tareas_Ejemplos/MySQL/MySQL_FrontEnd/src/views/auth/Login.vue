<template>
  <body>
    <div class="degradado"></div>
    <div class="center">
      <h1 style="color: #00bcd4">Bienvenido</h1>
      <v-card class="mx-auto px-6" max-width="500" elevation="0">
        <v-window v-model="$store.state.loginStep">
          <v-window-item :value="0">
            <p class="mt-6 titulo">Login</p>
            <v-form class="">
              <v-text-field
                prepend-icon="mdi-account"
                label="Correo Electronico"
                type="email"
                class=""
                v-model="loginCorreo"
              >
              </v-text-field>
              <v-text-field
                prepend-icon="mdi-lock"
                label="Contraseña"
                type="password"
                v-model="loginPass"
              >
              </v-text-field>
            </v-form>

            <v-card-actions class="mb-6 mt-4">
              <v-btn
                raised
                block
                outlined
                color="blue"
                elevation="6"
                @click="login()"
              >
                INICIAR SESION
              </v-btn>
            </v-card-actions>

            <v-row class="" justify-sm="center">
              <v-col class="" cols="12" xl="8" lg="8" md="8" sm="12" xs="12">
                <v-card-text> ¿No tienes una cuenta? </v-card-text>
              </v-col>
              <v-col class="" cols="12" xl="4" lg="4" md="4" sm="12" xs="12">
                <v-card-actions>
                  <v-btn
                    depressed
                    text
                    color="cyan"
                    @click="$store.state.loginStep = 1"
                  >
                    Registrarme
                  </v-btn>
                </v-card-actions>
              </v-col>
            </v-row>
          </v-window-item>
          <v-window-item :value="1">
            <p class="mt-6 titulo">Crear una cuenta</p>
            <v-form v-model="valid">
              <v-text-field
                prepend-icon="mdi-account"
                label="Correo Electronico"
                type="text"
                class="email"
                v-model="form.correo"
                :rules="emailRules"
              >
              </v-text-field>
              <v-row class="">
                <v-col
                  class="mb-0 pb-0"
                  cols="12"
                  xl="6"
                  lg="6"
                  md="6"
                  sm="12"
                  xs="12"
                >
                  <v-text-field
                    prepend-icon="mdi-lock"
                    label="Contraseña"
                    type="password"
                    v-model="form.pass"
                    :rules="passRules"
                  >
                  </v-text-field>
                </v-col>
                <v-col class="" cols="12" xl="6" lg="6" md="6" sm="12" xs="12">
                  <v-text-field
                    prepend-icon="mdi-lock"
                    label="Confirmar Contraseña"
                    type="password"
                    v-model="form.confirmPass"
                    :rules="passRules"
                  >
                  </v-text-field>
                </v-col>
              </v-row>
              <v-text-field
                prepend-icon="mdi-account"
                label="Nombre Completo"
                type="text"
                class=""
                v-model="form.nombreCompleto"
              >
              </v-text-field>
              <v-card-actions class="mb-6 mt-4">
                <v-btn
                  block
                  outlined
                  color="blue"
                  elevation="6"
                  @click="registerUser(form)"
                >
                  REGISTRARME
                </v-btn>
              </v-card-actions>
              <v-row justify="center" justify-sm="center">
                <v-card-actions class="mt-0 pt-0">
                  <v-btn
                    depressed
                    text
                    color="cyan"
                    @click="$store.state.loginStep = 0"
                  >
                    <v-icon left> mdi-arrow-left-bold </v-icon>
                    Ya tengo una cuenta
                  </v-btn>
                </v-card-actions>
              </v-row>
            </v-form>
          </v-window-item>
        </v-window>
      </v-card>
    </div>
  </body>
</template>

<script>
import { auth, fr } from "../../main.js";
export default {
  name: "login",
  components: {},
  data() {
    return {
      newLoginDate: "",
      valid: "",
      emailRules: [
        (v) =>
          !v ||
          /^\w+([.-]?\w+)@\w+([.-]?\w+)(.\w{2,3})+$/.test(v) ||
          "E-mail must be valid",
      ],
      passRules: [
        (v) => !v || v == this.form.pass || "Contras iguales deben ser",
      ],
      form: {
        nombreCompleto: "",
        correo: "",
        pass: "",
        confirmPass: "",
      },
      loginCorreo: "",
      loginPass: "",
    };
  },
  methods: {
    registerUser() {
      auth
        .createUserWithEmailAndPassword(this.form.correo, this.form.pass)
        .then((response) => {
          const usuario = {
            nombreCompleto: this.form.nombreCompleto,
            correo: this.form.correo,
            fechaRegistro: response.user.metadata.creationTime,
            fechaLogin: response.user.metadata.lastSignInTime,
          };
          this.guardarDatos(response.user.uid, usuario);
          console.log("auth data: ", response);
        })
        .catch((error) => {
          switch (error.code) {
            case "auth/email-already-in-use":
              alert("El correo  proporcionado ya esta en uso..");
              break;
            case "auth/invalid-email":
              alert("Dirección de correo invalida");
              break;
            case "auth/operation-not-allowed":
              alert("Registro no disponbible");
              break;
            case "auth/weak-password":
              alert(
                "La contraseña debe tener mayúsculas, minúsculas y números."
              );
              break;
          }
        });
    },
    guardarDatos(id, userData) {
      fr.collection("users")
        .doc(id)
        .set(userData)
        .then(() => {
          window.sessionStorage.setItem("key", id);
          window.sessionStorage.setItem("user", JSON.stringify(userData));
          this.$router.push({ name: "Home" });
        })
        .catch((error) => {
          console.error("Error writing document: ", error);
          alert("error");
        });
    },
    login() {
      auth
        .signInWithEmailAndPassword(this.loginCorreo, this.loginPass)
        .then((response) => {
          window.sessionStorage.setItem("key", response.user.uid);
          this.newLoginDate = response.user.metadata.lastSignInTime;
          fr.collection("users")
            .doc(response.user.uid)
            .get()
            .then((resp) => {
              window.sessionStorage.setItem(
                "user",
                JSON.stringify(resp.data())
              );
              fr.collection("users")
                .doc(window.sessionStorage.getItem("key"))
                .update({ fechaLogin: this.newLoginDate });
              this.$router.push({ name: "Home" });
            });
        })
        .catch(function (error) {
          // Handle Errors here.
          var errorCode = error.code;
          var errorMessage = error.message;
          if (errorCode === "auth/wrong-password") {
            alert("Wrong password.");
          } else {
            alert(errorMessage);
          }
          console.log(error);
        });
    },
  },
};
</script>

<style scoped>
@import url("https://fonts.googleapis.com/css2?family=Montserrat:wght@900&display=swap");

body {
  margin: 0;
  padding: 0;
  background: url("../../assets/media/backgrounds/nubes-copia.png");
  height: 100vh;
  overflow: hidden;
}
.degradado {
  background: linear-gradient(
    to right bottom,
    #081f42,
    #00276c,
    #002b96,
    #0628bd,
    #8d5cff
  );
  height: 100vh;
  opacity: 0.6;
}
.titulo {
  font: weight 700px;
  font-size: 30px;
  text-align: left;
}

@media screen and (min-width: 800px) {
  .center {
    position: absolute;
    top: 50%;
    left: 50%;
    transform: translate(-50%, -50%);
    width: 550px;
    height: 600px;
    background: white;
    border-radius: 20px;
    box-shadow: 10px 10px 15px rgba(0, 0, 0, 0.05);
  }
}
@media screen and (max-width: 800px) {
  .center {
    position: absolute;
    top: 50%;
    left: 50%;
    transform: translate(-50%, -50%);
    width: 400px;
    height: 600px;
    background: white;
    border-radius: 10px;
    box-shadow: 10px 10px 15px rgba(0, 0, 0, 0.05);
  }
}

.center h1 {
  text-align: center;
  padding: 20px 0;
  border-bottom: 1px solid silver;
}
</style>
