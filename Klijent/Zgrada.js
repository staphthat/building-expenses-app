export class Zgrada1
{
    constructor()
    {
        this.listaStanova=[];
        this.kontejner = null;

    }

    crtaj(host){
        this.kontejner=document.createElement("div");
        this.kontejner.className="zgrada-kontejner";
        host.appendChild(this.kontejner);

        const leviDiv = document.createElement("div");
        leviDiv.className="levi-div";
        this.kontejner.appendChild(leviDiv);
        
        const desniDiv = document.createElement("div");
        desniDiv.className="desni-div";
        this.kontejner.appendChild(desniDiv);

        const izborDiv = document.createElement("div");
        izborDiv.className = "izbor-okvir";
        leviDiv.appendChild(izborDiv);

        const stanDiv = document.createElement("div");
        leviDiv.appendChild(stanDiv);

        //biraj stan
        const birajDiv = document.createElement("div");
        izborDiv.appendChild(birajDiv);

        const birajLabel = document.createElement("label");
        birajLabel.innerHTML="Biraj stan:";
        birajDiv.appendChild(birajLabel);

        const birajSelect = document.createElement("select");
        birajDiv.appendChild(birajSelect);

        this.listaStanova.forEach(stan=>{
            const option = document.createElement("option");
            option.innerHTML = stan.brojStana;
            option.value = stan.id;
            birajSelect.appendChild(option);
        });

        //prikazi dugme
        const prikaziButton = document.createElement("button");
        prikaziButton.className="prikazi-button";
        prikaziButton.innerHTML = "Prikazi informacije";
            prikaziButton.onclick=(ev)=>{
            const stanID = parseInt(birajSelect.value);
            this.prikaziInformacije(stanID, stanDiv, desniDiv);
        };
        izborDiv.appendChild(prikaziButton);
    }

    async prikaziInformacije(stanID, stanDiv, desniDiv){
        try{
            stanDiv.innerHTML="";
            desniDiv.innerHTML="";

            const response = await fetch(`https://localhost:7080/Ispit/VratiInformacijeZaStan/${stanID}`);
            if(!response.ok)
            {
                throw new Error("Neuspelo dobavljanje informacija za stan.");
            }
            const stanInfo = await response.json();

            let stanObjekat = this.listaStanova.find(s=>s.id===stanID);
            stanObjekat.prikaziStan(stanDiv);

            console.log(stanInfo);
        }
        catch(e)
        {
            throw new Error(e.message);
        }
    }
}