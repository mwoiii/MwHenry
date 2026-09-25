# ThunderKit Unity Project Setup Guide

ThunderKit is cool to work with when you have it set up properly - but unfortunately that's also the hardest part. Things be pretty terribly broken for some reason, with unobvious solutions. Here's a scuffed but hopefully working setup for this project:

- Open the ThunderKit settings tab via `Tools -> ThunderKit -> Settings`. Press the bottom tab in the window titled `ThunderKit Settings`, and then at the top of the window, press the `Browse` button directly underneath the `Game Executable` input. Navigate to your RoR2 installation folder (for a Steam installation, this is typically `Steam\steamapps\common\Risk of Rain 2`), and select `Risk of Rain 2.exe`. Then press the `Import` button. A popup will open asking to restart the project to disable the Automatic Assembly Updater - do so.

- Once the project reopens, it should immediately begin importing everything. This will be evident if several command prompts pop up and close again. You will be met with another prompt to restart the project, which you should again confirm.

- When the project opens once again, things are mostly in place. However, if you check the HenryBody prefab for example, you will see that lots of the component scripts are still missing for some reason (maybe the import process is fundamentally broken, maybe something is wrong with this project setup - who knows (not me)). This can be fixed by once again going to your RoR2 installation, then navigating to `Risk of Rain 2_Data\Managed` and copying the file `RoR2.dll`. Then, open the Unity project in file explorer, and navigate to `Packages\Risk of Rain 2`. Paste the file in here to replace the broken version imported by ThunderKit. Upon tabbing back into the Unity project, you should see that this resolves the missing components.

- Finally, you'll notice that entering Play mode in Unity completely crashes the project. This is troublesome for testing things like animations or particle systems. To resolve this, go back to the folder where you just pasted `RoR2.dll`, and find the files `Unity.Burst.dll`, `Unity.Burst.Unsafe.dll`, and their corresponding `.meta` files. Delete all of them. Then, back in Unity, navigate to `Window -> Package Manager`. At the top left of the window, switch `Packages: In Project` to `Packages: Unity Registry`. Scroll down the packages until you find `Burst`, and install it. Following this, the project should hopefully be fully up and running.


## Misc. Notes

Make sure there are no loose scripts in the project before trying to set up/use ThunderKit. This will cause issues with the importing process, or if done after the importing process, cause an error with `Assembly-CSharp.dll` every time the project refreshes.
