# ThunderKit Unity Project Setup Guide

ThunderKit is cool to work with when you have it set up properly - but unfortunately that's also the hardest part. Things are pretty terribly broken for some reason, with unobvious solutions. This project has been set up such that hopefully minimal headaches are encountered:

- Open the Unity Project. Throughout the setup, you will frequently get a popup complaining about the lack of a `Mono.Cecil.dll`. Each time this appears, close it and press on.

- Once the project had loaded, if the ThunderKit settings window isn't automatically opened, open it via `Tools -> ThunderKit -> Settings`. Press the bottom tab on the window titled `ThunderKit Settings`, and then at the top of the window, press the `Browse` button directly underneath the `Game Executable` input.

- Navigate to your RoR2 installation folder (for a Steam installation, this is typically `Steam\steamapps\common\Risk of Rain 2`), and select `Risk of Rain 2.exe`. Then press the `Import` button. A popup will open asking to restart the project to disable the Automatic Assembly Updater - do so.

- Once the project reopens, it should immediately begin importing everything. This will be evident if several command prompts pop up and close again. You will be met with another prompt to restart the project, which you should again confirm.

- When the project opens once again, things should hopefully all be in place.

## Misc. Notes

These notes concern some of the specific quirks that come with setting up ThunderKit in a Unity project (all of which are accounted for in this template).

- The `Unity.Burst.dll` and `Unity.Burst.Unsafe.dll` files imported by ThunderKit cause Play mode to crash, which is troublesome for testing things like animations or particle systems. Installing the latest version of Burst via the Package Manager before importing prevents ThunderKit from copying over the faulty versions. To resolve this issue in post, open the Unity project in file explorer, navigate to `Packages\Risk of Rain 2`, then find `Unity.Burst.dll`, `Unity.Burst.Unsafe.dll`, `Unity.Mathematics.dll`, and their corresponding `.meta` files. Delete all of them. Then, back in Unity, navigate to `Window -> Package Manager`. At the top left of the window, switch `Packages: In Project` to `Packages: Unity Registry`. Scroll down the packages until you find `Burst`, and install it.

- Some of the `RoR2.dll` scripts seem to be missing on import if the Risk of Thunder `multiplayer-hlapi` package is not installed before the import process. This can be fixed by going to your RoR2 installation, then navigating to `Risk of Rain 2_Data\Managed` and copying the file `RoR2.dll`. Then, open the Unity project in file explorer, and navigate to `Packages\Risk of Rain 2`. Paste the file in here to replace the broken version imported by ThunderKit.

- Make sure there are no loose scripts in the project before trying to set up/use ThunderKit. This will cause issues with the importing process, or if done after the importing process, cause an error with `Assembly-CSharp.dll` every time the project refreshes.
