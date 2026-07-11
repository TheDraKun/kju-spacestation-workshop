# Space Station Escape

_A Beginner-Friendly Unity Game Development Workshop Project_

---

# Overview

**Space Station Escape** is a Unity project designed specifically for a one-day Game Development workshop.

Rather than teaching Unity features in isolation, students build one complete, playable game from start to finish. Every gameplay mechanic introduces a Unity or C# concept while contributing to the final experience.

By the end of the workshop, students will understand how individual gameplay systems work together to create a complete game and leave with a finished project they can continue building on.

---

# Story

A systems failure has forced the space station into emergency lockdown, leaving only the underground evacuation system as a means of escape. Restore the station's critical systems, bring the emergency network back online, and escape before it's too late.

---

# Gameplay Loop

```
Explore
    ↓
Collect Objective Items
    ↓
Carry Item
    ↓
Deposit Item
    ↓
Activate Console
    ↓
Restore Station Systems
    ↓
Escape
```

---

# Features

## Player

- Third Person Character Controller
- Camera Follow
- Item Carry System

---

## Gameplay Systems

- Collectible Objective Items
- Carry & Drop System
- Deposit Stations
- Room Activation Consoles
- Progress Doors
- Room Progression
- Emergency Escape Console
- Emergency Escape Pod
- Complete Win Sequence

---

# Rooms

## Reactor Room

Restore the station's power systems.

Gameplay

- Collect **Energy Cores**
- Deposit Energy Cores
- Activate Reactor Console

---

## Medbay

Restore the station's medical systems.

Gameplay

- Collect **Med Packs**
- Deposit Med Packs
- Activate Medbay Console

---

## Control Room

Unlocks after both the Reactor Room and Medbay have been restored.

Gameplay

- Collect **Data Chips**
- Deposit Data Chips
- Activate Control Console

---

## Emergency Escape

After restoring every critical system:

Gameplay

- Activate the Emergency Escape Console
- Call the Emergency Escape Pod
- Board the Emergency Escape Pod
- Complete the Mission

---

# User Interface

Mission Tracker

- Reactor Room Progress
- Medbay Progress
- Control Room Progress
- Escape Objective

Status Indicators

- Active (Yellow)
- Completed (Green)

Popup Notifications

Examples

- Reactor Restored
- Medbay Restored
- Control Room Restored
- Escape Initiated

Victory Screen

- Mission Complete
- Restart Option

---

# Audio

Gameplay feedback through simple sound effects.

Current Audio

- Item Pickup
- Item Deposit
- Console Activation
- Escape Pod Arrival
- Mission Complete

---

# Architecture

                            Player
                               │
                               ▼
                      Gameplay Systems
    (Objective Items • Carry • Deposit Stations • Activation Consoles)
                               │
                               ▼
                      Primary Room Managers
                    (Reactor & Medbay Rooms)
                               │
                        Room Completion
                               ▼
                          Game Manager
                 ┌─────────────┼─────────────┐
                 ▼             ▼             ▼
           UI Manager   Final Room Manager  Escape Console
                        (Control Room)          │
                               │                │
                      Room Completion           │
                               └────────┬───────┘
                                        ▼
                                  Escape Pod
                                        │
                                        ▼
                               Mission Complete

```

The **GameManager** acts as the central coordinator and manages:

- Room Progression
- Game Progression
- UI Updates
- Final Escape Sequence
- Victory Flow

Gameplay systems communicate with the GameManager through a simple Singleton pattern, keeping the project easy to understand and teach.

---

# Core Scripts

## Player

- PlayerMovement
- PlayerCarry

## Gameplay

- ObjectiveItem
- DepositStation
- ActivationConsole
- ProgressDoor

## Managers

- RoomManager
- GameManager
- UIManager

## Ending

- EscapeConsole
- EscapePod

---

# Workshop Progression

## Mission 1 — Welcome Aboard

Learn the Unity Editor and build the player controller.

Concepts

- Unity Editor
- Scene Navigation
- GameObjects & Components
- Character Controller
- Camera Follow
- Player Input

---

## Mission 2 — Restore the Reactor

Build the first complete gameplay loop.

Concepts

- Trigger Colliders
- Object Interaction
- Carry System
- Deposit Station
- Activation Console
- Door Progression

---

## Mission 3 — Restore the Medbay

Build a second room using the gameplay systems from Mission 2.

Concepts

- Prefabs
- Reusability
- Inspector Configuration
- Gameplay Expansion

---

## Mission 4 — Restore the Control Room

Introduce game progression and system management.

Concepts

- Room Unlocking
- GameManager
- UI Updates
- Game Progression

---

## Mission 5 — Escape the Station

Complete the game.

Concepts

- Escape Console
- Escape Pod
- Win Condition
- Audio Feedback

---

# Learning Outcomes

By the end of the workshop students will have learned:

- Unity Editor Fundamentals
- GameObjects & Components
- C# Scripting
- Physics & Trigger Collisions
- Object Interaction
- State Management
- UI Programming
- Audio Integration
- Basic Game Architecture

They will also leave with a fully playable Unity game that they can continue expanding on their own.

---

# Design Philosophy

The project prioritizes:

- Learning by Building
- Readable Code
- Small Focused Scripts
- Reusable Gameplay Systems
- Visible Player Progression
- Beginner-Friendly Architecture

The goal is to teach **Game Development**, not just Unity features.

---

# Current Status

## Version

**v1.0 – Workshop Build**

## Status

- Gameplay Complete
- UI Complete
- Audio Complete
- Win Sequence Complete
- QA Tested
- General Audience Tested

The project is feature complete and ready for workshop preparation.

---

# Workshop Resources (Planned)

- Starter Project
- Checkpoint Packages
- Instructor Teaching Notes
- Workshop Slides
- Student Challenges
- Resource Pack

---

## License

This project was created as an educational resource for the **Unity Game Development Workshop** and is intended for learning purposes.
```
