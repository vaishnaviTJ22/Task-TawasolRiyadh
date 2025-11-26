# Endless Runner with Ghost

A simple 3D endless runner made in Unity where the ghost replicate yout movement.

## Features
- Auto-running player
- One-click jump
- Ghost replay of your last run
- Procedural platform generation
- Object pooling
- Score & health system
- URP neon glow visuals

## Controls
- **Mouse Left click / Touch Screen(Single click)** – Jump

## Gameplay
- Player runs automatically
- Collect items for **+10 score**
- Avoid obstacles (**-1 health**)
- When you die, the game end
- Restart or Back home screen

## Requirements
- Unity **6000.0+**
- URP **17.0.4**
- Input System **1.14.2**

## Main Scripts
- `PlayerController` – Jump
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

