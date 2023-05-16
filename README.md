# Carrom Game Making Procedure

1. Created a new alignment to set the game in portrait mode.

2. Added all the given sprites as game objects and aligned them as it would be in a carrom board.

3.Added rigidbodies to the striker and coins as well as circle colliders.

4.Created bouncy physics 2D material to allow the striker to bounce of the walls.

5.Added box collisions to the border of the board.

6.Added circle colliders that are triggers at the holes of the board.

7.Added a slider and configured it so that when the slider is moved the striker also moves on the board.

8.Added the arrow as a game object with sprite renderer to show the direction in which the striker should move.

9.On click got the mouse position and pointed the arrow in the right direction by running an atan function and then using Quaternion.Euler() method.

10.Clamped the distance between the mouse position and the striker to scale the arrow on the striker only to a certain extent.

11.Added force to the striker using the rigidbody component in the direction the arrow was facing by getting mouse position, striker transform and then reversing the direction in which force is added.

12.Added a coin collector script to all holes and tags to all coins to see which color coins had entered the hole and hence distributed points accordingly.

13.Created a gameflow object that managed switching of turns between player and opponent.

14.Tried to implement enemy hitting his coins in the hole(Could not figure this out).

15.Added a timer that counts down and displays game over when ended.
 
 
