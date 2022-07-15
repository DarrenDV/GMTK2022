using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillHealthBar : MonoBehaviour
{
    public Health health;
    public Image healthBarImage;
    private Slider healthBarSlider;

    // Start is called before the first frame update
    void Awake()
    {
        healthBarSlider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        //float healthPercentage = health.health / health.maxHealth;
        healthBarSlider.value = health.health; // healthPercentage * 100;
    }
}
