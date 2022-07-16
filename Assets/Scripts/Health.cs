using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health = 100;
    public int maxHealth = 100;
    [SerializeField] private ScoreText scoreText;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
        
    }

    void Die()
    {
        scoreText.canAddScore = false;
        Destroy(scoreText.gameObject);
        // play death animation
        // play death sound
        // game over screen
    }


    // Update is called once per frame
    // void Update()
    // {
        
    // }
}
