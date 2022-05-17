import sumar, { restar, multiplicar, dividir} from "./modules/matematica.js";
import Alumno from "./modules/alumno.js";
import { decomposeUrl } from './modules/url.js';
import { getCurrencyByISO } from "./modules/conversionMoneda.js";
import {copiarArchivo} from "./modules/cambiarNombreTxt.js"

//1.1) index01.js Jugar con el console.log (concatenar, interpolar)

const saludar = function(hora = 'noches', nombre = 'Facu'){
    console.log (`Buenas ${hora}, ${nombre}`);
}
saludar();

//1.2) index02.js crear un modulo matematica /src/modules




console.log(sumar(1,2));
console.log(restar(5,2));
console.log(multiplicar(10,3));
console.log(dividir(6,2));

//1.3) index03.js crear una clase Alumno (username, DNI) instanciar dos en un archivo.

const alumno1 = new Alumno ("Facundo", 46029497);
const alumno2 = new Alumno ("Mariano", 46024583);
console.log(alumno1);
console.log(alumno2);

//1.4) index04.js utilizar el modulo interno fs (FileSystem) y hacer un ejemplo de una funcion que recibe como parametro un archivo y un nombre para leer el archivo y escribirlo con otro nombre.
/* rename('sexo.txt', 'CambiadoDeNombre.txt', (err) => {
    if (err) throw err;
    console.log('Rename complete!');
  }); */
  //let nombreActual = "sexo.txt";
  //let  nombreCufa = "tetas.txt";
//   cambiarTxt("Radrinazi.js", "tetas.txt");
  copiarArchivo("chistecito.txt","PolshuCrack.txt");

  console.log(decomposeUrl('http://www.ort.edu.ar:8080/alumnos/index.htm?curso=2022&mes=mayo'))

  console.log(getCurrencyByISO('US'));