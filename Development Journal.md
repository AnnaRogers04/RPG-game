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

- research into UI systems to implement a function health bar.

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
However, i came to realise this concept was too broad for the time i had to complete it by i changed my idea to simplify it by getting rid of the labyrinth and having the enemies in the open as intractable.

## The Process

- I started by prototyping a class to randomly generate numbers.
- I added the deviation to the random generator making a bell curve that leans towards a number I chose.
- I used this generator to create a battle loop where the random generator is the attack damage.
- implement tile based system, however collisions did not work.


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
### BattleSystem.cs
```cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSystem : MonoBehaviour
{
    public Health playerHealth, enemyHealth;
    public BellCurveRandomGenerator bcrg;
    public void SetEnemyTarget(Health newEnemy) => enemyHealth = newEnemy;


    public void Battle()
    {
        enemyHealth.TakeDamage(bcrg.GenerateBellCurveRandom(1, 6, 3));
        playerHealth.TakeDamage(bcrg.GenerateBellCurveRandom(1, 6, 4));
    }
}
```

### Enemy.cs
```cs
using System.Collections;
using System.Collections.Generic;
using Unity.UI;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public BattleSystem bs;
    public Sprite enemyImg;
    public Image image;
    private Health _health;
    private GameObject battleUI;

    private BattleSystem battleSystem;

    [SerializeField]private Slider battleSlider;
    private void Start()
    {
        battleSystem = GameObject.FindGameObjectWithTag("BattleSystem").GetComponent<BattleSystem>();
        _health = GetComponent<Health>();
        battleUI = image.gameObject;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Triggered No Work I Guess");
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Triggered");
            bs.enemyHealth = _health;
            image.sprite = enemyImg;
            battleUI.SetActive(true);
            _health.healthBar = battleSlider;
            _health.ResetHealth();
            battleSystem.enemyHealth = _health;
        }
    }
}
```
### Health.cs
```cs
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float currentHealth, maxHealth = 100f;
    public Slider healthBar;
    public GameObject fillObject;
    public GameObject battleUI;

    [SerializeField]private bool isPlayer;
    [SerializeField]private Restart restart;
    private void Awake()
    {
        currentHealth = maxHealth;
        if(healthBar == null) return;
        healthBar.value = currentHealth / maxHealth;
    }    

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0) Die();
        healthBar.value = currentHealth / maxHealth;
    }

    public void AddHealth(float amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth) currentHealth = maxHealth;
        healthBar.value = currentHealth / maxHealth;
    }

    private void Die()
    {
        //fillObject.SetActive(false);
        battleUI.SetActive(false);
    }

    public void ResetHealth()
    {
        if (currentHealth > maxHealth) currentHealth = maxHealth;
        healthBar.value = currentHealth / maxHealth;
    }

    private void Update()
    {
        if(isPlayer == false) return;

        if(currentHealth <= 0)
        {
            restart.RestartGame();
        }
    }

}
```
### PlayerMovement.cs
```cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 1.5f;

    public SpriteRenderer spriteRenderer;
    public Animator PlayerAnim;
    public string ParameterName;

    private void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveX, moveY, 0);
        transform.position += movement * speed * Time.deltaTime;

        if(Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
             PlayerAnim.SetBool(ParameterName, true);
        }
        else
        {
             PlayerAnim.SetBool(ParameterName, false);
        }
        if(Input.GetAxis("Horizontal") >= 0 )
        {
             spriteRenderer.flipX = false;
        }
         if(Input.GetAxis("Horizontal") <= 0 )
        {
             spriteRenderer.flipX = true;
        }


```
### RestartButton.cs
```cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

    
    public class Restart : MonoBehaviour
    {
        [SerializeField]private GameObject restartCanvas;
    	public void RestartGame() 
        {
    		SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
            restartCanvas.SetActive(false);
    	}

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                restartCanvas.SetActive(!restartCanvas.activeSelf);
            }
        }
    }

```


- [https://lunarlynx-games.itch.io/rollquest](itchlink)
- [https://github.com/AnnaRogers04](gitlink)
- [https://youtu.be/_V-dt0JOJTU?si=6-LwRPRocS8P6i0_](youtubelink)



## Reflection

### What Went Well
Using SoloLearn i furthered my understanding in reading code because of this I was able to write and read code more clearly with less help.
- it was my first proper game project, it is a large achievement to get something finished.

### What Did Not Go Well
I chose a very broad subject to try a recreate in a short amount of time, because of this my project ended up taking a lot longer then it should have. This left me to partially neglect the rest of my work on other subjects, this left me playing catchup.
- time management was an issue.
- i struggled with focus due to being overwhelmed with the large amount of projects.

### What would you do differently next time?
Next time I will drastically simplify what i want to create while keeping the code unique. I will focus less on graphics and how the game looks while narrowing the concept. This will give me more time to focus on the code.


## Bibliography

MikeT (2015) Answer to ‘Random number generator which gravitates numbers to any given number in range?’ At: https://stackoverflow.com/a/28943782/27932229 (Accessed  15/11/2024).

Technologies, U. (s.d.) Unity - Scripting API: Random.Range. At: https://docs.unity3d.com/6000.0/Documentation/ScriptReference/Random.Range.html (Accessed  15/11/2024).

What is pseudocode? | Definition from TechTarget (s.d.) At: https://www.techtarget.com/whatis/definition/pseudocode (Accessed  15/11/2024).


# Documentation
I wanted to create a dice generator that has a bell curve and returns values closer to selected deviation number. For this I created a random generator for the D6, D12 and D20 dice and then added a peak which is the bell curve. I used Mathf.Lerp to help calculate between the min and peak and the max and peak.

## Declared assets
Hero nad Opponents Animation | 2D Characters | Unity Asset Store (s.d.) At: https://assetstore.unity.com/packages/2d/characters/hero-nad-opponents-animation-140776 (Accessed  29/11/2024).
Pixel Art Top Down - Basic | 2D Environments | Unity Asset Store (s.d.) At: https://assetstore.unity.com/packages/2d/environments/pixel-art-top-down-basic-187605 (Accessed  29/11/2024).
ChatGBT 3.5 script - Bellcurve.cs


# Implementation

## What was the process of completing the task? What influenced your decision making?
When talking about what i liked i mentioned logic, I liked the idea of being able to win something by memory. While making the dice lean towards a number isn't exactly logical it gave the effect i wanted unintentionally. 

## What was the process of completing the task at hand? Did you do any initial planning?
I didn't have any initial planning for the dice, i originally struggled with coming up with an idea when it came to starting the game. 
## Did you receive any feedback from users, peers or lecturers? How did you react to it?
The feedback I got for this project was to focus less on the graphics. The graphics had roped me into a spiral where it consumed me and i couldn't focus on any of the code for the game.

### What creative or technical approaches did you use or try, and how did this contribute to the outcome?

I used ChatGBT, Github and SoloLearn. ChatGBT and SoloLearn helped massively when it came to understanding and being able to read code. As someone who's new to coding I couldn't recommend this more.
ChatGBT is a great software, while i still don't fully understand it the aspect of being able to access my game files anywhere is really helpful.
I would say all of this contributed to the game in a positive way. f

### Did you have any technical difficulties? If so, what were they and did you manage to overcome them?

When coding i had troubles asking ChatGBT for help. My questions were too broad for it therefore the code it produced wasn't what i wanted and didn't work as intended.



