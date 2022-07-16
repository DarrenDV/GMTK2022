using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Health : MonoBehaviour
{
    public int health = 100;
    public int maxHealth = 100;

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
