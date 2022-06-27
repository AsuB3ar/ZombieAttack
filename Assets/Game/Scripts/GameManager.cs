using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject Enemy;
    public GameObject GameOverMenu;
    public GameObject MenuBG;
    public EnemyScript enemy;
    public PlayerScript player;


    public Text killDisplay;
    public Text levelDisplay;

    public bool isSpawn = false;

    public float spawnTimer;
    public float spawnCooldown;

    private Renderer r;


    // Start is called before the first frame update
    void Start()
    {
        spawnCooldown = (spawnTimer / player.Level) * 2;
        r = MenuBG.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        killDisplay.text = player.Kill.ToString();
        levelDisplay.text = player.Level.ToString();
        if(isSpawn == true)
        {
            if(spawnCooldown > 0)
            {
                spawnCooldown -= Time.deltaTime;
            }

            if(spawnCooldown <= 0)
            {
                SpawnEnemy();
                spawnCooldown = (spawnTimer / player.Level) * 2;
            }
        }
    }
    void SpawnEnemy()
    {
        float enemySpawnRangeX = Random.Range(-12f, 12f);
        float enemySpawnRangeZ = Random.Range(-15f, 15f);
        Instantiate(Enemy, new Vector3(enemySpawnRangeX, 1f, enemySpawnRangeZ), Quaternion.identity);
    }

    public void GameOver()
    {
        GameOverMenu.SetActive(true);
        Time.timeScale = 0;
    }
}
