# FinalApiProject
This is a League of Legends API of champions and their abilities

Instructions

clone repository

create a mysql workbench connection

create a database/schema called leaguechampions

run the finalprojectscript in your connection to create your database tables

go to FinalProjectApi >> FinalProjectApi >> appsettings.json and edit username and password 
"Server=127.0.0.1;Port=3306;Database=leaguechampions;User=User;Password=Password"

Endpoints

  Get https://localhost:7144/api/champions/{ChampionId} //gets champions data
  
  Get https://localhost:7144/api/abilities/{ChampionId} //gets abilities data
  
  Post https://localhost:7144/api/champions //posts new champion

Sample Request

POST https://localhost:7144/api/champions

{
    "championName": "Akali",
    "championRole": "Assassin",
    "difficulty": 2,
    "ability": {
        "ability1": "Five Point Strike",
        "ability2": "Twilight Shroud",
        "ability3": "Shuriken Flip",
        "ult": "Perfect Execution",
        "innate": "Assassin's Mark"
    }
}

Sample Response

{
    "championId": 4,
    "championName": "Akali",
    "championRole": "Assassin",
    "difficulty": 2,
    "ability": {
        "abilityId": 4,
        "ability1": "Five Point Strike",
        "ability2": "Twilight Shroud",
        "ability3": "Shuriken Flip",
        "ult": "Perfect Execution",
        "innate": "Assassin's Mark"
    }
    
}

