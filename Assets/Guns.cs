using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guns : MonoBehaviour
{
    [SerializeField] private List<GameObject> guns = new List<GameObject>();
    [SerializeField] private List<GameObject> specials = new List<GameObject>();

    [SerializeField] private GameObject bullet;

    [SerializeField] private GameObject totem;

    [SerializeField] private GameObject specialParent;

    private float timeBetweenShotsNow;
    
    public float gunStrength = 0.5f;

    public float timeBetweenShots = 1f;
    public float timeBetweenShotsDice = 0.5f;
    
    public bool diceEffect;

    public float diceEffectAlive = 5f;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Shot());
        timeBetweenShotsNow = timeBetweenShots;
    }

    public void DiceEffect()
    {
        specialParent.SetActive(true);
        diceEffect = true;
        timeBetweenShotsNow = timeBetweenShotsDice;
        Manager.Instance.effectActive = true;
        StartCoroutine(DiceEffectTime());
    }

    private IEnumerator DiceEffectTime()
    {
        yield return new WaitForSeconds(diceEffectAlive);
        diceEffect = false;
        specialParent.SetActive(false);
        timeBetweenShotsNow = timeBetweenShots;
        Manager.Instance.EffectHasStopped();
        StopCoroutine(DiceEffectTime());
    }
    
    private IEnumerator Shot()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeBetweenShotsNow);
        
            foreach (GameObject gun in guns)
            {
                ShootGun(gun);
                gameObject.GetComponent<AudioSource>().Play();
            }

            if (diceEffect)
            {
                foreach (GameObject gun in specials)
                {
                    ShootGun(gun);
                    gameObject.GetComponent<AudioSource>().Play();
                }
            }
        }
    }

    private void ShootGun(GameObject gun)
    {
        Vector3 heading = totem.transform.position - gun.transform.position;
        float distance = heading.magnitude;
        Vector3 direction = heading / distance;
    
        Vector3 finalDirection = new Vector3(direction.x, 0, direction.z);
    
        GameObject go = Instantiate(bullet, gun.transform.position, Quaternion.identity);
        go.GetComponent<Bullet>().rb.AddForce(-finalDirection * gunStrength, ForceMode.Impulse);
    }
}
