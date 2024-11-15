# RPG Game

Fundamentals Of Games Development

Anna Rogers

2315276

## Dice Research

### What sources or references have you identified as relevant to this task?

- I don't like the luck based aspect of dice.
- I would like to create dice with returns a more bell curve of values, so it would often be 2-4.
- I found this article which explained how to generate a bell curve for random number generation (MikeT, 2015).I used stack overflow as an aid for my Bell Curve code. The user 'Mike T' or 'user735897' was the user that uploaded the code that i used to help me understand the code. The helped me acknowledge that the code i was attempting to use wasn't a bell curve but just a random generator.
While his code helped, it took a long time for me to actually read the code due to the heavy amounts of over commenting on the script he provided.
- The document above states that i will create a random generator from 1 to 6 and choose a number for the deviation. that deviation number will determine if it rolls closer to the chosen number or further away.
- I would like to avoid `Unity.Random` as my dice game is using a non-uniform random generator and needs to be able to deviate towards certain numbers (Technologies, s.d.).
- I wrote some pseudo to help me understand how to approach this task(What is pseudocode? | Definition from TechTarget, s.d.).

### Pseudo Code
```Plaintext

To create a non-uniform random generator i need to:

- Create a random generator from 1 to 6, 1 to 12 and 1 to 20
- Choose a deviation number e.g. 2 for the 1 to 6 dice 
- Use the bell curve to create the deviation when rolling the dice to break up the "random" aspect of the generator.
- Create an aspect to choose how many dice roll at once for instance:
if you right click on the dice, the dice rolls.
- Have a way for the dice to reset after the round set the reset button to restart the code.
-create option buttons to select fight or flee buttons. 

```
### Concept

My original concept for this game was very different from the outcome. Originally i wanted to create a 2D labyrinth game where the fight system depended on on the dice roll. I wanted the dice roll to have a deviation towards a number of my choosing to take away the luck aspect in the game. I was going to base it on the game in the interactive netflix series called black mirror bandisnatch. 
However, i came to realise this concept was too broad for the time i had to complete it by i changed my idea to simplify it by getting rid of the labyrinth and having the enemies in the open as intractables.

## The Process

- I started by prototyping a class to randomly generate number.

### BellCurveGenerator.cs

```cs
public class BellCurveRandomGenerator : MonoBehaviour
{
    public int sampleCount = 10;
    private void Start()
    {
 
        for (int i = 0; i < sampleCount; i++)
        {
             int D6Dice = GenerateBellCurveRandom(1, 6, 2); 
             int D12Dice = GenerateBellCurveRandom(1, 12, 8);
             int D20Dice = GenerateBellCurveRandom(1, 20, 12);
             int total = D6Dice + D12Dice + D20Dice;
             Debug.Log($"Generated D6: {D6Dice}, D12: {D12Dice}, D20: {D20Dice}, Total: {total}");
        } 
    }
    public int GenerateBellCurveRandom(float min, float max, float peak)
    {
        float randomValue = Random.Range(0f, 1f);
        if (peak == (min + max) / 2)
        {
            randomValue = Mathf.Pow(randomValue, 2);
        }
        else
        {
            if (randomValue < 0.5f)
            {
                randomValue = Mathf.Lerp(min, peak, Mathf.Pow(randomValue * 2f, 2)); 
            }
            else
            {
                randomValue = Mathf.Lerp(peak, max, Mathf.Pow((randomValue - 0.5f) * 2f, 2));
            }
        }
        int finalValue = Mathf.Clamp(Mathf.RoundToInt(randomValue), Mathf.RoundToInt(min), Mathf.RoundToInt(max));

        return finalValue;
    }
}
```
- This did not initially work, I was struggling to the understand the concepts and leveraged ChatGPT in order to explain what was going wrong.

### ChatGPT Response

Let’s go through this code step-by-step! This code is a Unity script that simulates rolling different kinds of dice (D6, D12, and D20) but with a "bell curve" effect, meaning the results will be biased toward the average values rather than evenly spread across all possible values.

### 1. **Class Definition and Variables**
   ```csharp
   public class BellCurveRandomGenerator : MonoBehaviour
   {
       public int sampleCount = 10;
   ```

   - `BellCurveRandomGenerator` is a class that inherits from `MonoBehaviour`, meaning it’s meant to be attached to a GameObject in Unity.
   - `sampleCount` is a public integer variable that determines how many times the dice rolls will be simulated (default is 10).

### 2. **`Start` Method**
   ```csharp
   private void Start()
   {
       for (int i = 0; i < sampleCount; i++)
       {
           int D6Dice = GenerateBellCurveRandom(1, 6, 2); 
           int D12Dice = GenerateBellCurveRandom(1, 12, 8);
           int D20Dice = GenerateBellCurveRandom(1, 20, 12);
           int total = D6Dice + D12Dice + D20Dice;
           Debug.Log($"Generated D6: {D6Dice}, D12: {D12Dice}, D20: {D20Dice}, Total: {total}");
       }
   }
   ```
- The response was somewhat helped to understand the underlying concepts I needed to utilise. However the code generated also did not work the way intended.

## Final Outcomes

### BellCurve.cs
```cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BellCurveRandomGenerator : MonoBehaviour
{
    public int sampleCount = 10;
    private void Start()
    {
 
        for (int i = 0; i < sampleCount; i++)
        {
             int D6Dice = GenerateBellCurveRandom(1, 6, 2); 
             int D12Dice = GenerateBellCurveRandom(1, 12, 8);
             int D20Dice = GenerateBellCurveRandom(1, 20, 12);
             int total = D6Dice + D12Dice + D20Dice;
             Debug.Log($"Generated D6: {D6Dice}, D12: {D12Dice}, D20: {D20Dice}, Total: {total}");
        } 
    }
    public int GenerateBellCurveRandom(float min, float max, float peak)
    {
        float randomValue = Random.Range(0f, 1f);
        if (peak == (min + max) / 2)
        {
            randomValue = Mathf.Pow(randomValue, 2);
        }
        else
        {
            if (randomValue < 0.5f)
            {
                randomValue = Mathf.Lerp(min, peak, Mathf.Pow(randomValue * 2f, 2)); 
            }
            else
            {
                randomValue = Mathf.Lerp(peak, max, Mathf.Pow((randomValue - 0.5f) * 2f, 2));
            }
        }
        int finalValue = Mathf.Clamp(Mathf.RoundToInt(randomValue), Mathf.RoundToInt(min), Mathf.RoundToInt(max));

        return finalValue;
    }
}
```

- [LINK TO GAME](itchlink)
- [LINK TO REPOSITORY](gitlink)
- [LINK TO DEMONSTRATION VIDEO](youtubelink)

- EMBED VIDEO AND WIDGETS HERE

## Reflection

### What Went Well
Using SoloLearn i furthered my understanding in reading code because of this I was able to write and read code more clearly with less help.

### What Did Not Go Well
I chose a very broad subject to try a recreate in a short amount of time, because of this my project ended up taking a lot longer then it should have. This left me to partially neglect the rest of my work on other subjects, this left me playing catchup.

### What would you do differently next time?
Next time I will drastically simplify what i want to create while keeping the code unique. I will focus less on graphics and how the game looks while narrowing the concept. This will give me more time to focus on the code.


## Bibliography

MikeT (2015) Answer to ‘Random number generator which gravitates numbers to any given number in range?’ At: https://stackoverflow.com/a/28943782/27932229 (Accessed  15/11/2024).

Technologies, U. (s.d.) Unity - Scripting API: Random.Range. At: https://docs.unity3d.com/6000.0/Documentation/ScriptReference/Random.Range.html (Accessed  15/11/2024).

What is pseudocode? | Definition from TechTarget (s.d.) At: https://www.techtarget.com/whatis/definition/pseudocode (Accessed  15/11/2024).


## Declared Assets



# Documentation
I wanted to create a dice generator that has a bell curve and returns values closer to selected deviation number. For this I created a random generator for the D6, D12 and D20 dice and then added a peak which is the bell curve. I used Mathf.Lerp to help calculate between the min and peak and the max and peak.





# Implementation

## What was the process of completing the task? What influenced your decision making?
When talking about what i liked i mentioned logic, I liked the idea of being able to win something by memory. While making the dice lean towards a number isn't exactly logical it gave the effect i wanted unintentionally. 

## What was the process of completing the task at hand? Did you do any initial planning?
I didnt have any initial planning for the dice, i originally struggled with coming up with an idea when it came to starting the game. 
## Did you receive any feedback from users, peers or lecturers? How did you react to it?


### What creative or technical approaches did you use or try, and how did this contribute to the outcome?

I used ChatGBT, Github and SoloLearn. ChatGBT and SoloLearn helped massively when it came to understanding and being able to read code. As someone who's new to coding I couldn't recommend this more.
ChatGBT is a great software, while i still don't fully understand it the aspect of being able to access my game files anywhere is really helpful.
I would say all of this contributed to the game in a positive way. f

### Did you have any technical difficulties? If so, what were they and did you manage to overcome them?

When coding i had troubles asking ChatGBT for help. My questions were too broad for it therefore the code it produced wasn't what i wanted and didn't work as intended.


## Outcome


- [Example Video Link](https://www.youtube.com/watch?v=dQw4w9WgXcQ&ab_channel=RickAstley)
- [Example Repo Link](https://github.com/githubtraining/hellogitworld)
- [Example Build Link](https://samperson.itch.io/desktop-goose)

<iframe width="560" height="315" src="https://www.youtube.com/embed/dQw4w9WgXcQ?si=C4v0qHaYuEISAC01" title="YouTube video player" frameborder="0" allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture; web-share" referrerpolicy="strict-origin-when-cross-origin" allowfullscreen></iframe>

*Figure 3. An example of an embedded video using a HTML code snippet.*

<iframe frameborder="0" src="https://itch.io/embed/2374819" width="552" height="167"><a href="https://bitboyb.itch.io/nephilim-resurrection">Nephilim Resurrection (BETA) by bitboyb</a></iframe>

*Figure 4. An example of a itch.io widget*


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
