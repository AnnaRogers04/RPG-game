# RPG - Dice

Fundamentals Of Games Development

Anna Rogers

2315276

## Research

### What sources or references have you identified as relevant to this task?

What type of sources did you identity and want to explore? How would you justify it in reference to the brief set?

- I don't like the luck based aspect of dice.
- I would like to create dice with returns a more bell curve of values, so it would often be 2-4.

- i found this article https://stackoverflow.com/questions/5816985/random-number-generator-which-gravitates-numbers-to-any-given-number-in-range

- The document above states that i will create a random generator from 1 to 6 and choose a number for the deviation. that deviation number will determine if it rolls closer to the chosen number or further away.

What type of sources do you want to avoid? How could these kinds of sources be detrimental to the user experience, immersion or implementation?

- I woild like to avoid unity.random as my dice game is using a non-uniform random generator and needs to be able to deviate towards certain numbers.

### Pseudo Code
```Plaintext

To create a non-uniform random generator i need to:

- Create a random generator from 1 to 6, 1 to 12 and 1 to 20
- Choose a deviation number e.g. 2 for the 1 to 6 dice 
- Use the bell curve to create the deviation when rolling the dice to break up the "random" aspec of the generator.
- Create an aspect to choose how many dice roll at once for instance:
if you right click on the dice, the dice rolls.
- Have a way for the dice to reset after the round set the reset button to restart the code.
-create option buttons to select fight or flee buttons. 

```
### Concept
```
For my concept I would like to use 2D versions of the dice needed to roll. You click on the dice ans it will roll with the numbers appearing below. There will be a re-roll button on the screen which resets the code.
Id like to create a labyrinth based 2D game where you come across enemys as you progess. You will roll a dice against all the enemys. An even number means you fight the enemy your up against, an odd number lets you choosse if you fight or flee. Fighting can make you become stronger but if you die your game resets. This game is based on black mirror bandisnatch the netflix playable film.
```
#### Sources

https://stackoverflow.com/questions/5816985/    
I used stack overflow as an aid for my Bell Curve code. The user 'Mike T' or 'user735897' was the user that uploaded the code that i used to help me understand the code. The helped me acknowledge that the code i was attempting to use wasnt a bell curve but just a random generator.
While his code helped, it took a long time for me to actually read the code due to the heavy amounts of over commenting on the script he provided.

```Markdown
# Documentation
I wanted to create a dice generator that has a bell curve and returns values closer to selected devation numbers. For this i used 






# example
I wanted to create an emitter which takes advantage of spread and focus, which was a technique I learned from a previous assignment where the spatialisation of an object changes depending on distance. I also wanted to work specifically with a `Spline Component` to encapsulate the entire ship with an “Ocean Emitter”. This led me to read the Unreal Blueprints API References and Wwise 3D Positioning documentation (Unreal Engine Blueprint API Reference | Unreal Engine 5.4 Documentation | Epic Developer Community, s.d., AudioKinetic Inc, s.d.).

I found a Blueprint node called “Find Location Closest to World Location" which returns a `Vector3` on the spline position closest to another `Vector3`, I believe this can help move the emitter towards the player(Finding time of given results from (Find Location Closest to World Location) from Splines - Programming & Scripting / Blueprint, 2023).

I found the Unreal documentation clear and easy to navigate, however it was much harder to find specific nodes unless you are familiar with the naming conventions used by Unreal, such as “World Location” and the API documentation is separated from the property references. The Wwise documentation on the other hand is much easier to navigate as they have core topics such as “Using Sounds and Motion to Enhance Gameplay” and examples of how they can be applied, which the unreal documentation lacked. 

# Example Game Source

Just Cause 3 is an action-adventure game developed by Avalanche Studios, it features a mechanic where the player can navigate the open world with the use of a parachute and a wingsuit(Just Cause 3, 2015).

The wind becomes more prominent in the mix and its volume and speed is based on the player's velocity when using the wingsuit or parachute. It is not too overwhelming during action sequences to ensure audio responses can be clearly heard.

I found their implementation and choice great for the context of their narrative and game mechanics. However, for the sequences featured in the assignment, it is more “cinematic” allowing for a different approach for the mix and can be “exaggerated” to drive its narrative function.


```

## Implementation

### What was the process of completing the task? What influenced your decision making?

- What was the process of completing the task at hand? Did you do any initial planning?
- Did you receive any feedback from users, peers or lecturers? How did you react to it?

<br>

```csharp
using UnityEngine;
public class HelloWorld : MonoBehaviour 
{
    public void Start() 
    {
        Debug.Log("Hello World!");
    }
}
```
*Figure 1. An example of using a script as a figure. This script has a `Start()` method!*

### What creative or technical approaches did you use or try, and how did this contribute to the outcome?

- Did you try any new software or approaches? How did the effect development?

<br>

![onhover image description](https://beforesandafters.com/wp-content/uploads/2021/05/Welcome-to-Unreal-Engine-5-Early-Access-11-16-screenshot.png)
*Figure 2. An example of an image as a figure. This image shows where to package your Unreal project!.*

### Did you have any technical difficulties? If so, what were they and did you manage to overcome them?

- I had issues with the bell curve and it not generating properly.

## Outcome

Here you can put links required for delivery of the task, ensure they are properly labelled appropriately and the links function. The required components can vary between tasks, you can find a definative list in the Assessment Information. Images and code snippets can be embedded and annotated if appropriate.

- [Example Video Link](https://www.youtube.com/watch?v=dQw4w9WgXcQ&ab_channel=RickAstley)
- [Example Repo Link](https://github.com/githubtraining/hellogitworld)
- [Example Build Link](https://samperson.itch.io/desktop-goose)

<iframe width="560" height="315" src="https://www.youtube.com/embed/dQw4w9WgXcQ?si=C4v0qHaYuEISAC01" title="YouTube video player" frameborder="0" allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture; web-share" referrerpolicy="strict-origin-when-cross-origin" allowfullscreen></iframe>

*Figure 3. An example of an embedded video using a HTML code snippet.*

<iframe frameborder="0" src="https://itch.io/embed/2374819" width="552" height="167"><a href="https://bitboyb.itch.io/nephilim-resurrection">Nephilim Resurrection (BETA) by bitboyb</a></iframe>

*Figure 4. An example of a itch.io widget*

## Critical Reflection

### What did or did not work well and why?

- What did not work well? What parts of the assignment that you felt did not fit the brief or ended up being lacklustre.
- What did you think went very well? Were there any specific aspects you thought were very good?

### What would you do differently next time?

- Are there any new approaches, methodologies or different software that you wish to incorporate if you have another chance?
- Is there another aspect you believe should have been the focus?

## Bibliography

- Please use the [harvard referencing convention](https://mylibrary.uca.ac.uk/referencing).

Video game development (2024) In: Wikipedia. At: https://en.wikipedia.org/w/index.php?title=Video_game_development&oldid=1240603537 (Accessed  03/09/2024).

## Declared Assets

- Please use the [harvard referencing convention](https://mylibrary.uca.ac.uk/referencing).

Infinity Blade: Adversaries in Epic Content - UE Marketplace (s.d.) At: https://www.unrealengine.com/marketplace/en-US/product/infinity-blade-enemies (Accessed  09/09/2024).

---

```Markdown
# General Tips

- Use plenty of images and videos to demonstrate your point. You can embed YouTube tutorials, your own recordings, etc.
- Always reference! Even documentation, tutorials and anything you used for your assignment. Use an inline reference for the sentence and a bibliography reference at the end.
- Word count is not important, you can also chose to use bullet points. As long as it is clear and readable, the format your decide to use can be flexible.
- You are free to use AI but please ensure you have made a note in the declared assets, for example if you have a script called Test.cs , you should note that AI was used to in the creation of this script. You can use a bullet point list for each asset used like:

The following assets were created or modified with the use of GPT 4o:
- Test.cs
- AnotherScript.cs
- Development Journal.html

```
