# FinalApiProject
This is a League of Legends API of champions and their abilities

Endpoints

  https://localhost:7144/api/champions{ChampionId}
  
  https://localhost:7144/api/abilities/{ChampionId}
  
  https://localhost:7144/api/champions

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

