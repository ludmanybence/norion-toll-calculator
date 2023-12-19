# Prod

`docker` och `make` behövs

```
make up_build
```

eller

```
make up
``` 

om `up_build` har redan körts tidigare


Navigera till 
``` 
http://localhost:4173 
```

# Dev

### Frontend
Navigera till ./frontend och installera dependecies

```
npm i 
```

och kör 


```
npm run dev
```

### Backend

Behöver .NET 8 SDK!

Navigera till ./backend och kör

Tests:

```
dotnet test
```

Server: 

```
dotnet run --project TollCalculatorBackend
```


<br> 


# Uppgift beskrivning
Målbilden är en applikation för att hantera biltullarna i Göteborg med tillhörande avgiftsberäkning för fordonen.

Det finns inga direkta syntaxfel utan det handlar mer om struktur och allmänna programmeringskunskaper som inte är specifika för något språk. Det finns utrymme för en mängd förbättringar – vi vill att du tänker igenom vilka förändringar och tillägg du vill göra för att få en kod som du ”kan stå för”.

# Tidsåtgång
Ingen deadline, men lämna ett resultat inom 7-10 dagar.  

# Inlämning
Lägg upp lösningen på din egen github så vi kan följa commit-historiken. 


