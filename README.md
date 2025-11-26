Endless Runner with Ghost Replay – Game Document
📋 Overview

Genre: Endless Runner
Platform: PC (Keyboard / Gamepad)
Engine: Unity 6000.0+
Render Pipeline: Universal Render Pipeline (URP)

A 3D endless-runner game where the player races forward automatically through procedurally generated platforms, collects items, avoids obstacles, and competes against a ghost replay of their previous run.

✨ Features

🏃 Auto-Running Gameplay
Continuous forward movement with gradually increasing difficulty.

👻 Ghost Replay System
Replays your previous run with a 0.5s delay so you can race against yourself.

🎮 Simple Controls
One-button jump mechanic.

🏗️ Procedural Generation
Infinite platform spawning using a dynamic platform generator.

♻️ Object Pooling
Optimized performance by reusing platforms, obstacles, and collectables.

📊 Score & Health System
Collect items for points and avoid obstacles to survive.

🎨 Custom URP Shaders
Neon glow and stylized visuals.

🎮 How to Play
Controls

Space / Gamepad South Button – Jump

Objective

Survive as long as possible

Collect items (+10 score)

Avoid obstacles (−1 health)

Beat the ghost replay of your last attempt

Gameplay Loop

Player automatically runs forward

Speed gradually increases

Jump to avoid obstacles and collect items

When you die:

Your run is stored as the ghost replay

You restart and try to beat your previous ghost

🛠️ Technical Details
Requirements

Unity 6000.0 or higher

URP 17.0.4

New Input System 1.14.2

Packages Used

com.unity.render-pipelines.universal – 17.0.4

com.unity.inputsystem – 1.14.2

com.unity.ugui – 2.0.0
