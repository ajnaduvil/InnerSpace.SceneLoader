# Innerspace Scene Loader

### Objective 
To implement the scene-loader for the VR-Trainings.
### User Stories Covered
-   As a user, I want to see a loading screen, while the main-scene loads, so that I get an indicator that the program is not stuck.
-   As a user, I want to get one randomized hint/tip/quote about VR-Trainings in general (effectivity, etc.), while the main-scene loads so that I can learn something, while waiting. (be creative, with finding useful quotes)
-   As a user, I want to see some kind of progress while waiting, so that I can guess approximately how long it could take, until I can start the training.
-   As a user, I want to have a smooth transition between loading screen and the scene itself. (be creative, with the transition… but keep in mind you build it for VR-Users)
-   As a product owner, I want to change the hints/tips/quotes outside of unity, so that I don’t need to have coding-skills.
#### BONUS:
-   As a VR-User, I want to have a loading-screen, which follows the movement of the headset with a slight delay, as static HUDs are not very comfortable. Robo-Recall does this very good in this sample at minute 7:00 [https://youtu.be/Tjzcuz7PN5k?t=420](https://youtu.be/Tjzcuz7PN5k?t=420)

### Video

Here is a video of the project in action.

[![IMAGE ALT TEXT HERE](https://img.youtube.com/vi/FGkpgwpMenE/0.jpg)](https://www.youtube.com/watch?v=FGkpgwpMenE)

### Application User Experience

-   Connect the oculus rift to the laptop/PC
-   Launch the Scene Loader application by double clicking "Innerspace.SceneLoader.exe"
-   In the entry screen a welcome UI with a "Load" button appears
-   Click "Load" button using the trigger on the oculus controller
-   The scene fades to black and loading screen with random tool tip and progress bar and a loading icon appears
-   Once the scene loading finishes the cabin Interior appears.
-   Click thumb stick button to teleport around the interior

**Changing the tool tip configuration**

-   A `ToolTipConfig.json` with the default configuration data will be created at `Scene Loader v1.0.0\Innerspace Scene Loader_Data` after running the application for the first time.
-   You can edit the `ToolTipConfig.json` data or replace with new file
-   A sample tooltip configuration is provided with the build to demonstrate changing the tool tip data dynamaically

**Sample tool tip Configuration file format**
```json
{
"toolTips":[
{
"header":"Did you know?",  
"info":"The use of VR in education will dramatically increase over the next few years. While it is unlikely to replace traditional face-to-face teaching methods anytime soon."  
},  
{
"header":"Did you know?",  
"info":"The University of Barcelona uses VR as a tool in psychology and neuroscience. UCLA is training neurosurgeons using their “Surgical Theatre”"  
}]
}
```

### Dependencies

-   [VRTK](https://assetstore.unity.com/packages/tools/integration/vrtk-virtual-reality-toolkit-vr-toolkit-64131) : Used for setting up VR in the applicaiton. Made use of vrtk's features like UI interaction, teleport ..etc
-   [Oculus Integration](https://assetstore.unity.com/packages/tools/integration/oculus-integration-82022) : Used go integrated oculus sdk with VRTK
-   [Oculus AvtarSDK v1.26](https://developer.oculus.com/downloads/package/oculus-avatar-sdk/1.26.0/) : Used for VR body awareness. Virtual hands in the application is from Avtar SDK.
-   [AVR Utils](https://github.com/ajnaduvil/AVR.Utils) : This is a public repository I have created which contains some re-usable components for Unity development.
-   [C#](https://docs.microsoft.com/en-us/dotnet/csharp/) :  Used as the scripting language
-   [Unity3D](http://unity.com) : Used for application development. 
-   [Finished Cabin](https://assetstore.unity.com/packages/3d/environments/urban/furnished-cabin-71426) Unity Asset : Used as the main scene


### Known Issues
-  App needs an oculus device to be connected. Failure scenarios related to device availability are not handled.
-   In tooltip config file, the character limit validation and format validation is not implemented

### Implementation Details
>For further details about the technical implementation of the project see [Implementation Details](https://github.com/ajnaduvil/InnerSpace.SceneLoader/blob/master/Implementation%20Details.md) page.

### References

**[Executable Build](https://github.com/ajnaduvil/InnerSpace.SceneLoader/releases/tag/v1.0.0)** :

The build `Scene.Loader.v1.0.0.zip` file contains the following files

1. Executable Build : The folder `Scene Loader v1.0.0` contains the executable file. Double click `Innerspace Scene Loader.exe` to run the application
2. Sample `ToolTipConfig.json` file : This file can be used to replace the default tooltip data by adding it in `Scene Loader v1.0.0\Innerspace Scene Loader_Data` folder
3.  A preview video of the application in action




