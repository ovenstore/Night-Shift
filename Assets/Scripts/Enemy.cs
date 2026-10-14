using System.Data;
using UnityEngine;

public enum EnemyType
{
    Snake, Bat
}

public class Enemy : MonoBehaviour
{
    public float speed;
    public EnemyType enemyType;
    private Player player;

    void Awake()
    {
        player = FindFirstObjectByType<Player>();
    }

    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        // delete the enemy if it goes off of the map
        if (transform.position.x <= -8)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Broom"))
        {
            if (player.highAttacking && enemyType == EnemyType.Bat)
            {
                Destroy(gameObject);
            } 
            
            if (player.lowAttacking && enemyType == EnemyType.Snake)
            {
                Destroy(gameObject);
            }
        }
    }
}