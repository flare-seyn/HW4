# HW4
## Devlog
In this project, the Model–View–Controller (MVC) design pattern is used to keep the Player code decoupled from the other systems in the game. While the model aspect of this game is less relevant, the view and controller layers play an important role in structuring the project.

The MVC structure allows each system to focus on a single responsibility, which made debugging and iteration much easier during development.

# Controller

The controller side of the MVC pattern is defined by the PlayerController class.

PlayerController is responsible for all player input and gameplay behavior, including:

Reading player input in Update()

Applying movement forces to the Rigidbody2D

Detecting collisions with pipes and triggers

Deciding when the player scores or dies

The PlayerController does not directly modify UI elements or play audio. Instead, it communicates important gameplay moments through events.

For example, instead of directly changing UI text or playing sounds, the PlayerController raises events such as:

Scored.Invoke()
Died.Invoke()

This ensures the player logic remains focused only on control logic.

# View

The view side of the MVC pattern is implemented using multiple classes that respond to events.

The primary view scripts in this project are:

ScoreView

AudioView

# ScoreView

ScoreView is responsible for displaying the current score on the screen. It contains a reference to a TextMeshProUGUI object used to show the score visually.

ScoreView subscribes to the scoring event when enabled and updates the text whenever the score changes. It does not calculate the score or determine when scoring occurs — it only displays information.

Because of this, ScoreView has no direct dependency on PlayerController.

AudioView

AudioView is responsible for playing sound effects such as flap, score, and hit sounds.

It listens for the same gameplay events triggered by PlayerController and plays the appropriate AudioClip in response. The player logic does not know which sound is played or how it is played.

This allows audio behavior to be changed or removed without modifying gameplay code.

# Events and Decoupling

Events are the main mechanism used to decouple the controller and view layers.

Rather than having PlayerController reference UI or audio objects directly, it simply broadcasts events when something happens.

Any number of systems can subscribe to these events, including:

UI

Audio

Animations

Screen effects

This design prevents circular dependencies between scripts and makes the project modular and easier to maintain.

Singleton: ScoreManager

The project also uses a Singleton pattern through the ScoreManager class.

ScoreManager contains a static Instance variable that ensures only one score system exists in the game.

Its responsibilities include:

Tracking the current score value

Responding to scoring events

Providing global access to score data

Because ScoreManager exists independently from PlayerController and ScoreView, neither system directly depends on the other.

This further reinforces the separation between control and view layers.

Reflection

Using the MVC pattern helped keep the Player code clean and isolated from presentation systems such as UI and audio.

During development, gameplay tuning — such as pipe spacing and timing — made scoring somewhat difficult, which made the game a bit hard to score at times. However, because the logic was decoupled, these issues could be adjusted through prefabs and values without changing the PlayerController code itself.

Overall, the MVC structure made the project easier to debug, extend, and understand.

# Summary

Controller: PlayerController
View: ScoreView and AudioView
Communication: C# events
Shared state: ScoreManager Singleton

By separating responsibilities across these systems, the project maintains a clean MVC-style architecture that keeps the Player code decoupled from UI, audio, and scoring systems.
## Open-Source Assets
If you added any other assets, list them here!
- [Brackey's Platformer Bundle](https://brackeysgames.itch.io/brackeys-platformer-bundle) - sound effects
- [2D pixel art seagull sprites](https://elthen.itch.io/2d-pixel-art-seagull-sprites) - seagull sprites
- https://freesound.org/people/Clusman/sounds/543117/ sound effects
- 
