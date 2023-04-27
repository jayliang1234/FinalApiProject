# FinalApiProject
This is a League of Legends API of champions and their abilities

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

