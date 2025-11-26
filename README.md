Endless Runner with Ghost Replay
A 3D endless runner game built in Unity where you race against a ghost replay of your previous run.

📋 Overview
Genre: Endless Runner
Platform: PC (Keyboard/Gamepad)
Engine: Unity 6000.0
Pipeline: Universal Render Pipeline (URP)

An endless runner where the player automatically runs forward through procedurally generated platforms, collecting items and avoiding obstacles while competing against a ghost replay of their previous run.

✨ Features
🏃 Auto-Running Gameplay - Continuously moving player with increasing difficulty
👻 Ghost Replay System - Race against your previous run with 0.5s delay
🎮 Simple Controls - One-button jump mechanic
🏗️ Procedural Generation - Infinite platform spawning system
♻️ Object Pooling - Optimized performance with object reuse
📊 Score & Health System - Track your progress and survivability
🎨 Custom Shaders - Neon glow effects with URP
🎮 How to Play
Controls
Space / Gamepad Button South - Jump
Objective
Survive as long as possible
Collect items to increase your score (+10 each)
Avoid obstacles to preserve health (-1 per hit)
Beat your ghost replay from the previous run
Gameplay Loop
Player runs forward automatically
Speed gradually increases over time
Jump to avoid obstacles and collect items
When you die, your run becomes the ghost
Restart and try to beat your previous performance
🛠️ Technical Details
Requirements
Unity Version: 6000.0 or higher
Render Pipeline: Universal Render Pipeline (URP) 17.0.4
Input System: New Input System 1.14.2
Key Dependencies
com.unity.render-pipelines.universal: 17.0.4
com.unity.inputsystem: 1.14.2
com.unity.ugui: 2.0.0
Project Structure
Assets/
├── Scenes/
│   ├── Start.unity          # Main menu scene
│   └── Game.unity           # Gameplay scene
├── Scripts/
│   ├── Manager/
│   │   ├── GameManager.cs
│   │   ├── SyncManager.cs
│   │   ├── SpeedController.cs
│   │   ├── UIManager.cs
│   │   ├── EventManager.cs
│   │   └── ObjectPooler.cs
│   ├── Player/
│   │   ├── PlayerController.cs
│   │   ├── GhostPlayerController.cs
│   │   └── PlayerState.cs
│   └── Environment/
│       ├── Platform/
│       ├── Obstacles/
│       └── Collectables/
├── Prefabs/
├── Materials/
├── Models/
└── Shaders/
🎯 Core Systems
Ghost Replay System
Records player position, rotation, and velocity every frame
Stores up to 300 states in a circular buffer
Interpolates between states for smooth playback
Automatically resets on scene reload
Platform Spawning
Spawns 5 initial platforms on game start
Triggers new platform spawn when player enters current platform
Despawns platforms 50 units behind the player
Uses object pooling for performance
Speed Controller
Initial speed: 5 units/second
Acceleration: 0.1 units/second²
Maximum speed: 15 units/second
Progressive difficulty scaling
⚙️ Configuration
GameManager Settings
Parameter	Default Value
Starting Health	3
Score Per Collectable	10
Speed Settings
Parameter	Default Value
Initial Speed	5.0
Acceleration	0.1
Max Speed	15.0
Ghost Replay Settings
Parameter	Default Value
Network Delay	0.5s
Buffer Size	300 states
Interpolation	Enabled
🚀 Getting Started
Installation
Clone or download this repository
Open the project in Unity 6000.0 or higher
Ensure URP is properly configured
Open Scenes/Start.unity
Press Play
Building
Go to File > Build Settings
Add scenes: Start.unity and Game.unity
Select your target platform
Click Build
🎨 Customization
Adding New Platforms
Create platform prefab with:
Platform script
Spawn point transform
Optional obstacles and collectables
Add to PlatformSpawner's platformPrefabs array
Adjusting Difficulty
Modify SpeedController settings for speed curve
Change obstacle density in platform prefabs
Adjust starting health in GameManager
Visual Effects
Edit NeonGlow.shader for custom glow effects
Modify dissolve effect duration in Obstacle script
Customize ghost transparency in GhostPlayerController
📝 Scripts Overview
Script	Purpose
GameManager	Core game logic, score, and health
SyncManager	Records and provides states for ghost replay
PlayerController	Player movement and jump mechanics
GhostPlayerController	Replays recorded player states
PlatformSpawner	Procedural platform generation
SpeedController	Global speed management
UIManager	UI updates and screen management
EventManager	Centralized event system
ObjectPooler	Object pooling for performance
📄 License
This project is available for educational and commercial use.

🤝 Credits
Built with Unity Engine and Universal Render Pipeline.

Enjoy the game and try to beat your ghost! 👻🏃‍♂️
