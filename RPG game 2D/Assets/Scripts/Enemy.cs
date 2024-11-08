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
            _health.healthBar[0] = battleSlider;
            _health.ResetHealth();
            battleSystem.enemyHealth = _health;
        }
    }
}
