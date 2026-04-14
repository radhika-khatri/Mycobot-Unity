# 🤖 Mycobot + Unity

This project integrates the **MyCobot robotic arm** with **Unity** to simulate and control the robot in a 3D environment. It bridges the physical robot and a virtual simulation so you can visualize the arm's movements in real time, test motion sequences safely before running them on hardware, and build interactive robotics demos.

---

## 🎥 Demo Videos

Click the thumbnails below to watch the project in action on YouTube:

[![Mycobot Unity Demo 1](https://img.youtube.com/vi/aK3czk6uDUw/0.jpg)](https://www.youtube.com/watch?v=aK3czk6uDUw)

[![Mycobot Unity Demo 2](https://img.youtube.com/vi/adNUaTfbi8k/0.jpg)](https://www.youtube.com/watch?v=adNUaTfbi8k)

---

## 🧠 What This Project Does

- Loads a 3D model of the MyCobot arm inside Unity
- Connects Unity to the robot (or simulates its behavior) so joint movements are reflected in the scene
- Lets you control or animate the arm through Unity's interface
- Serves as a foundation for pick-and-place tasks, path planning visualization, and robotic simulation demos

---

## 🛠️ Tech Stack

- **Unity** (3D game engine used as a robotics simulator)
- **MyCobot 280** (6-axis collaborative robotic arm by Elephant Robotics)
- **Python** (for robot control scripts communicating with the arm)
- **ROS / ROS-Sharp** (optional, for real-time ROS-Unity communication)

---

## ⚙️ Requirements

- Unity (2020.3 LTS or later recommended)
- Python 3.x
- `pymycobot` library for controlling the physical arm:
  ```bash
  pip install pymycobot
  ```
- MyCobot 280 connected via USB (for physical hardware control)
- ROS Noetic (if using the ROS-Unity integration path)

---

## 🚀 Getting Started

### 1. Clone the repo

```bash
git clone https://github.com/radhika-khatri/Mycobot-Unity.git
```

### 2. Open in Unity

- Launch Unity Hub
- Click **Add project from disk** and select the cloned folder
- Open the project and let Unity import all assets

### 3. Run the simulation

- Open the main scene from the `Assets/Scenes/` folder
- Press **Play** in Unity to start the simulation
- The robot arm model will be visible and ready to animate or control

---

## 📁 Repo Structure

```
Mycobot-Unity/
├── Assets/               # Unity assets, scenes, scripts, and robot model
├── Packages/             # Unity package dependencies
├── ProjectSettings/      # Unity project configuration
└── *.py                  # Python scripts for robot communication
```

---

## 💡 Use Cases

- **Safe prototyping**: Test motion sequences in simulation before running on real hardware
- **Education**: Learn robotics and Unity integration without needing a physical robot
- **Demos**: Build interactive 3D demos showcasing robotic arm capabilities
- **Research**: Use as a base for more advanced pick-and-place or manipulation tasks

---

## ⚠️ Things to Keep in Mind

- Make sure the COM port in the Python script matches your machine's USB port for the MyCobot.
- Running the Unity simulation doesn't require a physical robot. You can use it in simulation-only mode.
- Unity's coordinate system may need adjustments depending on the URDF model orientation.

---

## 👤 Author

**Radhika Khatri**  
[GitHub Profile](https://github.com/radhika-khatri)
