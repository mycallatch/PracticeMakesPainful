10/8/22

Today I connected GitLab with the Unity Engine, which I will be using to make my game.

11/10/22

Basic placeholder for the floor and player made. Also created and adjusted forces applied due to user input. There was an issue where the user could hold down the jump key, allowing them to be in the air forever, in order to prevent this I added an extra box collider at the bottom of the player object to detect whether they were in contact with a surface or not; then I created if statements to check whether the player was in contact with the ground or not to dictate if they should be able to jump again or not.

16/10/22

Adjusted movement speed and jump height of the player. As well as started creating the dash feature for the game.

19/10/2

Finished off the dash function of my game. Ran into an issue that it would only dash in one direction, so I added a feature that flips the character to whatever direction the player walks, allowing for control over the dash direction.

21/10/22

Created a Attack class. Ran into an issue that I did not have anything to test it on, in order to solve this I made a second character and coded it so that it ran a debug log on impact.

27/10/22

Created a health system using the Impact class and worked on the knockback feature, had an issue that it was knocking back the wrong player, must fix.

03/11/22

Began making a fist draft of interim project report. Abstract and Introduction completed, as well as list of Objectives.

09/11/22

Created a Kick function with different knockback power and damage. However ran into an issue where the kick will hit the player twice at once, must fix later.

10/11/22 - 15/11/22

Began work on the Background section of my interim report. And created a basic health bar

17/11/22

Fixed bugs in knockback by assigning the variable for knockback to the enemy player at the start of the game, and solved the multiple kick issue by breaking the loop.

20/11/22

Working on the Build part of my report.

21/11/22

Implemented health bar into the impact health and created second health bar.

23/11/22

Created a timer and fixed bug that allowed the timer to count down into the negatives by checking if the timer was at 0 or below, then stopping it there.

14/01/23

Implemented initial version of win counter.

21/01/23

Expanding on my report's background section.

28/01/23

Created the "opponent" branch, where I will be working on creating the controls for my secondary character. 

While swapping the initial player's movement controls from checking "GetAxisRaw" to "GetKeyDown" I ran into an issue where, if the player pressed a key, the action would continue forever. To resolve this I used else if statements to check if the key was released, if so the value of horizontal and vertical movement was returned to 0.

29/01/23

Created a movement class for the second player and began the second player's attack class by creating a method of punching. 

I had an issue where the player would invert at the opposite time they were supposed to, to solve this I altered Update to call Invert() in the opposite moments to player one. This however caused the dash function to be inverted also, to fix this I multiplied the value of the dashSpeed variable by -1.


5/02/23 - 16/02/23

Learning "Aseprite", a tool for creating and animating sprites.

18/02/23

Created sprite sheet for player's idle stance. Had an issue where it automatically sliced the sprites wrongly, which mad the player seem as though he was jumping in place instead of side-to-side. Fixed this error by manually adjusting slices.

23/02/23

Worked on project report. Created an intro for Milestones section, gives explaination of how it is testing. Created a Sprites sub-section for my build section and looked into design patterns Unity uses as part of the software.

25/02/23 - 27/02/23

Began implementing sprites into my game and continued report writing.

28/02/23
Implemented animation for walking, which activates through detecting horizontal movement and then playing the animation.

Ran into an issue where the sprites were positioned funnily, used a feature in unity to choose the centre of the sprite, when the slice was a different size to the other slices in the spritesheet.

Another issue where punch animation would not play when called, must fix.

02/03/23

Created a way of resetting my game. 

Ran into an issue where it would reset the entire game, including the counts that I needed for counting round wins and game wins. Instead I will use this to reset the game for a new play session.

Created a new reset method, which returns all players to their right place and filled each player's health bars to solve this.

Ran into an issue where the winning player's win count will reset but not the losing player.

04/03/23

Created a full reset function called NewGame(), which when called resets everything. Called when a player wins twice.

Also created sprite sheets for jumping and dashing.

11/03/23

Created a game over screen to be displayed after a set is finished. Allowing the players to see the number of wins and health bar over the game over screen. Thus showing the winner.

Ran into an issue where the game would reset immediately, making it impossible to properly see the game over screen.

To solve this, I used the Invoke method, which allowed for a delay on the call to NewGame().

12/03/23

Realised a bug through User Acceptance Testing. Winning player's health will not reset upon beating their enemy. Must fix.

Began refactoring code to remove code smells.

14/03/23

Created a player win screen, which displays when the correct player wins twice in a set.

18/03/23

Created and implemented secondary character's sprite animations.

Also fixed bug where only 1 player's health would be reset upon a KO by refilling the winner's health after beating their opponent in the game manager.
