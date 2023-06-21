# AR-tower-defence-game
A prototype for an AR tabletop tower defence game. Contains the Unity/Vuforia project.

# Repo Structure
This repository is structured into subfolders as follows:
* _TowerDefenceAR_: contains the Unity/Vuforia project
* _build_: contains an Android build (APK) of the game
* _gimp-images_: contains gimp image files used to create the image targets
* _image-targets_: contains the image target printout document (PDF), including all the image targets needed to play the game

# Build and Deploy
To build and deploy the project **Unity version 2022.3.0f1** is required.

The Android SDK has to be installed in order to build the project for Android. Download and install Android Studio. Use SDK Manager to install the **SDK for Android 6.0 (Marshmellow, API Level 23)**.

Build the project for Android using the pre-defined build settings. The output is the APK file. Transfer the APK file to an Android mobile device, e.g. via USP cable.

Alternatively, use the pre-built APK file from the _build_ subfolder.

# Install
On the Android device, open the APK file and install the game.

**Note:** Android will probably prompt a warning that the APK file is not safe. The only uses the device camera for tracking. It does not, to my knowledge, record or send any data anywhere. So, if you trust me you can ignore the warning. :)

# Image Targets
Before playing, prepare the image targets:
* Download the image target printout PDF from the _image-targets_ subfolder.
* Print the PDF.
* Cut out the image targets along the dotted lines (except for the "Table" target, which does not have to be cut out).

# How To Play
Here's how to play the game.

## Preparation
* Place the "Table" image target on a large table or the floor. It should be placed visibly, more or less in the center of the playing area (e.g. the table).
* Start the app.

## Playing
To "build" a building, ...
* take the corresponding builder card
* make sure it's visible and being tracked (will have a yellow highlight around the border)
* and place it on the playing surface.

The building will be built after the builder card is visible and tracked continuously for 5 seconds.

The buildings have to be built in order:
1. Build the _Tower_
2. Build the _Enemy Spawn Point_
3. Build _Defence Turret_ 1-4 and/or _Obstacle_ 1-4, in respective order.

* After the the Enemy Spawn Point is built, it spawns tanks which will attack the Tower as well as Defence Turrets.
* Defence Turrets, in turn, will attack tanks in range.
* Tanks have to avoid, i.e. drive around, Obstacles (or any building).

The game is lost once the Tower is destroyed.