##Säkerhet
Med hjälp av AspNetCore.Authorization har jag kunnat lägga till säkerhetsdörren [Authorize]
i min auctionItemcontroller, de action-metoder som finns innuti controllern är med andra ord skyddade
så att endast registrerade användare som är inloggade har möjlighet att besöka sidorna "Add auction item" 
samt "Edit auction item". En besökare som inte är inloggad kan därmed inte nå dessa sidor

## Användare
Blev väldigt stressigt att bli klar med allt i tid, och fick därför prioritera kraven allt eftersom. 
Därför finns bara en typ av användare, den "vanliga" användaren har därmed tillgång till att 
skapa,redigera och radera ett föremål.



## TODO - Kvar att göra

Skapa ytterligare användartyper och tilldela dessa olika auktoriteter med hjälp av roller och claims. 
Lägga mer tid på styling/css för att ge användare en behagligare upplevelse 
Skapa ytterligare controller för att ge varje controll ett tydligare syfte,
just nu finns bara två controller och det kan vara svårt att förstå vad varje actionmetod egentligen gör.
Extra finjustering med olika fält etc.



## Förtydliganden/motivering

Finns säkert en hel del onödig kod i projektet som saknar syfte, likaså finns en del
kodupprepning som skulle kunna åtgärdas med t.ex partial views.
