# Procedural Animation

This is my own version of a procedurally animated walking sequence based on popular ones found online.

The goal of this project is to create a procedurally animated walking robot as shown on the gif on the side. This is achieved by utilizing IK (Inverse Kinematics) that’s based on Unity’s Rigging Animation system. 

![procedural-anim.gif](https://github.com/BrianAnakPintar/Procedural-Animation/blob/master/gifs/procedural-anim.gif)

---

# How it works

1. IK constraints are utilized to connect the joints on the robot’s legs together. This allows us to control each legs by moving the target position.
    
    ![Ik-constraints.gif](https://github.com/BrianAnakPintar/Procedural-Animation/blob/master/gifs/Ik-constraints.gif)
    
2. Afterwards, Raycast is utilized which creates a ray from an object and point it downwards so that it hits the ground. This raycast will act as the intended point for our leg.
    
    ```csharp
    Ray ray = new Ray(caster.transform.position, Vector3.down);
    ```
    
3. Then, the distance between the Raycast and the current leg will be tracked.
4. Whenever the distance exceeds our allotted max distance we will add that leg onto a Queue which contains in order which legs we want to move.
5. Based on the order of the queue, the leg will then be moved onto the raycasted point as well as adding the player’s movement vector in order to anticipate the player’s direction.
6. In order to achieve a smooth and “realistic’ movement, the legs will have it’s y-axis increased based on a sine function.
7. Now we should have a crawling robot
    
    ![walking.gif](https://github.com/BrianAnakPintar/Procedural-Animation/blob/master/gifs/walking.gif)
    

---

Assets used on the project:
- Toon shader from https://roystan.net/articles/toon-shader/
- Cute robot from https://assetstore.unity.com/packages/3d/characters/robots/robot-sphere-136226
