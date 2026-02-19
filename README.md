# Shinjuku Showdown - Console Fight Game

A simple turn-based console game inspired by anime battles.  
Fight between **Gojo** and **Sukuna** using hand-to-hand combat.  

<!-- Updated GIF -->
<p align="center">
  <img src="https://raw.githubusercontent.com/renziscool12/Shinjuku-Showdown/main/Image/go%20vs%20su.gif" alt="Gojo vs Sukuna" width="500" />
</p>

---

## Features
- Turn-based fight system
- Randomized damage for attacks
- Win / tie / lose outcomes with cutscenes
- Console input for player moves
- Simple health display

## Learnings / Notes
- Practiced **OOP concepts**: constructors, encapsulation, methods  
- Learned how to **handle console input** for turn-based games  
- Managed **win/tie logic** and cutscenes  
- Experimented with **randomized attack damage**

---

## Soon to add/Improvements
- Add multiple attack types  
- Show health bars visually  
- Add a “skip cutscene” feature  
- Expand game to multiple rounds or multiple fighters

## UPDATE 1.0
- Buffed both fighters’ health from **120 → 200**
- Added **Black Flash** for both fighters
- Implemented **Sukuna AI** to simulate smarter enemies
- Added **cutscene for hitting Black Flash** to make attacks feel epic

## UPDATE 1.1
- Introduced **RCT healing mechanics**:
  - Sukuna AI can now heal strategically
  - Gojo/Player can heal using RCT
- Added **MaxHealth** and ensured healing doesn’t exceed it
- General **bug fixes and balance tweaks**
- Nerfed **Hand-to-Hand Combat**: damage reduced from 15–30 → 9–19
- Nerfed **Black Flash**: damage reduced from 50 → 37

## UPDATE 1.2
- Added **Sukuna special move: Cleave**
  - Deals **15–23 damage**
  - Includes **HP clamping** to prevent negative health
  - Can be used strategically by **Sukuna AI**
- Minor **bug fixes and balance adjustments**

## UPDATE 1.3
- Added Sukuna ultimate finisher: **World Cutting Slash (WCS)**
  - Deals **65 damage**
  - Includes **dramatic cutscene** with suspenseful build-up
  - Limited usage with **`maxWcsUse`** to prevent spamming
- Sukuna AI improvements:
  - Automatically uses **Dismantle** when Gojo’s HP is low
  - Automatically triggers **WCS** if Gojo cannot use RCT
- Added **warning system** for both RCT and WCS to prevent repeated messages
- Health and damage clamping improved:
  - Prevents **Health exceeding MaxHealth**
  - Prevents **WCS usage going negative**
- Minor AI logic and balance tweaks for **fairer, more strategic fights**
  
  
  

