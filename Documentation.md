**Dokumentation**

**Arbetssätt** 

Vi har arbetat på distans men varit uppkopplade och nåbara under hela dagen. Vi har haft standups möten samt extra möten vid behov.
Vi har använt Projects här på Github med Backlog, in progress, review och done. Där har man enkelt kunnat se och följa vad alla arbetar med.
Efter en pull request ska minst en approva och reviewa koden.
Vi hade problem dom första dagarna med att få appen att funka- berodde på att man skulle ha både Blazor projektet och API projektet som startprojekt. Det var skönt när det löste sig!
Att fördela arbetsuppgifterna har gått mycket bra. Alla har varit mer eller mindre delaktiga i alla delar.
Vi har hjälpt varandra när vi kört fast och fått bra input.


**Endpoints**

Vi valde att forsätta med minimal API då vi var mest bekväma med det samt att vi upplever att det är smidigare än controllers. 
Vi har endpoints för event, login/registrering, statestik och bokning.

**Databas**

Vi använder SQL Server och hanterar databasen med Entity Framework Core, vilket vi satte upp redan i början av projektet för att underlätta databasåtkomst.
Applikationen har tre huvudtabeller: Users, Events och Bookings.
Tabellerna har relationer där en användare kan ha flera bokningar, och ett event kan ha flera deltagare.
Vi använder migrationer för att hantera databasändringar på ett strukturerat sätt.
Seed-data används för att skapa exempelanvändare och event vid första körningen av systemet vilket vi har löst med hjälp av migrations, som flitigt används även efter första uppsättningen.
Detta ger oss en flexibel och skalbar databasstruktur som enkelt kan uppdateras och hanteras.


**Inlogg, Authorize och Local storage**

Till en början skapade vi inlogg med hjälp av API och Cookies endast, vilket satte käppar i hjulen när vi skulle implementera [AuthorizeView] i Blazor, då det inte fungerade med cookies på olika localhost.
Efter flera försök att lösa det med hjälp av CORS och olika inställningar i API och Blazor, samt att releasa projektet på samma localhost, gav vi upp och valde att använda oss av local storage istället.
För vidare utveckling skulle vi kolla vidare på Tokens via JWT för bättre säkerhet om mer tid fanns.
Då vi ville gömma sidor för obehöriga användare använde vi [AuthorizeView] för att visa olika sidor beroende på om användaren är inloggad eller inte och vad användaren har för roll vilket hämtas från localhost.

**Eventservice**

**Statistik**

**Adminsidor**

Vi har adminsidor som hanterar events, users, bokningar. Man kan skapa, uppdatera eller radera events. Radera användare och bokningar. Se statistik över bokningar.

**Usersidor**

Som användare kan man se event, filtrera, sortera och söka. Boka via ett formulär och få en bokningsbekräftelse. Man kan se sina bokningar och radera en bokning.

**Styling**

Vi använder Bootstrap tillsammans med egen CSS för att skapa en enhetlig och responsiv design. Bootstrap ger oss en solid grund, medan egen CSS ger oss möjlighet att anpassa detaljer.
Formulär använder Bootstrap-klasser för enkel styling och tydlig validering.
Responsivitet hanteras med Bootstrap grid och media queries för att anpassa layouten till olika skärmstorlekar.

**Design**
Vi har valt att ha en enkel och tydlig design med fokus på funktionalitet. 
Färgmässigt anpassa vi efter Golden ticket som är namnet för appen och för att få den att sticka ut mer valde vi något mörkare för meny och komponenter som text och buttons av designen medan själva bakgrundsfärgen förblir neutral.


