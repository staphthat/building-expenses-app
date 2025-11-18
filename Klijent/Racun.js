export class Racun
{
constructor(id, mesec, cenaVode, cenaStruje, cenaKomunalija, placen){
    this.id=id;
    this.mesec=mesec;
    this.cenaVode=cenaVode;
    this.cenaStruje=cenaStruje;
    this.cenaKomunalija=cenaKomunalija;
    this.placen=placen;

    this.kontejner=null;
    
    }
    crtajRacun(host){
        this.kontejner=document.createElement("div");
        this.kontejner.className="racun-kontejner";

        if(this.placen) {
        this.kontejner.classList.add("placen");
        } else {
        this.kontejner.classList.add("neplacen");
        }

        host.appendChild(this.kontejner);

        const info=[
        {label1: "Mesec:", label2: this.mesec},
        {label1: "Voda:", label2: this.cenaVode},
        {label1: "Struja:", label2: this.cenaStruje},
        {label1: "Komunalne usluge:", label2: this.cenaKomunalija},
        {label1: "Placen:", label2: this.placen? "Da" : "Ne"}
    ];
    info.forEach(i=>{
        let racunRed = document.createElement("div");
        racunRed.className="racun-red";
        this.kontejner.appendChild(racunRed);

        let racunLabela1 = document.createElement("label");
        racunLabela1.innerHTML=i.label1;
        racunRed.appendChild(racunLabela1);

        let racunLabela2 = document.createElement("label");
        racunLabela2.innerHTML=i.label2;
        racunRed.appendChild(racunLabela2);
    });
    }
}