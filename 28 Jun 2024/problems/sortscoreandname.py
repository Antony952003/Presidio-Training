playerswithscore  = {
    "homelander": 120,
    "starlight": 50,
    "butcher": 85,
    "atrain": 100,
    "black noir": 90,
    "queen maeve": 95,
    "stormfront": 110,
    "kimiko": 80,
    "frenchie": 70,
    "hugie": 60,
    "deep": 75,
    "ashley": 65,
    "stan edgar": 105,
    "victoria neuman": 115,
    "lamplighter": 55
}

highscores = sorted(playerswithscore.items(), key=lambda x: x[1], reverse=True)
topscorers = []
for i in highscores:
    if(len(topscorers) < 10):
        topscorers.append(i)
    else:
        break
print(topscorers)