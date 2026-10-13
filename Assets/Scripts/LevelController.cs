using UnityEngine;

public class LevelController : MonoBehaviour
{
    public int difficulty1;
    public int difficulty2;
    public int maxEnemies1;
    public int maxEnemies2;

    public GameObject bat;
    public GameObject snake;

    private Camera cam;
    private int spawnTimer = 0;
    private int spawnInterval = 100;
    private int maxEnemies = 0;

    void Start()
    {
        cam = Camera.main;

        switch(GameState.currentLevel)
        {
            case 1:
                spawnInterval = 100 / difficulty1;
                maxEnemies = maxEnemies1;
                break;
            case 2:
                spawnInterval = 100 / difficulty2;
                maxEnemies = maxEnemies2;
                break;
            default:
                Debug.Log("Couldn't set spawn odds, wrong game state");
                break;
        }
    }

    void FixedUpdate()
    {
        spawnTimer += 1;

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        // check that the timer is greater than the spawn interval and that we haven't exceeded the max number of enemies
        if (spawnTimer >= spawnInterval && enemies.Length < maxEnemies)
        {
            // get the x value 2 units right of the camera right edge
            float spawnX = 2 + cam.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;

            // ensure that we aren't spawning on top of any previous enemies
            foreach (GameObject enemy in enemies) {
                if (Mathf.Abs(spawnX - enemy.transform.position.x) < 2)
                {
                    spawnX += 2;
                }
            }

            // check that spawnX is still within the level bounds 
            if (spawnX < 52)
            {
                SpawnEnemy(spawnX);
            }

            spawnTimer = 0;
        }
    }

    void SpawnEnemy(float spawnX)
    {
        // randomly spawn either a bat or a snake
        if (Random.value > 0.5f)
        {
            Vector3 batSpawn = new Vector3(spawnX, 0.5f, 0f);
            Instantiate(bat, batSpawn, Quaternion.identity);
        }
        else
        {
            Vector3 snakeSpawn = new Vector3(spawnX, -1.8f, 0f);
            Instantiate(snake, snakeSpawn, Quaternion.identity);
        }
    }
}
