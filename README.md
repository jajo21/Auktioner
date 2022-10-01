# Auktioner.NET - Januari 2022
## Instruktioner
1. Ladda ner repot från https://github.com/jajo21/Auktioner
2. Leta upp valfri terminal och utgå från mappen "./Auktioner"
3. Applikationen kräver att du har .NET5.0 SDK installerat
4. Skriv kommandot ```dotnet run``` i terminalen
5. Applikationen körs nu på port 5000 och 5001
6. Öppna en webbläsare och navigera in på https://localhost:5001/

## Syfte - YH-utbildning: Webbutvecklare .NET
* Inlämningsuppgift i kursen Dynamiska Webbsystem 1 - Januari 2022
* Beskrivning: Ett första större mer realistiskt projekt där vi ska sätta upp ett digitalt arbetsverktyg för ett företag som håller på med auktioner. Mer information finns i PDF:en under kravspecifikation
* Resultat: 100/100 (VG)

## Tekniker
* C#
* ASP.NET Core MVC
* ASP.Net Core Identity
* Entity Framework Core
* In Memory Database
* xUnit
* Razor

## Kravspecifikation
Det är en någorlunda längre kravspecifikation än mina tidigare uppgifter tillsammans med ett mer realistiskt scenario. För mer information klicka på PDF:en här: [Inlämning Auktioner.NET.pdf](https://github.com/jajo21/Auktioner/files/8840064/Inlamning_.Auktioner.NET.6Yhp.pdf) - Jag anser att jag har uppfyllt dessa krav.

## Förtydliganden/motivering

*Finns det något extra du vill förtydliga med din lösning? Både bra och mindre bra*  
Jag är mindre nöjd med uppbyggnaden av min kod. Går förmodligen att skapa den här lilla applikationen mer dry. Men tiden rann iväg och jag har spenderat för många timmar framför skärmen. Det har verkligen varit en bergochdalbana den här modulen. Men i slutändan fick jag ihop ett resultat iallafall även om jag är mindre nöjd med vissa delar. Vill lära mig så mycket mer. Det brister i kunskapen när man vill skapa något som ser smidigt och visuellt vackert ut, man får kämpa för att varje litet kodstycke ska göra som man vill. 

Mindre bra är att jag inte har fixat helheten med roller. Så att man hade kunnat koppla på exempelvis "Authorize(Roles = "Auctioneer")" på relevanta controllers för att begränsa användarna på ett annat sätt än vad jag har gjort i min app. Men efter många timmars läsande vet jag hur man skulle kunna implementera det i kod. Väljer att inte ändra mitt projekt eftersom uppgiftens krav redan är uppfyllda.
