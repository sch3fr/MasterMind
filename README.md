# MasterMind
A simple game that was my first coding assignment. The topic of the assignment was chosen in a draw. I got a Mastemind game.
## Assignment requirements
The requirements were quite simple. The porgram was in command line, since at the time we didn't know how to make GUI yet. 
The program had to be able to run the main function, in my case the Mastermind game, and also export and load files. 
The export and load was tricky to come up with, since it does not really make sense in my case. I ended up coding some 
import and export functionality, but it is useless.
## What is Mastermind?
Masterming is a code-breaking board game for who players. Player one choses the pattern of four code pegs. 
There are 6 colors of the pegs. The other player has to guess the pattern, based on a feedback from player one.
The feedback comes in form of key pegs. There are two types of them, one signs that the player two guessed the color used 
in the pattern, but it is on wrong position, and the other one signs that the codebreaker guessed right both the color and position. 
Then the second player comes up with new guess until he either guesses the whole pattern, or he runs out of the space on game board.
## How does it work?
Since I had no idea how to make a color guessing game, I ended up making a number guessing version. The program generates a random
3 digits number and the user keeps guessing until they get it right. There is no limit here. <br>
It is possible and very easy to tweak the difficulty to make the random number 4 digits.
## What is new in v2
Compared to v1 I acutally submitted, v2 is coded entirely in English. It is also split into multiple classes files. If you would like to 
view the abomination that was the v1, you can in the /Backup/.