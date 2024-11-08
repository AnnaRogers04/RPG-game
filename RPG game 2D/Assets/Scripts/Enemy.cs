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

    private void Start()
    {
        _health = GetComponent<Health>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            bs.enemyHealth = _health;
            image.sprite = enemyImg;
        }
    }
}
