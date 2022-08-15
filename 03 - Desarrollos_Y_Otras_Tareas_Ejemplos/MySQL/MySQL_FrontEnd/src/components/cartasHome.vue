<template>
  <div class="cartasHome">
    <v-container fluid>
      <v-row class="mt-4 mb-6">
        <v-col cols="12" md="8">
          <v-row>
            <v-col cols="12" md="6">
              <v-card
                elevation="4"
                outlined
                min-height="200px"
                max-height="380px"
              >
                <div class="titulo-tar margen-iz">Clima</div>

                <v-divider class="mt-1 mx-3 color-linea"></v-divider>
                <v-card-text class="mx-auto">
                  <v-row justify="center" class="mt-1">
                    <v-col
                      cols="12"
                      xl="4"
                      lg="4"
                      md="4"
                      sm="12"
                      xs="12"
                      class="mx-auto my-0 py-0"
                    >
                      <v-img
                        class="icono-clima"
                        contain
                        :src="clima.current.condition.icon"
                      >
                      </v-img>
                    </v-col>
                    <v-col
                      cols="12"
                      xl="8"
                      lg="8"
                      md="8"
                      sm="12"
                      xs="12"
                      class="mt-4 mx-0 px-0"
                    >
                      <h1 class="subtitulo">{{ clima.current.temp_c }} ºC</h1>
                      <div class="d-flex justify-center">
                        <p class="">
                          {{ clima.current.condition.text }}
                        </p>
                      </div>
                    </v-col>
                  </v-row>
                </v-card-text>
              </v-card>
            </v-col>
            <v-col cols="12" md="6">
              <v-card
                elevation="4"
                outlined
                min-height="200px"
                max-height="380px"
              >
                <div class="titulo-tar margen-iz">País Seleccionado</div>

                <v-divider class="mt-1 mx-3 color-linea"></v-divider>
                <div class="d-flex justify-center">
                  <v-row
                    justify="space-around"
                    justify-sm="center"
                    class="mt-3"
                  >
                    <v-col
                      cols="12"
                      xl="5"
                      lg="5"
                      md="12"
                      sm="12"
                      xs="12"
                      class="mb-0 pb-0"
                    >
                      <p class="subtitulo mt-6">{{ paisName }}</p>
                    </v-col>
                    <div class="d-flex justify-center">
                      <v-col
                        cols="12"
                        xl="7"
                        lg="7"
                        md="12"
                        sm="12"
                        xs="12"
                        class="my-auto mx-0 px-0"
                      >
                        <v-img
                          contain
                          class="img-bandera-grande"
                          :src="paisImg"
                        >
                        </v-img>
                      </v-col>
                    </div>
                  </v-row>
                </div>
              </v-card>
            </v-col>
          </v-row>

          <v-row>
            <v-col cols="12" md="6">
              <v-card
                elevation="4"
                outlined
                min-height="200px"
                max-height="380px"
              >
                <div class="titulo-tar margen-iz">Tareas Pendientes</div>

                <v-divider class="mt-2 mx-3 color-linea"></v-divider>
                <v-row class="mx-auto mt-1">
                  <v-col
                    cols="12"
                    class="ml-2 mb-0 pb-0 mt-0 pt-0"
                    v-for="(item, i) in itemsPend"
                    :key="i"
                  >
                    <p>
                      {{ item.tareasPend }}
                    </p>
                  </v-col>
                </v-row>
              </v-card>
            </v-col>
            <v-col cols="12" md="6">
              <v-card
                elevation="4"
                outlined
                min-height="200px"
                max-height="380px"
              >
                <div class="titulo-tar margen-iz">Hora</div>

                <v-divider class="mt-1 mx-3 color-linea"></v-divider>
                <v-card-text class="mx-auto">
                  <v-row class="mt-3" justify="center">
                    <v-col cols="12">
                      <!-- <div class="hour">{{hours}}</div>
                      <div class="dots">:</div>
                      <div class="min">{{minutes}}</div>
                      <div class="dots">:</div>
                      <div class="secs">{{seconds}}</div>
                      <div class="mode"></div>                  -->
                      <!-- <div
                      id="DigitalCLOCK"
                      class="clock"
                      onload="showTime()"
                      ></div> -->
                      <h1 class="subtitulo">
                        {{ newHora }}
                      </h1>
                    </v-col>
                  </v-row>
                </v-card-text>
              </v-card>
            </v-col>
          </v-row>

          <v-row>
            <v-col cols="12" md="6">
              <v-card
                elevation="4"
                outlined
                min-height="200px"
                max-height="380px"
              >
                <div class="titulo-tar margen-iz">Tareas Completadas</div>

                <v-divider class="mt-1 mx-3 color-linea"></v-divider>
                <v-row class="mx-auto mt-2">
                  <v-col
                    cols="12"
                    class="ml-2 mb-0 pb-0 mt-0 pt-0"
                    v-for="(item, i) in itemsComp"
                    :key="i"
                  >
                    <p>
                      {{ item.tareasComp }}
                    </p>
                  </v-col>
                </v-row>
              </v-card>
            </v-col>
            <v-col cols="12" md="6">
              <v-card
                elevation="4"
                outlined
                min-height="200px"
                max-height="200px"
                class="scroll"
              >
                <div class="titulo-tar margen-iz">Zonas Horarias</div>

                <v-divider class="mt-1 mx-3 color-linea"></v-divider>
                <v-row justify="center" class="">
                  <v-col
                    cols="12"
                    xl="12"
                    lg="12"
                    md="12"
                    sm="12"
                    xs="12"
                    class="pb-0 pt-2"
                    v-for="item in timeZones.zones"
                    :key="item.id"
                  >
                    <div class="d-flex justify-left">
                      <v-btn
                        plain
                        class="zonas"
                        text
                        @click="setHorayClima(item.zoneName)"
                      >
                        {{ item.zoneName }}
                      </v-btn>
                    </div>
                  </v-col>
                </v-row>
              </v-card>
            </v-col>
          </v-row>
        </v-col>

        <v-col cols="12" md="4">
          <v-card elevation="2" outlined min min-height="640px">
            <div class="titulo-tar margen-iz">Países Disponibles</div>
            <v-divider class="mt-1 mx-3 color-linea"></v-divider>
            <v-row class="mt-6" justify="space-around">
              <v-col
                cols="12"
                xl="6"
                lg="6"
                md="6"
                sm="12"
                xs="12"
                class="mx-auto"
              >
                <div class="d-flex justify-center">
                  <v-img
                    class="img-bandera-chica"
                    contain
                    src="../assets/media/banderas/mexicoFlag.png"
                  >
                  </v-img>
                </div>
              </v-col>
              <v-col
                cols="12"
                xl="6"
                lg="6"
                md="6"
                sm="12"
                xs="12"
                class="mt-3 mx-auto"
              >
                <div class="d-flex justify-left">
                  <v-btn class="titulo-pais" text plain @click="setPais('MX')">
                    México
                  </v-btn>
                </div>
              </v-col>
            </v-row>
            <v-divider class="mt-4 mx-3"></v-divider>
            <v-row class="mt-6" justify="space-around">
              <v-col cols="12" xl="6" lg="6" md="6" sm="12" xs="12" mx-auto>
                <div class="d-flex justify-center">
                  <v-img
                    class="img-bandera-chica"
                    contain
                    src="../assets/media/banderas/canadaFlag.png"
                  >
                  </v-img>
                </div>
              </v-col>
              <v-col
                cols="12"
                xl="6"
                lg="6"
                md="6"
                sm="12"
                xs="12"
                class="mt-3 mx-auto"
              >
                <div class="d-flex justify-left">
                  <v-btn class="titulo-pais" text plain @click="setPais('CA')">
                    Canadá
                  </v-btn>
                </div>
              </v-col>
            </v-row>
            <v-divider class="mt-4 mx-3"></v-divider>
            <v-row class="mt-6" justify="space-around">
              <v-col cols="12" xl="6" lg="6" md="6" sm="12" xs="12" mx-auto>
                <div class="d-flex justify-center">
                  <v-img
                    class="img-bandera-chica"
                    contain
                    src="../assets/media/banderas/usaFlag.png"
                  >
                  </v-img>
                </div>
              </v-col>
              <v-col
                cols="12"
                xl="6"
                lg="6"
                md="6"
                sm="12"
                xs="12"
                class="mt-3 mx-auto"
              >
                <div class="d-flex justify-left">
                  <v-btn class="titulo-pais" text plain @click="setPais('US')">
                    USA
                  </v-btn>
                </div>
              </v-col>
            </v-row>
            <v-divider class="mt-4 mx-3"></v-divider>
            <v-row class="mt-6" justify="space-around">
              <v-col cols="12" xl="6" lg="6" md="6" sm="12" xs="12" mx-auto>
                <div class="d-flex justify-center">
                  <v-img
                    class="img-bandera-chica"
                    contain
                    src="../assets/media/banderas/holandaFlag.png"
                  >
                  </v-img>
                </div>
              </v-col>
              <v-col
                cols="12"
                xl="6"
                lg="6"
                md="6"
                sm="12"
                xs="12"
                class="mt-3 mx-auto"
              >
                <div class="d-flex justify-left">
                  <v-btn class="titulo-pais" text plain @click="setPais('NL')">
                    Holanda
                  </v-btn>
                </div>
              </v-col>
            </v-row>
          </v-card>
        </v-col>
      </v-row>
    </v-container>
  </div>
</template>

<script>
export default {
  name: "cartasHome",
  components: {},
  data() {
    return {
      itemsPend: [
        { tareasPend: "Ir al Banco" },
        { tareasPend: "Revisar balance general " },
        { tareasPend: "Ajustar métricas de diseño" },
      ],
      itemsComp: [
        { tareasComp: "Terminar la prueba" },
        { tareasComp: "Debuggear code" },
        { tareasComp: "Realizar pruebas unitarias" },
      ],
      timeZones: [],
      paisName: "",
      paisImg: "",
      clima: [],
      newHora: "",
      userInfo: [],
      time: null,
      interval: null,
      // hours: 0,
      // minutes: 0,
      // seconds: 0,
    };
  },
  // beforeDestroy(){
  //   clearInterval(this.interval)
  // },
  // created(){
  //   this.interval = setInterval(() => {
  //     this.time = Intl.DateTimeFormat(navigator.language,{
  //       hour: 'numeric',
  //       minute: 'numeric',
  //       second: 'numeric',
  //     }).format()
  //   }, 1000)
  // },
  mounted() {
    this.setPais("MX");
    //this.setHorayClima(this.timeZones.zones[0].zoneName);
    this.getUserData();
    this.setTime();
  },
  methods: {
    async getData(city) {
      let response = await fetch(
        "https://api.timezonedb.com/v2.1/list-time-zone?key=TMTQ32PJM68R&format=json&country=" +
          city
      );
      const result = await response.json();
      this.timeZones = result;
      const name = await this.timeZones.zones[0].zoneName;
      console.log(name);
      this.setHorayClima(name);
    },
    async setPais(city) {
      switch (city) {
        case "MX":
          this.paisName = "México";
          this.paisImg =
            "https://4.bp.blogspot.com/-raAfjkYY0Ik/USvYXiU_3yI/AAAAAAAADGU/VoL41j2wzZ4/w1200-h630-p-k-no-nu/banderamexicoactual.jpg";
          break;
        case "CA":
          this.paisName = "Canadá";
          this.paisImg =
            "https://www.banderas-mundo.es/data/flags/w1600/ca.png";
          break;
        case "US":
          this.paisName = "USA";
          this.paisImg =
            "https://www.nicepng.com/png/full/6-63506_usa-png-clipart-american-flag-icon-png.png";
          break;
        case "NL":
          this.paisName = "Holanda";
          this.paisImg =
            "https://www.paisesbajosytu.nl/binaries/medium/content/gallery/netherlandsandyou/content-afbeeldingen/algemeen/vlag-nederland.png";
          break;
      }
      this.getData(city);
    },
    async setHorayClima(nombreDeZona) {
      console.log(
        "http://api.weatherapi.com/v1/current.json?key=0aa62ac6ab564f0899811732212409&q&q=" +
          nombreDeZona +
          "&aqi=yes"
      );
      let response = await fetch(
        "https://api.weatherapi.com/v1/forecast.json?key=0aa62ac6ab564f0899811732212409&q&q&q=" +
          nombreDeZona +
          "&days=1&aqi=no&alerts=yes"
      );
      this.clima = await response.json();
      console.log(this.clima.current.temp_c);
      this.setHoraReal(nombreDeZona);
    },
    async setHoraReal(nombreDeZona) {
      let response = await fetch(
        "https://api.weatherapi.com/v1/timezone.json?key=0aa62ac6ab564f0899811732212409&q&q&q=" +
          nombreDeZona
      );
      this.hora = await response.json();
      this.newHora = new Date(
        this.hora.location.localtime_epoch * 1000
      ).toLocaleTimeString();
      console.log(
        new Date(this.hora.location.localtime_epoch).toLocaleTimeString()
      );
      console.log("Hora real:", this.newHora);
      //console.log("String a numero:", parseInt(this.newHora[0,1]), parseInt(this.newHora[3,4]));
      // var date = new Date(this.hora.location.localtime_epoch);
    },
    getUserData() {
      const user = JSON.parse(window.sessionStorage.getItem("user"));
      this.userInfo = user;
      console.log(this.userInfo);
    },
    // showTime(){

    // var h = parseInt(this.newHora);
    // var m = parseInt(this.newHora[3] , this.newHora[4]);
    // var s = parseInt(this.newHora[6], this.newHora[7]);
    // var session = "AM";

    // if(h == 0){
    //     h = 12;
    // }

    // if(h > 12){
    //     h = h - 12;
    //     session = "PM";
    // }

    // h = (h < 10) ? "0" + h : h;
    // m = (m < 10) ? "0" + m : m;
    // s = (s < 10) ? "0" + s : s;

    // var time = h + ":" + m + ":" + s + " " + session;
    // document.getElementById("DigitalCLOCK").innerText = time;
    // document.getElementById("DigitalCLOCK").textContent = time;
    // setTimeout(this.showTime, 1000);
    // },

    // setTime () {
    //   setInterval(() => {
    //     //const date = new Date()
    //     for(var i= 0; i< this.newHora.length; i++) this.newHora[i] = +this.newHora[i];
    //     this.hours = this.newHora;
    //     this.minutes = this.newHora;
    //     this.seconds = this.newHora;
    //   }, 1000)
    // },

    // // checkSingleDigit (digit) {
    // //   return ('0' + digit).slice(-2)
    // // },
  },
};
</script>

<style scoped>
@import url("https://fonts.googleapis.com/css2?family=Poppins:wght@300&display=swap");

p {
  font-family: "Poppins";
  font-weight: 200px;
  font-size: 19px;
  text-align: justify;
}
.scroll {
  overflow-y: scroll;
}
.clock {
  transform: translateX(-50%) translateY(-50%);
  color: #ff4747;
  font-size: 60px;
  letter-spacing: 7px;
}
.titulo {
  font-family: "Poppins";
  font: weight 700px;
  font-size: 28px;
  line-height: 40px;
  color: black;
  text-align: center;
}
.titulo-pais {
  font-family: "Poppins";
  font: weight 600px;
  font-size: 22px;
  color: black;
}
.titulo-tar {
  font-family: "Poppins";
  font-size: 20px;
  text-align: left;
  color: rgba(0, 0, 0, 0.4);
}
.subtitulo {
  font-family: "Poppins";
  font: weight 700px;
  font-size: 38px;
  line-height: 40px;
  color: black;
  text-align: center;
}
.tareas {
  font-family: "Poppins";
  font: weight 600px;
  font-size: 20px;
  line-height: 40px;
  color: black;
}
.zonas {
  font-family: "Poppins";
  font-weight: 200px;
  font-size: 15px;
  text-align: justify;
}
.lista {
  list-style: none;
}
.linea {
  width: 200px;
  height: 0px;
  border: 2px solid #495167;
  opacity: 1;
}
.color-linea {
  background-color: cyan;
}
.color-fondo {
  background-color: blueviolet;
}
.margen-iz {
  margin-top: 12px;
  margin-left: 20px;
}
.icono-clima {
  display: block;
  width: 120px;
}
.img-bandera-grande {
  display: block;
  max-width: 220px;
}
.img-bandera-chica {
  display: block;
  max-width: 90px;
}
</style>
