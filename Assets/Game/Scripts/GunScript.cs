using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public bool isFiring;

    public BulletScript bullet;
    public float bulletSpeed;
    public float rateOfFire;
    private float bulletTimer;
    private int bulletDmg;

    public Transform firePoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isFiring)
        {
            bulletTimer -= Time.deltaTime;
            if(bulletTimer <= 0)
            {
                bulletTimer = 1 / rateOfFire;
                BulletScript newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation) as BulletScript;
                newBullet.bulletSpeed = bulletSpeed;
            }
        }
        else
        {
            bulletTimer = 0;
        }
    }
}
