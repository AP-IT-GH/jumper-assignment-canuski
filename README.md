# Jumper Opdracht Oscar-Abdulla
Dit document legt uit hoe onze opdracht werkt, eruit ziet en hoe de training verliep. Gemaakt door **Oscar Alexander** en **Abdulla Bagishev**.

## Overzicht

In deze opdracht hebben we een zelflerende agent gemaakt die obstakels ontwijkt door erover te springen. We hebben gebruikgemaakt van een aangepast Unity-omgeving, waarbij obstakels met een random snelheid bewegen. De agent is getraind met een reinforcement learning algoritme om te leren wanneer hij moet springen om de obstakels te vermijden. Als extra hebben we daarbij ook coins langs boven laten spawnen. De agent moet hierdoor leren om de obstakels te vermijden langs onder, maar de coins te verzamelen langs boven.

## Technische Details

We hebben gebruikgemaakt van Unity om de omgeving to maken en de ML-agents toolkit om de agent te trainen. 
**Omgeving:**
- De agent staat op de grond in een rechthoekige doos.
- Er is een bewegende ruimteschip dat hij dient te ontwijken.
- Elke keer dat er een ruiteschip spawnt krijgt hij een andere snelheid mee.
- Er is een bewegende coin met dezelfde logic als het ruimteschp, maar langs boven.
- De agent dient deze te verzamelen.

**Acties van de agent:**
- Omhoog springen
- Niet springen

**Beloning:**
- Positieve:
  - Springen over het schip.
  - Niet raken van het dak.
  - Stilstaan op de grond.
  - Coin verzamelen.
  - In leven blijven
- Negatieve:
  - Raken van het schip.
  - Raken van het plafond.
  - Dood gaan.
 
## Training
Voor het trainen hebben we een al eerdere gebruikte configuratie gebruikt die aan ons werd gegeven door de lector, die kan je terug vinden in de files. Training werd uitgevoerd met een enkele agent die meerdere obstakels moest ontwijken gedurende verschillende episoden. De agent ontvind beloning. De onderstaande afbeelding toont van tensorboard hoe het trainingsverloop liep:
![image](https://github.com/AP-IT-GH/jumper-assignment-canuski/assets/125011800/b831f535-3a4a-44b4-8f9e-ca4619d24e7c)
Aan de afebeelding te zien kan je duidelijk opmerken dat de agent trainde en bijleerde(bovenste grafiek). Je merkt ook dat het niet 100% is getraind, wij denken dat dit komt omdat de agent soms omhoog springt om een coin te pakken, om daarna direct terug te vallen op een ruitmteschip, waardoor hij veel beloning verliest. Als we dit uitvoerde zonder de coins werkte het veel beter, aan de onderstaande afbeelding kun je zien dat de training veel beter verliep. 
![image](https://github.com/AP-IT-GH/jumper-assignment-canuski/assets/125011800/317475e4-14be-478f-9bbb-6827ddefa675)
De oplossing hiervoor is om beter logica en een beter beloning/straffings systeem uit te werken. Echter, door tijdsgebrek hebben we dit niet kunnen doen. Dit is wel een goede les geweest en we gaan dit zeker in ons achterhoofd houden als wij aan de projectopdracht beginnen.

## Resultaten
De agent leert effectief te springen en obsakels te vermijden, maar heeft soms moeite met het kiezen tussen, de coin pakken of het schip ontwijken. Er was veel variatie in de 'learning curve', wat aangeeft dat de obstakelsnelheid en game logica een uitdagende factor was.

## Reproduceren van de opdracht
Om deze opdracht te reproduceren, volg je deze stappen.
1. Clone de GitHub-repository naar je lokale machine: <br> `git clone https://github.com/AP-IT-GH/jumper-assignment-canuski.git`
2. Installeer Unity en de ML-Agents Toolkit via de package manager, als je dat nog niet hebt gedaan.
3. Open het Unity project dat zich bevind in de repository.
4. Train de agent door de ML-Agents training te starten in een Python omgeving zoals Ananconda: <br> `mlagents-learn CubeAgent.yaml --run-id=CubeAgent`
5. Bekijk de trainingsresultaten in TensorBoard: run `tensorboard --logidir results` in de command prompt, ga vervolgends naar `localhost:6006` in je browser.

## Contact
Als je vragen hebt of hulp nodig hebt bij het reproducren van dit project, neem dan contact op met ons.
