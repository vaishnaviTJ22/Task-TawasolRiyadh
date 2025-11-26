What is This Game?
An endless runner where you automatically run forward, jump over obstacles, collect items for points, and race against a "ghost" replay of your previous run.

How to Play
Controls
Jump: Press Space (or gamepad button)
Goal
Survive as long as possible
Collect items (+10 points each)
Avoid obstacles (-1 health each)
Start with 3 health, game over at 0
Gameplay
Player runs forward automatically (speed increases over time)
Jump to avoid obstacles and collect items
Ghost shows your previous run with a 0.5 second delay
When you die, your current run becomes the new ghost
Restart and try to beat your ghost!
Game Features
Speed System
Starts at 5 units/sec
Gradually increases to max 15 units/sec
Gets harder as you play longer
Ghost Replay
Shows your last run as a transparent player
Appears 0.5 seconds behind your current position
Lets you compete against yourself
Automatically resets when you restart
Platforms
Spawn infinitely ahead of you
Despawn when 50 units behind you
Randomly selected from prefab pool
Contain obstacles and collectables
Collectables
Rotating items you can pick up
Give +10 score each
Disappear when collected
Obstacles
Hurt you for 1 damage when touched
Dissolve and disappear after hit
Optional visual dissolve effect
UI Elements
During Game:

Score (top of screen)
Health (top of screen)
Game Over:

Final score display
Restart button → replay the game
Main Menu button → return to start screen
Technical Setup
Key Scripts
PlayerController - Player movement and jump
GhostPlayerController - Replays previous run
GameManager - Tracks score and health
SyncManager - Records player states for ghost
PlatformSpawner - Generates platforms
UIManager - Updates UI displays
Scene Structure
Player_Parent/Player          # Main player character
GhostPlayer_Parent/GhostPlayer # Ghost replay
Canvas                         # UI elements
PlatformSpawner               # Spawns platforms
GameManager                   # Game logic
SyncManager                   # Ghost system
Quick Settings
GameManager

Starting Health: 3
Points per Collectable: 10
Speed

Start: 5 → Max: 15
Acceleration: 0.1/sec
Ghost

Delay: 0.5 seconds
Buffer: 300 states
Platforms

Initial Count: 5
Despawn Distance: 50 units
That's it! Simple endless runner with ghost replay functionality.
