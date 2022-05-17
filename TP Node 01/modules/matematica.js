
export default function sumar (x1, x2) {
    return x1 + x2;
}

export const restar = (x1, x2) => {
   return x1 - x2;
}

export const multiplicar = (x1, x2) => {
    return x1 * x2;
}
export const dividir = (x1, x2) => {
    if (x2 == 0){
        console.log("No se puede dividir");
    }
    else{
        return x1 / x2;
    }
}


