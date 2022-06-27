using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    public float bulletSpeed;
    public float bulletDestroyTimer;
    public int bulletDmg;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime);

        bulletDestroyTimer -= Time.deltaTime;
        if (bulletDestroyTimer <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            other.GetComponent<EnemyScript>().damagedEnemy(bulletDmg);
            Destroy(gameObject);
        }
    }

}
