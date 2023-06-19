# Procedural-Animation
My own implementation of a procedural walk animation.


![](https://github.com/BrianAnakPintar/Procedural-Animation/blob/master/procedural-anim.gif)

# About the project
The goal of the project is to demonstrate the ability of the animation to dynamically interact with the environment, showcasing the powerful features of Unity's IK (Inverse Kinematics) system. By leveraging IK, the animation achieves realistic and responsive movements, allowing the robot to interact physically with its surroundings.

# How it works
1. By using the Unity Animation Rigging package, we use IK (Inverse Kinematics) to control the legs.
2. In order to procedurally animate the movement, we cast use raycast to cast a point which points to the ideal location of the legs.
3. Then we track of the distance of this point with our actual leg.
4. Whenever our leg gets farther than our alloted max distance, then we move the leg onto the raycasted point along with a movement vector from the player to anticipate additional movement
5. We also would like to move only 1 leg at a time, we solve this by using a queue datatype.
6. In order to add "motion" we move the leg's y-axis by using a sine function.
7. One's everything is done your cute robot is ready to crawl!

![](https://github.com/BrianAnakPintar/Procedural-Animation/blob/master/walking.gif)

Assets used on the project:
- Toon shader from https://roystan.net/articles/toon-shader/
- Cute robot from https://assetstore.unity.com/packages/3d/characters/robots/robot-sphere-136226
