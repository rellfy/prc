# Planar Rectilinear Controller (PRC)
![](https://cdn.discordapp.com/attachments/531317018536837155/730935625078800404/X7aQOwro6x.gif)

PRC is a simple yet complete DOTS Unity project which utilises the [DOTools](https://github.com/rellfy/dotools) library to create a decent Unity ECS project architecture.  
The game has a simple mechanic which is a plane composed of small vertical balls contrained to vertical motion only, hence the project name.

This project implements the following:
- Addressables
- "New" input system
- Unit tests with the Unity Test Framework
- Scriptable Objects to setup all gameplay parameters (called "Profiles")
- DOTS only, no MonoBehaviours

Once finished, the project will support multiplayer gameplay (using Unity NetCode) and be able to procedurally generate an infinite rectilinear plane with good peformance.
