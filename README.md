# AVRRadialMenu

![Unity](https://img.shields.io/badge/Unity-100000?style=for-the-badge&logo=unity&logoColor=white)
![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)

*This document serves as a technical documentation of the project.*

## 1. Project Description
This project was developed as part of a Master's program on Augumented and Virtual Reality in Computer Science. 
We developed a reusable approach with which different types of radial menus can be quickly and easily integrated into 3D applications. The structure of the application was chosen in such a way that a high degree of reusability is guaranteed.

Functions and methods can be bound to the cubes, which makes it possible to control various aspects of an application using only the menu.

### 1.1 Background 
Radial menus are a well-known and simple way of providing users of an application with a menu. Since 3D applications often offer various options to customize or control the application, it makes sense to make them accessible in such a way that a user can access them quickly and as intuitively as possible. This gave rise to the motivation to develop a radial menu for 3D applications. Care is taken to ensure that the resulting menu can be integrated as universally as possible into different applications, i.e. that various options are available for positioning or operating the menu. 

The project is based on the concept of the Command and Control Cube (CCC), a cube consisting of several levels whose individual levels are shown or hidden depending on the position of the controller. For details of how the CCC works, please refer to the book [VR Kompakt](https://link.springer.com/book/10.1007/978-3-658-41245-6) by Professor Manfred Brill. In his book, he explains the concept and implementation of the CCC, which we will build on here. For this reason, we also refer to the corresponding repository for the book for a basic understanding of the project. The [Code of the CCC](https://github.com/MBrill/VRKompakt/tree/main/Unity/VR/VRKVIU/SystemControl/CommandControlCube) can be viewed here.

<div align="center" width="100%"><img src="Documents/RadialMenu.gif" /></div>

### 1.2 Implementation Approach

We have decided to base our application on the implementation of the CCC by Manfred Brill. This meant that the required prefabs and logics were already available, which saved a lot of work. At the same time, it enables a better understanding and better reusability.

<div align="center" width="100%"><img src="Documents/CCC.png" /></div>

In order to achieve the goals of our project, the first step was to adapt the existing logic and prefabs in the CCC to our use case:

* Reduction of the CCC to a single level
* Reduce the prefab of a layer to 4 cubes 
* Reduce prefab of a single cube
* Remove unnecessary logic

A concept was then developed for how the menus should be operated and how and where they should be positioned. A concept was then developed for how the menus should be operated and how and where they should be positioned. We came up with the following options:

* Positioning in the scene
* Position of the menu follows the controller 
* Position of the menu in front of the camera following the direction of view 
###
* Orientation according to the position of the controller 
* Orientation according to the direction of view of the user/camera
###
* Operation by moving the controller/collider 
* Operation via touch or trackpad 

In order to implement this, it was necessary to introduce new logic at several points in the project, which is why the project structure is described below.

## 2. Project Structure
The project is structured as follows:
```bash
AVRRadialMenu
│ 
Assets				# Main contents of the project
│
├── CCC
│	│
│	├──Prefabs		# Prefabs used for the Menu design
│	│
│	├── Scripts		# Scripts used to control the  behaviour of the menu
│	│	└──Base		# Base logic to initialize components
│	│	│
│	│	...
│	│
│	...
│
├── Resources			# Log4Net Config-Files 
│	└──...
│ 
├── Scenes			# Szenes to Showcase different Menu Use Cases 
│	└──...
│
├── Scripts 
│	└──Callbacks		# Logic Scripts bound to Menu cubes  
│	└──Logging		# Scripts used to log debug information  
│	└──...
│	│
│   ...
│	
...
```

### 2.1 Prefabs, components and scenes 

Prefabs are used in this project to determine the appearance of individual components. Prefabs are reusable building blocks that can in turn be used in other prefabs. The prefab of the radial menu is again made up of prefabs. To change the appearance of the cubes, the corresponding prefab must therefore be adapted. If the appearance of the menu is to be changed, its prefab, which contains the prefab of a single cube, must be adapted. All these files are located in the prefabs folder. 

<div align="center" width="100%"><img src="Documents/RadialMenuPrefab.png" /></div>

The Scripts folder contains all scripts that control the functionality of the Radial Menu. Please note that there are two scripts folders that are on different levels. The scripts that control the behavior of the menu are located in the Scripts folder within the CCC folder. The Scripts folder in the Assets folder contains the scripts that are called when a menu cube is selected. These can be exchanged for scripts with their own logic to change the actions that are executed when a cube is selected and thus customize the menu to your own needs. However, the scripts in the scripts folder within the CCC folder should not be changed. As already mentioned, they contain the necessary logic for using the radial menu. However, the various possible uses do not always require all scripts, so depending on the desired use, some scripts can be omitted.  

The Resources folder contains the config files for Log4net, the logging framework used in the scripts. These are necessary if the menu is to be operated with Log4net outputs in the scripts, otherwise they can be omitted. In this case, however, the logging outputs must be removed from the scripts, which is not recommended at this point. 

The Scenes folder contains all the scenes that were created during the project. These are basic scenes with different functionality of the radial menu. In all cases, the same functions are called up by selecting a cube, only the way in which the menu is displayed or the selection of a cube differs from scene to scene. You can therefore choose from different variants for use in your own projects. The following section goes into more detail about these variants and what is required to integrate them into your own project. 

## 3 Configuration and Setup 

In order to use the application, the ViveInputUtility (VIU) must be integrated by Vive. This can be downloaded from the [Vive repository](https://github.com/ViveSoftware/ViveInputUtility-Unity/releases) on GitHub. The downloaded source zip file must be unpacked and the content pasted into the HTC.UnityPlugin folder. Then you must specify in the project settings whether the application should be executed via an HMD or in the simulator. Once this step has been completed, the next step is to prepare the application for your own use case. This is done similarly for all options and is explained here with screenshots for the example of control using a trackpad. 

Here, the script that implements the logic for the trackpad must be assigned to the CCCController object. With its help, there are then several selection options that can be used to adapt the menu to your own use case. 

<div align="center" width="100%"><img src="Documents/MenuOptionsSetup.png"/></div>

As can be seen in the screenshot, the CCC object must be assigned to the script. You can then select whether the operation should be carried out with the left or right hand and which button should be used to show or hide the menu. In addition, a button can be defined with which a cube marked with a highlight can be selected and thus the associated action can be triggered. In the case of operation using a trackpad, a Select button can also be selected, which can then be used to highlight cubes. The Show checkbox indicates whether the menu is shown or hidden. If it is selected, the menu is displayed at the start of the application. 

The text shown on the cubes in the screenshot can also be customized individually for each cube when used in your own applications. To do this, the text element assigned to a cube must be edited, for which the layer1 assigned to the CCC object must be expanded. This contains all 4 cubes that belong to the menu, which in turn each have a canvas assigned to them on which the text can be displayed. The text is displayed using TextMeshPro and the text can simply be entered in the editor. The only disadvantage of this option is that all layers that are to be edited must always be expanded, which means that changing a text takes longer than if the texts were assigned using a script and could be done directly with the operating hand, for example. 

<div align="center" width="100%"><img src="Documents/TextCubesSetup.png"/></div>

The assignment of an action to be executed when a cube is selected can also not be done via a script, but must be done directly via the respective object of the cube to which the action is to be assigned. To do this, the CCC object must be expanded again and layer1 and the respective cube object must be selected. Here too, the assignment is always made individually and via the editor. It is important to know that when assigning several scripts to a cube, both are always called when the cube is selected, i.e. it is not possible to make a selection here. The assignment is also shown again in the following screenshot.  

<div align="center" width="100%"><img src="Documents/ActionCubeSetup.png"/></div>

Depending on the structure of the application, the action script must also be assigned to the object on which the action is to be executed (if it is to affect an object). In the case of all the examples provided, this is the chapter in the base scene, to which the script is also assigned once again. For the sake of completeness, this assignment is also shown again in the following screenshot and thus explained. 

<div align="center" width="100%"><img src="Documents/ActionToObjectSetup.png"/></div>

## 4 Use cases and needed files 

As described above, the menu application can be used in different variants, although not all scripts are required for all variants. For this reason, an overview of the most common variants and which scripts are required to operate them is provided below. 

| Use cases               | Needed Scripts                                                                                       |
|-------------------------|------------------------------------------------------------------------------------------------|
| Menu bound to camera    | CCC, CCCubeEventManager, LayerEventManager, ViuCCCCamera, RadialMenuBasis, RadialMenu          |
| Menu bound to controller| CCC, CCCubeEventManager, LayerEventManager, RadialMenuTrackpadBasis, RadialMenu, ViuCCCTrackpad|
| Menu positioned in room | CCC, CCCubeEventManager, LayerEventManager, RadialMenuBasis, RadialMenu


## 5 ToDos and possible improvements 

For future changes to this project, there are several possible improvements to which particular attention should be paid. 

For example, an implementation that makes it possible to generate menus with dynamic sizes without having to change the respective prefab by hand is pending. The logic for the input via trackpad must also be adapted for this, as the number of segments must be adapted to the number of cubes. However, this revision should be done quickly. In the worst case, a separate prefab must be created for a certain number of menu items and then a drop-down menu must be used to select how many cubes should be used to create a menu. 

It would also make sense to further improve the inheritance structure and thus prepare for the introduction of new features. It may also be possible to further simplify the code and make it clearer. This will also make it easier to introduce new features in the future. 

When labeling the cubes, it would make sense to only have to specify them once and then display them on all 4 sides of a cube instead of just one as is currently the case. This could improve usability in 3D applications in which the menu is placed in the room. As the user can move freely around the menu here, it would only make sense if a label is also given on all sides. The difficulty here is probably to set the text only once per cube, otherwise the susceptibility to errors increases greatly and the usability becomes worse. 

In addition to the texts, it would be useful to be able to assign a texture or an image to cubes that is displayed on all 4 sides. In this way, more complicated actions could be represented whose description in text form would be difficult to realize or would require too many words. Care must be taken here to ensure that images of different sizes are still displayed sharply and are not completely pixelated. 


