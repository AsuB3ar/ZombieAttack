using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public GameManager gameManager;

    public float playerHealth;
    public float currentPlayerHealth;

    public float hitIndicatorLength;
    private float hitIndicatorTimer;

    private Renderer render;
    private Color baseColor;

    // Start is called before the first frame update
    void Start()
    {
        currentPlayerHealth = playerHealth;
        render = GetComponent<Renderer>();
        baseColor = render.material.GetColor("_Color");
    }

    // Update is called once per frame
    void Update()
    {
        if (currentPlayerHealth <= 0)
        {
            gameObject.SetActive(false);
            gameManager.GameOver();
        }

        if(hitIndicatorTimer > 0)
        {
            hitIndicatorTimer -= Time.deltaTime;
            if(hitIndicatorTimer <= 0)
            {
                render.material.SetColor("_Color", baseColor);
            }
        }
    }

    public void HurtPlayer(int damagedAmount)
    {
        currentPlayerHealth -= damagedAmount;
        hitIndicatorTimer = hitIndicatorLength;
        render.material.SetColor("_Color", Color.red);
    }

}
