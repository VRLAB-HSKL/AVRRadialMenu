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
Assets
│ 
├── CCC
│	│
│	├──Prefabs					  # Prefabs used for the Menu design 	
│	│
│   ├── Scripts    				  # Scripts used to control the  behaviour of the menu 
│   │	 └──Base          		  # Base logic to initialize components 
│   │    │
│	│	 ...
│   │
│	...
│
├── Resources					  # Log4Net Config-Files 
│	└──...
│ 
├── Scenes						 # Szenes to Showcase different Menu Use Cases 
│	└──...
│
├── Scripts 
│	 └──Callbacks        	  # Logic Scripts bound to Menu cubes  
│	 └──Logging          	  # Scripts used to log debug information  
│	 └──...
│	 │
│    ...
│	
...
```

### 2.1 Prefabs, components and scenes 

### 3 Configuration and Setup 

### 4 Use cases and needed files 

