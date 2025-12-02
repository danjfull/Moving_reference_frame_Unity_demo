# Moving Reference Frame in Unity 6.2 Demonstration Software

This project functions as a demonstration of the benefit of using kinematic physics principles (forces) to move a character/vehicle around in 3-Dimensional space. This is in opposition to controlling the character/vehicle motion by explicitly setting the 3D position of the character/vehicle. Using physics allows the character to move around normally on a moving/accelerating platform (such as while inside a large moving vehicle), and their transition between the vehicle and non-moving surface also follows realistic behavior.

This project has a moving reference frame that is a large car. The user is encouraged to move the character around inside or on top of the vehicle while it is moving and also transition between the vehicle and the surface to see these physics principles demonstrated.

The character can jump and move around in 3-Dimensional Space, under the influence of gravity.

## Instructions for Build and Use

Steps to build and/or run the software:

1. Download Unity 6.2 Game Engine (via Unity Hub)
2. Download Blender 5.0.
3. Download this entire project folder
4. Open it using Unity Hub GUI
5. Ensure all automatic processes complete.
6. Press the top-center play button. Wait for the software to build.

Instructions for using the software:

1. The game starts with the pause menu open. This menu can be closed by pressing 'M' key or the 'esc' key. It can be reopened at any time using the same controls. Using the cursor, the user can adjust (by dragging the slider) the character's angle change sensitivity at any point during the game using this menu. When the menu is open, the game is paused. Some physics simulation aspects may continue to operate during this time.
2. Use cursor and WASD arrow keys to look and move around, respectively. Press and hold SPACEBAR to apply an impulse that will push the character up into the air by about a meter before gravity pulls them back down. This game uses an input system that may also work with a controller, but such has not been tested extensively.
3. A moving vehicle is included, which starts accelerating as soon as the game starts. The character can jump inside it's open back area and move up to the top floor of the vehicle while it is still moving. The character will move relative to the vehicle as if the vehicle's internal floors were stationary.

## Development Environment 

To recreate the development environment, you need the following software and/or libraries with the specified versions:

* Unity 6.2 Game Engine (installed via [Unity Hub](https://unity.com/download). Currently Unity 6.2 is automatically installed when Unity Hub is first launched). Note that paid licensing may be required if your organization makes more than $200k in profits per year.
* [Blender 5.0](https://www.blender.org/download/). This is a free to use software for 3D modeling. Behind the scenes, Unity has blender convert its .blend files into FBX files that Unity then can read into its system.
* [.NET 8.0](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) (this is for using and compiling C# code in Unity).
* [Microsoft Visual Studio](https://visualstudio.microsoft.com/downloads/), with the package Game Development with Unity.

## Useful Websites to Learn More

I found these websites useful in developing this software:

* [Unity Input System in Unity 6 YouTube Playlist](https://youtu.be/Cd2Erk_bsRY?list=PLX2vGYjWbI0RpLvO3B7aH-ObfcOifMD20)
* [Unity Project-Wide Actions Input System](https://docs.unity3d.com/Packages/com.unity.inputsystem@1.8/manual/ProjectWideActions.html)

## Future Work

The following items I plan to fix, improve, and/or add to this project in the future:

* [ ] Add in driving controls for the large vehicle
* [ ] Add in shock systems for large vehicle
* [ ] Add in a better UI overlay
* [ ] Add in a settings menu for remapping controls
* [ ] Redo terrain map to contain the character and vehicle inside the map boundaries

