# Endless Runner Game 3D: Ultimate Challenge

A high-intensity, feature-rich **3D Endless Runner** that pushes the boundaries of the genre. Featuring five unique layers of difficulty, dynamic boss encounters, and environmental hazards, this game is designed to be a true test of skill and survival.

---

## 🎮 The Five Pillars of Difficulty

This game goes beyond simple speed increases. It features five distinct difficulty systems that keep the player engaged and constantly adapting:

1. **The Four Brothers Challenge:** Four distinct difficulty modes (Easy, Medium, Hard, and Insane) that scale global speed and spawn frequency.
2. **The Stoppers (The Wall):** Specially coded obstacles and barriers that require precise timing and specific movement patterns to bypass.
3. **The Boss Blockades:** Unique Boss-type entities that periodically appear to block the road, forcing the player to find narrow escape routes or specific openings.
4. **Aerial Threats (Death from Above):** High-tier difficulty where objects fall dynamically from the sky, requiring the player to look ahead and predict impact zones.
5. **Ground Crawlers:** Low-profile hazards that crawl along the road, forcing the player to jump or switch lanes instantly to avoid a collision.

---

## 🚀 Key Features

* **Advanced Obstacle Logic:** A mix of static "Stoppers," moving "Crawlers," and falling "Aerials."
* **Procedural Generation:** Endless road segments with randomized obstacle patterns to ensure no two runs are identical.
* **High Score Persistence:** Integrated saving system that tracks your personal best and encourages replayability.
* **Dynamic Audio Engine:** A fully realized soundscape including:
    * **Jump Audio:** Weighted sound effects for player movement.
    * **Collision Feedback:** Impactful "Hit" sounds for game-over states.
    * **Background Score:** High-tempo music that matches the game's intensity.
* **Interactive UI:** Comprehensive Main Menu, Game Over screens, and a live HUD showing current distance and highest record.

---

## 🛠️ Technical Deep Dive

### **The Hazard System**
The game uses a specialized spawning algorithm to handle different hazard types simultaneously:
* **Falling Logic:** Objects are spawned at a height offset relative to the player's forward position and use gravity/physics to descend.
* **Crawling AI:** Ground hazards use a simple forward-vector movement to move toward or across the player's path.
* **Boss Logic:** Large-scale meshes that occupy multiple lanes, creating a "puzzle" element within the high-speed gameplay.

### **Optimization & Performance**
* **Object Pooling:** All obstacles (falling, crawling, and stoppers) are managed via an Object Pool to prevent memory spikes during high-intensity gameplay.
* **Culling:** Objects behind the player are immediately deactivated and returned to the pool.

---

## 🕹️ How to Play

### **Controls**
* **WASD / Arrow Keys:** Move and switch lanes.
* **Spacebar:** Jump over crawling hazards and low stoppers.
* **Shift/S:** Slide under high-level obstacles.

### **Survival Goal**
Avoid all hazards. **Do not touch anything.** Whether it falls from the sky, crawls on the ground, or is a stationary "Stopper," any contact results in an immediate Game Over.

---

## 📂 Project Structure

* `Core/Scripts/Managers`: Logic for the 5 Difficulty Levels and Score Tracking.
* `Core/Scripts/Hazards`: Separate classes for Falling, Crawling, and Boss obstacles.
* `Assets/Audio`: High-quality SFX for jumping, hitting, and UI interaction.
* `Assets/Prefabs`: The "Stoppers" and "Boss" models used for procedural spawning.

---

## 🔧 Installation

1.  Clone the repo: `git clone https://github.com/your-username/Endless-Runner-3D.git`
2.  Open in **[Your Engine, e.g., Unity]**.
3.  Load the `Main` scene and press **Play**.

---

## 📜 License
This project is licensed under the MIT License.

<p align="center">
  <img src="./Endless%20Runner%20Game.png" alt="Endless Runner Game Preview" width="50%">
</p>

**Developed with passion by Muhammad Abdullah**