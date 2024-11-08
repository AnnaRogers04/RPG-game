using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float currentHealth, maxHealth = 100f;
    public Slider[] healthBar;
    public GameObject fillObject;
    public GameObject battleUI;

    [SerializeField]private bool isPlayer;
    [SerializeField]private Restart restart;
    private void Awake()
    {
        currentHealth = maxHealth;
        if(healthBar[0] == null) return;
        foreach(Slider s in healthBar)
        {
            s.value = currentHealth / maxHealth;
        }
    }    

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0) Die();
        foreach(Slider s in healthBar)
        {
            s.value = currentHealth / maxHealth;
        }
    }

    public void AddHealth(float amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth) currentHealth = maxHealth;
        foreach(Slider s in healthBar)
        {
            s.value = currentHealth / maxHealth;
        }
    }

    private void Die()
    {
        fillObject.SetActive(false);
        battleUI.SetActive(false);
    }

    public void ResetHealth()
    {
        if (currentHealth > maxHealth) currentHealth = maxHealth;
        foreach(Slider s in healthBar)
        {
            s.value = currentHealth / maxHealth;
        }
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
