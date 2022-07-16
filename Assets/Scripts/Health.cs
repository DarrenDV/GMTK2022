using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int health = 100;
    public int maxHealth = 100;
    [SerializeField] private ScoreText scoreText;

    [SerializeField] private Slider healthSlider;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        UpdateHealth();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
        Debug.Log("Taking damage:" + damage);
        UpdateHealth();
    }

    void UpdateHealth()
    {
        healthSlider.value = health;
    }

    void Die()
    {
        scoreText.canAddScore = false;
        Destroy(scoreText.gameObject);
        // play death animation
        // play death sound
        // game over screen
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    }


    // Update is called once per frame
    // void Update()
    // {
        
    // }
}
