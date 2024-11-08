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
