# AVRRadialMenu

![Unity](https://img.shields.io/badge/Unity-100000?style=for-the-badge&logo=unity&logoColor=white)
![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)

*This document serves as a technical documentation of the project.*

## 1. Project Description
This project was developed as part of a Master's program on Augumented and Virtual Reality in Computer Science. 
We developed a reusable approach with which different types of radial menus can be quickly and easily integrated into 3D applications. The structure of the application was chosen in such a way that a high degree of reusability is guaranteed.

Functions and methods can be bound to the cubes, which makes it possible to control various aspects of an application using only the menu.

//Bild einfaches 2D-Radial Menu 

### 1.1 Background 
Radial menus are a well-known and simple way of providing users of an application with a menu. Since 3D applications often offer various options to customize or control the application, it makes sense to make them accessible in such a way that a user can access them quickly and as intuitively as possible. This gave rise to the motivation to develop a radial menu for 3D applications. Care is taken to ensure that the resulting menu can be integrated as universally as possible into different applications, i.e. that various options are available for positioning or operating the menu. 

The project is based on the concept of the Command and Control Cube (CCC), a cube consisting of several levels whose individual levels are shown or hidden depending on the position of the controller. For details of how the CCC works, please refer to the book [VR Kompakt]() by Professor Manfred Brill. In his book, he explains the concept and implementation of the CCC, which we will build on here. For this reason, we also refer to the corresponding repository for the book for a basic understanding of the project. In diesem kann der [Code des CCC](https://github.com/MBrill/VRKompakt/tree/main/Unity/VR/VRKVIU/SystemControl/CommandControlCube) eingesehen werden. 

//Link zum Buch VR-Kompakt einfügen 
//Bild CCC als Basis einfügen 

### 1.2 Implementation Approach
Überarbeitung des CCC, dieser dient als Basis, vereinfachen der Prefabs, ergänzen neuer Logik, Lösen von reiner Verwendung mit Collidern, 

We have decided to base our application on the implementation of the CCC by Manfred Brill. This meant that the required prefabs and logics were already available, which saved a lot of work. At the same time, it enables a better understanding and better reusability. 

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
Assets				   # Main contents of the project 
│ 
├── CCC
│	│
│	├──Prefabs		   # Prefabs used for the Menu design 	
│	│
│   ├── Scripts    	   # Scripts used to control the  behaviour of the menu 
│   │	 └──Base       # Base logic to initialize components 
│   │    │
│	│	 ...
│   │
│	...
│
├── Resources		   # Log4Net Config-Files 
│	└──...
│ 
├── Scenes			   # Szenes to Showcase different Menu Use Cases 
│	└──...
│
├── Scripts 
│	 └──Callbacks      # Logic Scripts bound to Menu cubes  
│	 └──Logging        # Scripts used to log debug information  
│	 └──...
│	 │
│    ...
│	
...
```

### 2.1 Prefabs, components and scenes 

Prefabs are used in this project to determine the appearance of individual components. Prefabs are reusable building blocks that can in turn be used in other prefabs. The prefab of the radial menu is again made up of prefabs. To change the appearance of the cubes, the corresponding prefab must therefore be adapted. If the appearance of the menu is to be changed, its prefab, which contains the prefab of a single cube, must be adapted. All these files are located in the prefabs folder. 

The Scripts folder contains all scripts that control the functionality of the Radial Menu. Please note that there are two scripts folders that are on different levels. The scripts that control the behavior of the menu are located in the Scripts folder within the CCC folder. The Scripts folder in the Assets folder contains the scripts that are called when a menu cube is selected. These can be exchanged for scripts with their own logic to change the actions that are executed when a cube is selected and thus customize the menu to your own needs. However, the scripts in the scripts folder within the CCC folder should not be changed. As already mentioned, they contain the necessary logic for using the radial menu. However, the various possible uses do not always require all scripts, so depending on the desired use, some scripts can be omitted.  

The Resources folder contains the config files for Log4net, the logging framework used in the scripts. These are necessary if the menu is to be operated with Log4net outputs in the scripts, otherwise they can be omitted. In this case, however, the logging outputs must be removed from the scripts, which is not recommended at this point. 

The Scenes folder contains all the scenes that were created during the project. These are basic scenes with different functionality of the radial menu. In all cases, the same functions are called up by selecting a cube, only the way in which the menu is displayed or the selection of a cube differs from scene to scene. You can therefore choose from different variants for use in your own projects. The following section goes into more detail about these variants and what is required to integrate them into your own project. 


### 3 Configuration and Setup 

### 4 Use cases and needed files 

### 5 ToDos and possible improvements 

--> Generation of different sized Menus 
--> improved Inheritance structure for scripts 
--> Textures for Cubes 
--> Text on all 4 Cube sides 


