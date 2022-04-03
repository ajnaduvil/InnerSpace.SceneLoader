
# Implementaiton Details

### Scene Hierarchy
![alt text](https://github.com/ajnaduvil/InnerSpace.SceneLoader/blob/master/Documentation/Implementation%20Details/project%20hierarchy.PNG?raw=true)

### Project file structure
![alt text](https://github.com/ajnaduvil/InnerSpace.SceneLoader/blob/master/Documentation/Implementation%20Details/project%20file%20structure.PNG?raw=true)
### Project Flow
 1.  Application enters `AppLoadedState` when the application is launched.
 2.  The [SceneLoadingHandler.cs](https://github.com/ajnaduvil/InnerSpace.SceneLoader/blob/master/SceneLoader.Unity/Assets/App/Scripts/SceneLoadingHandler.cs) is responsible for handling the  "Init" to "MainScene" transition logic
#### HUD
![HUD.png](https://github.com/ajnaduvil/InnerSpace.SceneLoader/blob/feature/documentation/Documentation/Implementation%20Details/HUD.png?raw=true)
1.  HUD.prefab contains a LoadingCursorHUD.prefab, Progressbar and a TooltipDisplay. The prefab is added to HUD layer and only seen by the HUDCamera. The `SmoothFollow` script is attached to the prefab to make it smoothly follow the user's head movement.
2.  HUD Camera: Cameara that only renders the HUD layer. This helps seeing the HUD even in the faded scene.

###  Modules
These are modules in the project which is developed in  a re-usable way. Test scenes for each modules are also included in their respective folders.
> Unit tests for each modules can be found under `Tests` folder in their respective folders
#### Tooltip
Takes care of displaying tool tip , creating and loading the tool tip info from the config file
-  Use [TooltipDisplay.prefab](https://github.com/ajnaduvil/InnerSpace.SceneLoader/blob/master/SceneLoader.Unity/Assets/App/Modules/ToolTip/Prefabs/TooltipDisplay.prefab "TooltipDisplay.prefab")  to display tool tip
- Tooltip data can be filled by creating a ScriptableObject in the editor by using **"Create->Innerspace->TooltipData"**. This can be referenced to [`ToolTipDisplayHandler`](https://github.com/ajnaduvil/InnerSpace.SceneLoader/blob/master/SceneLoader.Unity/Assets/App/Modules/ToolTip/Scripts/ToolTipDisplayHandler.cs "ToolTipDisplayHandler.cs") 
-   [`TooltipDatacontainer.cs`](https://github.com/ajnaduvil/InnerSpace.SceneLoader/blob/master/SceneLoader.Unity/Assets/App/Modules/ToolTip/Scripts/ToolTipDataContainer.cs)' takes care of creating the scritptable object in the editor and also serializing/de-serializing the `ToolTipConfig.json`  file 

#### Loading HUD
Contains a circular curosor with a spinning animation.

 - [`LoadingCursorHUD.prefab`](https://github.com/ajnaduvil/InnerSpace.SceneLoader/blob/master/SceneLoader.Unity/Assets/App/Modules/LoadingHUD/Prefabs/LoadingCursorHUD.prefab "LoadingCursorHUD.prefab") Spinning circular cursor with color customization options
 
#### Progressbar
- [`Progressbar.cs`](https://github.com/ajnaduvil/InnerSpace.SceneLoader/blob/master/SceneLoader.Unity/Assets/App/Modules/Progressbar/Scripts/Progressbar.cs "Progressbar.cs") contains the logic to set progress also an event which UI can subscribe when the property changed

#### SceneFader

1.  Use [`SceneFader.prefab`](https://github.com/ajnaduvil/InnerSpace.SceneLoader/blob/master/SceneLoader.Unity/Assets/App/Modules/SceneLoader/Prefabs/SceneFader.prefab "SceneFader.prefab") to handle scene fading . Scene fader automatically makes itself as the child of the referenced camera and handles the fading
2.  [`SceneFader.cs`](https://github.com/ajnaduvil/InnerSpace.SceneLoader/blob/master/SceneLoader.Unity/Assets/App/Modules/SceneLoader/Scripts/SceneFader.cs "SceneFader.cs") contains methods to handle scene fade-in and fade-out

#### SmoothFollow
The [`SmoothFollow.cs`](https://github.com/ajnaduvil/InnerSpace.SceneLoader/blob/master/SceneLoader.Unity/Assets/App/Modules/SmoothFollow/SmoothFollow.cs "SmoothFollow.cs")is used to follow an object smoothly maintaining a minimum distance.
