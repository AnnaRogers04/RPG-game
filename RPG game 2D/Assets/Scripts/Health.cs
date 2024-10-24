using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    []
   float testHealAmount = 5f;
[SerializeField]
float testDamageAmount = -5f;

public void ChangeHealth(float amount) {
   float oldHealth = currentHealth;
   currentHealth += amount;
   currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

   // Fire off health change event.
   OnHealthChanged?.Invoke(this, oldHealth, currentHealth);
}

// Test code
void Update() {
  if (Input.GetKeyDown(KeyCode.Q)) {
    ChangeHealth(testHealAmount);
  }
  if (Input.GetKeyDown(KeyCode.E)) {
    ChangeHealth(testDamageAmount);
  }
}
}
