using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public string direction;

    [SerializeField] private GameObject Projectile;

    public void Shoot()
    {
        Vector3 directionVector = Vector3.zero;

        switch (direction)
        {
            case "left":
                directionVector = Vector3.left;
                break;
            case "right":
                directionVector = Vector3.right;
                break;
            case "forward":
                directionVector = Vector3.forward;
                break;
            case "back":
                directionVector = Vector3.back;
                break;
        }
        
        GameObject bullet = Instantiate(Projectile, transform.position, Quaternion.identity);
        bullet.GetComponent<Bullet>().rb.AddForce(directionVector * (2 * 1000));
    }
}
