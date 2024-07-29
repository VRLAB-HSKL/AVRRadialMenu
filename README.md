# AVRRadialMenu

![Unity](https://img.shields.io/badge/Unity-100000?style=for-the-badge&logo=unity&logoColor=white)
![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)

*This document serves as a technical documentation of the project.*

## 1. Project Description
This project was developed as part of the "Augmented and Virtual Reality" course in the Master's program in Computer Science at the University of Applied Sciences Kaiserslautern.
We developed a versatile approach that enables the quick and easy integration of various types of radial menus into 3D applications in Unity. The application's structure was deliberately designed to ensure a high level of reusability.

Functions and methods can be assigned to the cubes, allowing control over various aspects of an application solely through the menu.

### 1.1 Background 
Radial menus are a well-known and straightforward way of providing users with a menu in an application. Since 3D applications often offer various options to customize or control the application, it is logical to make these options easily and intuitively accessible to users. This motivated the development of a radial menu for 3D applications. The goal was to ensure the resulting menu could be universally integrated into different applications, offering various options for positioning and operation.

The project is based on the concept of the Command and Control Cube (CCC), a cube consisting of several layers whose individual layers are shown or hidden depending on the position of the controller. For details on how the CCC works, please refer to the book [VR Kompakt](https://link.springer.com/book/10.1007/978-3-658-41245-6) by Professor Manfred Brill. In his book, he explains the concept and implementation of the CCC, which we build on here. For a basic understanding of the project, please refer to the corresponding repository for the book. The [Code of the CCC](https://github.com/MBrill/VRKompakt/tree/main/Unity/VR/VRKVIU/SystemControl/CommandControlCube) can be viewed here.

<div align="center" width="100%"><img src="Documents/RadialMenu.gif" /></div>

### 1.2 Implementation Approach

We decided to base our application on Manfred Brill's implementation of the CCC. This provided the necessary prefabs and logic, significantly reducing the workload and enhancing understanding and reusability.

<div align="center" width="100%"><img src="Documents/CCC.png" /></div>

To achieve our project goals, we first adapted the existing logic and prefabs in the CCC to fit our use case:

* Simplified the CCC to a single layer
* Reduced the layer's prefab to four cubes 
* Reduced prefab of a single cube
* Removed unnecessary logic

Next, we developed a concept for how the menus should be operated and positioned, resulting in the following options:

* Positioning in the scene
* Menu position follows the controller
* Menu position in front of the camera, aligned with the direction of view
###
* Orientation based on the controller's position
* Orientation aligned with the user's/camera's direction of view
###
* Operation by moving the controller/collider 
* Operation via touch or trackpad 

To implement these features, we introduced new logic at several points in the project, which is why the project structure is described below.

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
│	...
│	
...
```

### 2.1 Prefabs, components and scenes 

Prefabs are used in this project to determine the appearance of individual components. They are reusable building blocks that can be incorporated into other prefabs. The radial menu's prefab is composed of other prefabs. To change the appearance of the cubes, the corresponding prefab must be modified. If the menu's appearance needs to be changed, its prefab, which includes the prefab of a single cube, must be adjusted. All these files are located in the prefabs folder.

<div align="center" width="100%"><img src="Documents/RadialMenuPrefab.png" /></div>

The Scripts folder contains all scripts that control the functionality of the Radial Menu. Note that there are two scripts folders at different levels. The scripts controlling the menu's behavior are in the Scripts folder within the CCC folder. The Scripts folder in the Assets folder contains scripts called when a menu cube is selected. These can be replaced with custom scripts to modify the actions executed when a cube is selected, allowing menu customization. However, the scripts within the CCC folder's Scripts folder should not be altered as they contain the essential logic for using the radial menu. Depending on the desired use, not all scripts may be needed, and some can be omitted.

The Resources folder contains the config files for Log4net, the logging framework used in the scripts. These are necessary if the menu is to be operated with Log4net outputs in the scripts; otherwise, they can be omitted. However, the logging outputs must be removed from the scripts if Log4net is not used, which is not recommended.

The Scenes folder contains all the scenes created during the project. These are basic scenes showcasing different functionalities of the radial menu. In all cases, the same functions are called by selecting a cube; only the display method or cube selection varies between scenes. You can choose different variants for use in your own projects. The following section provides more details on these variants and how to integrate them into your project.

## 3. Configuration and Setup 
To use the application, you must integrate the ViveInputUtility (VIU) by Vive. This can be downloaded from the [Vive repository](https://github.com/ViveSoftware/ViveInputUtility-Unity/releases) on GitHub. After downloading, import the package into your Unity project. In the preferences, you can specify whether the application should run via an HMD or in the simulator. Once this is set up, the next step is to prepare the application for your specific use case. The process is similar for all options and is demonstrated here with screenshots using the example of trackpad control.

Here, the script that implements the logic for the trackpad must be assigned to the CCCController object. With its help, there are then several selection options that can be used to adapt the menu to your own use case. 

<div align="center" width="100%"><img src="Documents/MenuOptionsSetup.png"/></div>

As shown in the screenshot, the CCC object must be assigned to the script. You can then choose whether the operation should be performed with the left or right hand and select the button to show or hide the menu. Additionally, you can define a button to select a highlighted cube, triggering its associated action. For trackpad operation, a Select button can be chosen to highlight cubes. The Show checkbox indicates whether the menu is displayed or hidden; if selected, the menu will be shown at the start of the application.

The text displayed on the cubes can also be customized individually for each cube in your application. To do this, edit the text element assigned to a cube by expanding layer1 assigned to the CCC object. This layer contains all four cubes that belong to the menu, each with an assigned canvas for text display. The text is shown using TextMeshPro and can be easily entered in the editor. The drawback of this method is that all layers to be edited must be expanded, making text changes more time-consuming compared to assigning texts via a script and modifying them directly with the operating hand.

<div align="center" width="100%"><img src="Documents/TextCubesSetup.png"/></div>

The assignment of an action to be executed when a cube is selected can also not be done via a script, but must be done directly via the respective object of the cube to which the action is to be assigned. To do this, the CCC object must be expanded again and layer1 and the respective cube object must be selected. Here too, the assignment is always made individually and via the editor. It is important to know that when assigning several scripts to a cube, both are always called when the cube is selected, i.e. it is not possible to make a selection here. The assignment is also shown again in the following screenshot.  

<div align="center" width="100%"><img src="Documents/ActionCubeSetup.png"/></div>

Depending on the structure of the application, the action script must also be assigned to the object on which the action is to be executed (if it is to affect an object). In the case of all the examples provided, this is the chapter in the base scene, to which the script is also assigned once again. For the sake of completeness, this assignment is also shown again in the following screenshot and thus explained. 

<div align="center" width="100%"><img src="Documents/ActionToObjectSetup.png"/></div>

## 4. Use cases and needed files 

As mentioned earlier, the menu application can be utilized in various configurations, and not all scripts are necessary for every variant. Therefore, an overview of the most common variants and the scripts required for each is provided below.

| Use cases               | Needed Scripts                                                                                       |
|-------------------------|------------------------------------------------------------------------------------------------|
| Menu bound to camera    | CCC, CCCubeEventManager, LayerEventManager, ViuCCCCamera, RadialMenuBasis, RadialMenu          |
| Menu bound to controller| CCC, CCCubeEventManager, LayerEventManager, RadialMenuTrackpadBasis, RadialMenu, ViuCCCTrackpad|
| Menu positioned in room | CCC, CCCubeEventManager, LayerEventManager, RadialMenuBasis, RadialMenu


## 5. Future enhancements and potential improvements
Several improvements are worth considering for future updates to this project:

One major enhancement would be to implement dynamic menu sizing, allowing menus to adjust their size automatically without manual changes to the prefab. This would involve updating the trackpad input logic to accommodate a variable number of segments. As a temporary solution, creating separate prefabs for different menu sizes and using a dropdown menu to select the number of cubes could be considered.

Another area for improvement is refining the inheritance structure to better support the addition of new features. Simplifying and clarifying the code will also make future updates and feature integrations more manageable.

Improving the cube labeling system would also be beneficial. Currently, labels are specified for only one side of each cube. Modifying the system to apply labels to all four sides with a single specification would enhance usability, particularly in 3D environments where users can move around the menu. This change would help reduce errors and improve the overall user experience.

Additionally, integrating the ability to assign textures or images to the cubes—displayed on all sides—would allow for more complex visual representations of actions that might be difficult to convey with text alone. It’s important to ensure that these images are clear and not pixelated, regardless of their size.
