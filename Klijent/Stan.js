import { Zgrada1 } from "./Zgrada.js";

export class Stan
{
constructor(id, brojStana, imeVlasnika, povrsina, brojClanova){
this.id=id;
this.brojStana=brojStana;
this.imeVlasnika=imeVlasnika;
this.povrsina=povrsina;
this.brojClanova=brojClanova;

this.listaRacuna=[];
this.kontejner = null;
}

prikaziStan(host){
    this.kontejner = document.createElement("div");
    this.kontejner.className = "stan-kontejner";
    host.appendChild(this.kontejner);

    const info=[
        {label1: "Broj stana:", label2: this.brojStana},
        {label1: "Ime vlasnika:", label2: this.imeVlasnika},
        {label1: "Povrsina (m2):", label2: this.povrsina},
        {label1: "Broj clanova:", label2: this.brojClanova}
    ];
    info.forEach(i=>{
        let infoRed = document.createElement("div");
        this.kontejner.appendChild(infoRed);

        let infoLabela1 = document.createElement("label");
        infoLabela1.innerHTML=i.label1;
        infoRed.appendChild(infoLabela1);

        let infoLabela2 = document.createElement("label");
        infoLabela2.innerHTML=i.label2;
        infoRed.appendChild(infoLabela2);
    });

    const izracunajButton = document.createElement("button");
    izracunajButton.innerHTML="Izracunaj ukupno zaduzenje";
    izracunajButton.className= "izracunaj-button";
    izracunajButton.onclick=(ev)=>{
        this.izracunajZaduzenje();
        izracunajButton.disabled = true;
    }
    this.kontejner.appendChild(izracunajButton);
    console.log("Prosli smo i dugme");

    this.listaRacuna.forEach(racun=>{
        let divZaRacune = document.querySelector(".desni-div");
        racun.crtajRacun(divZaRacune);
        console.log("U forEach petlji smo");
    });
}

async izracunajZaduzenje(){
    try{
        const response = await fetch(`https://localhost:7080/Ispit/IzracunajUkupnoZaduzenje/${this.id}`);
        if (!response.ok)
        {
            throw new Error("Neuspelo dobavljanje zaduzenja.");
        }
        const zaduzenjeData = await response.json();

        console.log(zaduzenjeData);
        const dugmeIzracunaj = document.querySelector(".izracunaj-button");
        dugmeIzracunaj.innerHTML=`Ukupno zaduzenje: ${zaduzenjeData.zaduzenje}`;
    }
    catch(e)
    {
        alert(e.message);
    }
}
}
