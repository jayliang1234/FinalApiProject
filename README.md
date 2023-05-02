# FinalApiProject
This is a League of Legends API of champions and their abilities

Little change I made

the primary key "AbilityId" is INT instead of STRING

Instructions

clone repository

create a mysql workbench connection

create a database/schema called leaguechampions

run the finalprojectscript in your connection to create your database tables

go to FinalProjectApi >> FinalProjectApi >> appsettings.json and edit username and password so that it matches your connection

"Server=127.0.0.1;Port=3306;Database=leaguechampions;User=User;Password=Password"

Endpoints

  Get api/champions/{ChampionId} //gets champions data
      api/abilities/{AbilityId} //gets abilities data
      
  Put api/champions/{ChampionId} //Changes Data for Specified champion
      api/abilities/{AbilibtyId} //Changes Data for abilities
  
  Post api/champions //posts new champion

Sample Request

POST https://localhost:7144/api/champions
{
    "championName": "Bard",
    "championRole": "Suppport/Mage",
    "difficulty": 3,
    "ability": {
        "ability1": "Cosmic Binding",
        "ability2": "Caretaker's Shrine",
        "ability3": "Magical Journey",
        "ult": "Tempered Fate",
        "innate": "Traveler's Call"
    }
}

Sample Response

{
    "statusCode": 200,
    "statusDescription": "Successfully added champion",
    "champion": {
        "championId": 11,
        "championName": "Bard",
        "championRole": "Suppport/Mage",
        "difficulty": 3,
        "ability": {
            "abilityId": 11,
            "ability1": "Cosmic Binding",
            "ability2": "Caretaker's Shrine",
            "ability3": "Magical Journey",
            "ult": "Tempered Fate",
            "innate": "Traveler's Call"
        }
    }
}

