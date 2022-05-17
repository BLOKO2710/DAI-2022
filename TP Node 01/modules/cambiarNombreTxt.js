import { rename, copyFile } from 'fs';
export default function cambiadoTxt(nombreActual, nombreCufa) {

rename(`${nombreActual}`, `${nombreCufa}`, (err) => {
    if (err) throw err;
    console.log('Rename complete!');
  });

}

export function copiarArchivo(nombreActual, nombreCufa) {
// File destination.txt will be created or overwritten by default.
copyFile(nombreActual, nombreCufa, (err) => {
  if (err) throw err;
  console.log(`${nombreActual} was copied to destination.txt`);
});
}