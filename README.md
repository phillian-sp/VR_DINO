# VR DINO
![alt text](https://github.com/phillian-sp/VR_DINO/blob/main/VR_DINO_FRONT.jpg?raw=true)

Authors: [Cici Hou](mailto:xhou@stanford.edu), [Phillip Miao](mailto:pmiao@stanford.edu)

Feel free to reach out to us if you have any questions or feedback!

## Project Description
The rapid advancement in virtual reality (VR) technology has empowered developers to craft highly immersive experiences that captivate users' imaginations and deliver engaging, interactive content. In the "VR DINO" project we developed a VR parkour game, inspired by the popular Chrome "DINO" game. Players control a cute animated dinosaur to avoid crashing into its animal friends. Utilizing VR technology, this game seeks to enhance the player's experience through immersive interaction.

## Code Structure
This git repository contains the unity project for VR DINO. Here is the structure of this repository:
- `docs/`: Contains the paper for the project.
- `Packages/`: Contains the package information for the project.
- `ProjectSettings/`: Contains the settings for the project.
- `vrduino/`: Contains necessary files for VR tracking.
- `Assets/`: Contains all relevant assets for the game.
  - `Animation/`: Contains all the animations used in the game.
  - `Materials/`: Contains all the materials used in the game.
  - `Cardboard/`: Contains the code for the head tracking.
  - `Scripts/`: Contains all the scripts used in the game.
  - `Scenes/`: Contain a `TestScene` which is the main scene of the game.
  - `Sound/`: Contains all the sound effects used in the game.
  - `Self/`: Contains the main character of the game.
  - `Obstacles/`: Contains all the prefabs of the obstacles in the game.
  - `Environment/`: Contains the environment map of the game.
  - `Fonts/`: Contains the fonts used in the game.

## Note
The project is built using Unity 2022.3.30f1. Please make sure you have the correct version of Unity installed before running the project. Before running the project, please make sure to download the necessary Quixel megascans for the environment build from the following links:
- [Moss Texture](https://quixel.com/megascans/free?category=surface&category=moss)
- [Brick Texture](https://quixel.com/megascans/free?category=surface&category=brick&category=rough)
- [Street Curb Texture](https://quixel.com/megascans/free?category=3D%20asset&category=street)

## More Information
For more information about the specific design and implementation of the game, please refer to the paper in the `docs/` folder. The paper provides a detailed overview of the game, including the design process and implementation details.

## Acknowledgements
We would like to thank the EE 267 Professor Gordon Wetzstein and TAs Manu and Suyeon for their guidance and support throughout the development of this project.
