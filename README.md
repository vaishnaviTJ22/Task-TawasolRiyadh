# Endless Runner with Ghost Replay

A simple 3D endless runner made in Unity where you race against a ghost of your previous run.

## Features
- Auto-running player
- One-button jump
- Ghost replay of your last run (0.5s delay)
- Procedural platform generation
- Object pooling
- Score & health system
- URP neon glow visuals

## Controls
- **Space / Gamepad South Button** – Jump

## Gameplay
- Player runs automatically
- Collect items for **+10 score**
- Avoid obstacles (**-1 health**)
- When you die, your run becomes the ghost
- Restart and try to beat your previous run

## Requirements
- Unity **6000.0+**
- URP **17.0.4**
- Input System **1.14.2**

## Main Scripts
- `PlayerController` – Player movement & jump
- `GhostPlayerController` – Plays back previous run
- `SyncManager` – Records ghost data
- `PlatformSpawner` – Endless platform generation
- `SpeedController` – Increasing speed
- `GameManager` – Score, health, game flow

## Project Structure
```
Assets/
  Scenes/
  Scripts/
  Prefabs/
  Materials/
  Models/
  Shaders/
```

## How to Run
1. Open the project in Unity
2. Open **Start.unity**
3. Press Play

## Build
1. Add `Start.unity` + `Game.unity` to Build Settings
2. Choose platform
3. Build

