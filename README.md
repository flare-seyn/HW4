# HW4
## Devlog

In this project, the Model–View–Control (MVC) pattern is used to keep the Player logic decoupled from other game systems such as UI and audio. While the model layer is relatively minimal in this game, the control and view layers are clearly separated through the use of events and a Singleton-based manager.

The control side of the system is primarily defined by the PlayerController class. PlayerController is responsible for handling player input (for example, detecting the SPACE key to flap), applying physics forces to the player’s Rigidbody2D, and detecting collisions with pipes. Importantly, PlayerController does not directly update UI elements or play sounds. Instead, when meaningful gameplay events occur—such as the player successfully passing a pipe or colliding with an obstacle—it triggers events (for example, invoking a score event or calling GameController.TriggerGameOver()).

The view side of the system is handled by separate classes such as ScoreView and AudioView. ScoreView is responsible only for displaying the score on screen by updating a TextMeshPro UI element, while AudioView is responsible for playing audio clips such as flap, score, or hit sounds. These classes subscribe to events rather than being called directly by the player logic. As a result, they react to changes in game state without tightly coupling themselves to the PlayerController.

Events play a critical role in maintaining this decoupling. Instead of writing code such as updating UI text or calling AudioSource.Play() directly inside PlayerController, the controller simply invokes events when something happens. Multiple view systems can then subscribe to the same event, allowing UI, audio, and other effects to respond independently. This makes the system modular and prevents circular dependencies between scripts.

A Singleton is used in the form of the GameController class. GameController maintains global game state through variables such as IsGameOver and exposes a static GameOver event. When GameController.TriggerGameOver() is called, it broadcasts the event and freezes the game using Time.timeScale = 0f. View systems such as the Game Over UI subscribe to this event and display feedback to the player without the controller needing to know how that feedback is implemented.

One noticeable outcome of this structure is that the game is intentionally a bit hard to score. While the difficulty could be tuned further, this reflects a gameplay balancing issue rather than a structural problem. The scoring, audio feedback, and UI display all function correctly and independently, demonstrating that the MVC-inspired architecture and event-driven design successfully decouple control logic from presentation logic.

Overall, by separating control logic (PlayerController), global state management (GameController), and presentation logic (ScoreView, AudioView), this project demonstrates how MVC concepts, events, and a Singleton can be combined to produce a clean, flexible, and maintainable game architecture.


## Open-Source Assets
If you added any other assets, list them here!
- [Brackey's Platformer Bundle](https://brackeysgames.itch.io/brackeys-platformer-bundle) - sound effects
- [2D pixel art seagull sprites](https://elthen.itch.io/2d-pixel-art-seagull-sprites) - seagull sprites
- https://freesound.org/people/Clusman/sounds/543117/ sound effects
- 
