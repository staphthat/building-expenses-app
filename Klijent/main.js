import { Racun } from "./Racun.js";
import { Stan } from "./Stan.js";
import { Zgrada1 } from "./Zgrada.js";

const zgrada = new Zgrada1();

const response = await fetch("https://localhost:7080/Ispit/VratiSve");
if(!response.ok)
{
    throw new Error ("Neuspelo pribavljanje podataka.");
}
const stanoviData = await response.json();

stanoviData.forEach(st=>{
    const stan = new Stan(st.id, st.brojStana, st.imeVlasnika, st.povrsina, st.brojClanova);
    zgrada.listaStanova.push(stan);
    st.racuni.forEach(rac=>{
        const racun = new Racun(rac.id, rac.mesec, rac.cenaVode, rac.cenaStruje, rac.cenaKomunalija, rac.placen);
        stan.listaRacuna.push(racun);
    });
});
console.log(stanoviData);
zgrada.crtaj(document.body);
