# BattleShipGame-Flare

Please download the code as Zip, and unzip and double click the **BattleShip-Flare.sln** file to open the solution into Visual studio. 

I tried to make the code as simple as possible and self explanatory, added very few comments in the code - so that I dont confuse the readers. 

It has got two Projects -  **Console** and **Service layer**. 
Console contains the Program.cs - The Main Function. 

Code has been written for:
 Create 2 players
 Create and place BattleShips on the Board randomly - Show boards (very basic) on the Console for each player.
 Each player can play his/her turn unless one of them Wins.
 It shows each HIT and MISS on each turn and also shows if a SHIP is sunk.
 In the end it shows if a player is Lost when all his/her ships are sunk.
 
I made sure the following:
  Code is easily **extendible**, it easy to add new ships, new players etc.
  Used full abstraction of Player and GamePlay classes, its dependencies can easily be injected and test cases can be wriiten with less efforts.
  very Easy to **maintain and Read.**
![image](https://user-images.githubusercontent.com/32189221/141745582-b68e6cb9-8dc7-4be6-ba1e-409f85d2fede.png)
