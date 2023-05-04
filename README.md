# FinalApiProject
## This is a League of Legends API of champions and their abilities.

### Changes Made
The primary key "AbilityId" is now INT instead of STRING.

### Instructions
1. Clone repository.
2. Create a MySQL Workbench connection.
3. Create a database/schema called "leaguechampions".
4. Run the "finalprojectscript" in your connection to create your database tables.
5. Go to FinalProjectApi >> FinalProjectApi >> appsettings.json and edit "username" and "password" so that it matches your connection.

Example: "Server=127.0.0.1;Port=3306;Database=leaguechampions;User=User;Password=Password"

### Endpoints
- Get api/champions/{ChampionId} - Gets champion's data.
- Get api/abilities/{AbilityId} - Gets abilities data.
- Put api/champions/{ChampionId} - Changes data for specified champion.
- Put api/abilities/{AbilityId} - Changes data for abilities.
- Post api/champions - Posts new champion.
### Sample Request
POST https://localhost:7144/api/champions
```
{
    "championName": "Bard",
    "championRole": "Support/Mage",
    "difficulty": 3,
    "ability": {
        "ability1": "Cosmic Binding",
        "ability2": "Caretaker's Shrine",
        "ability3": "Magical Journey",
        "ult": "Tempered Fate",
        "innate": "Traveler's Call"
    }
}
```
### Sample Response
```
{
    "statusCode": 200,
    "statusDescription": "Successfully added champion",
    "champion": {
        "championId": 11,
        "championName": "Bard",
        "championRole": "Support/Mage",
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
```
