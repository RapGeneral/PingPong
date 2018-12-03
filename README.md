## PingPong Game Project

----

### Made by 

- Alexander Angelov - RapGeneral
- Dimitar Jelezov - Dimityr32

### Project Purpose

##### Our purpose is to create a fully functional, online if possible, ping pong game recreation from the past century.

### Documentation

##### When the game is started, the main menu will be displayed. 
##### From there, the user can choose via the arrows and enter 

- <b>Start</b>

    A menu to choose the difficulty and the type of game will open.

    For now only one type of game is avaliable: Classic. To play, move with the up/down arrows. To win, you must score 7 points against the computer.

    But be careful! If he scores 7 agains you, you will looose.
- <b>Shop</b>

    With every win you will get coins. You can spend them in the shop. From here, you can buy colors for the lines, or the ball.

- <b>Exit</b>

    Exits the game and saves current progress.
    
### Refactoring

---

##### Before the refactoring we had some problems:
- We used load functions to inject dependencies
- We had a switch to filter some commands
- We used reflection to get the commands
- We had menu factory which was given to all commands and distributed the menus
- We had a parent command class which held unnessesery information
- We used Console class everywhere
- We had around 5-6 different almost empty menu classes to help with dependency problems
- We used static class to set parameters and to give them to the games
- We used a static constant class that held all the constants
- We used File class imbedded in classes

##### The patterns we used are:
- Composite - because menus contained different choices
- Abstract Factory - to create commands
- IoC - to solve dependency problems
- Singleton (not singleton but the IoC version) - engine, commands, menus dont need to be multiinstance.
- Adapter - To adapt the file and console to the project.
- Template - Menus all share common behavior.


### Repository [repo]

[repo]: https://gitlab.com/RapGeneral/PingPong