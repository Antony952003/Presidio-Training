random_word = 'candy'

while True:
    cows = 0
    bulls = 0
    print('Its a 5 letter word u have to guess!!!')
    guess = input("Enter your guess : ").lower()

    for i in range(len(guess)):
        if(random_word.find(guess[i]) != -1 and random_word[i] == guess[i]):
            cows += 1
        elif(random_word.find(guess[i]) != -1):
            bulls += 1
    if(cows == len(random_word)):
        print(f"you have won the word is {guess}")
        break
    else:
        print(f"Cows : {cows}")
        print(f"Bulls : {bulls}")