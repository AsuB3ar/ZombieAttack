using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public GameObject Enemy;
    private Rigidbody myRigidbody;
    public float enemyMoveSpeed;
    public float enemyHealth;
    public float enemyCurrentHealth;

    
 

    public float hitIndicatorLength;
    private float hitIndicatorTimer;

    private Renderer render;
    private Color baseColor;

    public PlayerScript thePlayer;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        thePlayer = FindObjectOfType<PlayerScript>();
        render = GetComponent<Renderer>();
        baseColor = render.material.GetColor("_Color");
        enemyCurrentHealth = enemyHealth;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(thePlayer.transform.position);
        if(enemyCurrentHealth <= 0)
        {
            thePlayer.Kill += 1;
            Destroy(gameObject);
        }

        if(hitIndicatorLength > 0)
        {
            hitIndicatorTimer -= Time.deltaTime;
            if (hitIndicatorTimer <= 0)
            {
                render.material.SetColor("_Color", baseColor);
            }
        }
    }

    private void FixedUpdate()
    {
        myRigidbody.velocity = (transform.forward * enemyMoveSpeed * (thePlayer.Level*1));
    }

    public void damagedEnemy(int enemyDamageTaken)
    {
        enemyCurrentHealth -= enemyDamageTaken;
        hitIndicatorTimer = hitIndicatorLength;
        render.material.SetColor("_Color", Color.red);
    }

}
