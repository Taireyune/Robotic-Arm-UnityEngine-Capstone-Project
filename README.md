# Robotic-Arm-UnityEngine-Keystone-Project
<img 
src="https://github.com/Taireyune/Robotic-Arm-UnityEngine-Keystone-Project/blob/master/images/push_object.gif" 
width="434" height="259" alt="push object">
Robotic Arm - If I have a robotic arm - is my Keystone project from the Coursera Unity specialization. This was built for applications in machine learning and is not intended for entertainment purposes (though pushing things around in-game is oddly addictive sometimes).

## Requirements
- Windows 10
- Unity Hub 2.4.0

## Getting Started
Add this folder to the Unity Hub Projects. Open the project using Unity version 2019.3.9f1. 

## Features
- Robotic arm assembled using hinge joints with collidors
- Simple objects for movement manupulation
- Target area for the objects to move to
- When object move within target bounds, object is destroyed and 'target-reached' signal is broadcasted
- csv file with settings for arm angle limits, number of objects to spawn etc
- Boilerplate menu system (to satisfy Keystone requirements)

## Additional info
Note this version of the simulation uses Unity Physics Engine; a more customizable Physics simulation framework is available. Stay tuned for the simulation in Ubuntu 18.04 with more adjustable parameters, and connectors to use ROS and ZMQ commmunications.