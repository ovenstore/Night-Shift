using System.Data;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;

    void Update()
    {
        // transform.position += Vector3.left * speed * Time.deltaTime;
    }

    // if hit by the broom, die
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Broom"))
        {
            Destroy(gameObject);
        }
    }
}