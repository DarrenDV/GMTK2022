using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class Totem : MonoBehaviour
{
    
    [SerializeField] private List<Gun> guns = new List<Gun>();
    [SerializeField] private GameObject projectile;

    public float secondsToFire = 2f;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TotemFire());
    }
    

    IEnumerator TotemFire()
    {
        while (true)
        {
            yield return new WaitForSeconds(secondsToFire);
            foreach (Gun gun in guns)
            {
                gun.Shoot();
            }
        }
        yield return null;
    }
}
