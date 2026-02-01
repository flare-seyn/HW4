# HW4
## Devlog
In this project, the Model–View–Controller (MVC) design pattern is used to keep the Player logic decoupled from the rest of the game systems. While the model aspect of the game is relatively minimal, the separation between control and view plays a major role in keeping the code organized, flexible, and easier to debug.

Controller: PlayerController

The control side of the MVC pattern is primarily defined by the PlayerController class.

This script is responsible for handling all player-related input and gameplay logic, including:

Reading input in Update()

Applying upward force using the Rigidbody2D when the player flaps

Detecting collisions and triggers using OnCollisionEnter2D() and OnTriggerEnter2D()

Broadcasting gameplay events such as scoring and game over

For example, the variable:

public static event Action Scored;
public static event Action Died;


allows the PlayerController to signal that something has happened without directly referencing any UI or audio systems.

Because of this, the PlayerController never modifies UI text, never plays audio clips, and never manages score values directly. It only communicates intent through events.

This keeps the player code focused entirely on control logic, which is the key responsibility of the controller in MVC.

View: ScoreView and AudioView

The view side of the pattern is implemented using multiple classes, primarily:

ScoreView

AudioView

ScoreView

The ScoreView script is responsible only for displaying information to the player. It holds a reference to:

[SerializeField] private TextMeshProUGUI scoreText;


and subscribes to events in OnEnable():

PlayerController.Scored += UpdateScore;


When the score changes, the view updates the text, but it does not know why the score changed or what caused it. It simply reacts to events.

This allows the UI system to remain completely independent from gameplay logic.

AudioView

The AudioView class follows the same pattern. It contains references to audio clips such as:

public AudioClip flapClip;
public AudioClip scoreClip;
public AudioClip hitClip;


and listens for gameplay events to determine when sounds should play.

The PlayerController does not know what sound is being played or how it is played—it only raises events like Scored or Died.

This separation ensures that audio can be modified, replaced, or removed entirely without changing any gameplay code.

Events for Decoupling

Events are the main mechanism used to decouple the controller from the views.

Instead of writing code like:

scoreText.text = score.ToString();
audioSource.Play();


the PlayerController simply triggers:

Scored?.Invoke();
Died?.Invoke();


Any number of view systems can subscribe to these events:

UI

Audio

Animations

Screen effects

This makes the system highly modular and prevents circular dependencies between scripts.

Singleton: ScoreManager

The project also uses a Singleton pattern through the ScoreManager class.

The Singleton ensures there is only one authoritative score state shared across the game:

public static ScoreManager Instance;


The ScoreManager is responsible for:

Tracking the current score value

Responding to the Scored event

Providing a global point of access for score data

Because ScoreManager exists independently of both the PlayerController and the UI, neither system directly depends on each other.

This allows:

The PlayerController to remain unaware of how scoring is stored

The ScoreView to display score data without calculating it

The game logic to remain stable even if UI or audio changes

Reflection

Using MVC made debugging significantly easier, especially when dealing with issues such as scoring and collisions. For example, when it became difficult to score in the game due to pipe spacing and collider placement, the issue was isolated to level design and prefabs—not the player logic itself.

Because the PlayerController did not contain UI or audio code, gameplay bugs could be tested without worrying about breaking the presentation layer.

Although the model portion of the architecture is relatively simple in this project, the clear separation between controller and view demonstrates how MVC helps keep systems modular, readable, and maintainable even in a small game.

Summary

Controller: PlayerController

Handles input, physics, and gameplay events

View: ScoreView, AudioView

Display UI and play sound in response to events

Events:

Used to communicate between systems without direct references

Singleton: ScoreManager

Maintains centralized score state

Overall, the MVC pattern allows the Player code to remain decoupled from UI and audio systems, resulting in a cleaner architecture and a more scalable project structure.

## Open-Source Assets
If you added any other assets, list them here!
- [Brackey's Platformer Bundle](https://brackeysgames.itch.io/brackeys-platformer-bundle) - sound effects
- [2D pixel art seagull sprites](https://elthen.itch.io/2d-pixel-art-seagull-sprites) - seagull sprites
- https://freesound.org/people/Clusman/sounds/543117/ sound effects
- 
