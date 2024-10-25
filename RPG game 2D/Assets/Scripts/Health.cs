using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float currentHealth, maxHealth = 100f;
    public Slider healthBar;
    public GameObject fillObject;

    private void Awake()
    {
        currentHealth = maxHealth;
        healthBar.value  = currentHealth / maxHealth;
    }    

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0) Die();
        healthBar.value  = currentHealth / maxHealth;
    }

    public void AddHealth(float amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth) currentHealth = maxHealth;
        healthBar.value = currentHealth / maxHealth;
    }

    private void Die()
    {
        fillObject.SetActive(false);
        // TODO: Stuff to happen when this dies
    }
}
