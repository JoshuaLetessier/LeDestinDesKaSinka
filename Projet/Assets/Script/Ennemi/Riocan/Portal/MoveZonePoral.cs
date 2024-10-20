using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveZonePoral : MonoBehaviour
{
    public float speed;
    public Transform[] waypoints;

    public int damageOnCollision = 20;

    //public SpriteRenderer graphics;
    private Transform target;
    private int destPoint = 0;

    public static MoveZonePoral instance;
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        target = waypoints[0];
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position; //direction
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World); //deplacement 

        // Si l'ennemi est quasiment arrivé à sa destination
        if (Vector3.Distance(transform.position, target.position) < 0.3f)
        {
            destPoint = (destPoint + 1) % waypoints.Length;
            target = waypoints[destPoint]; //l'endroit ou laquelle on se dirige
            //graphics.flipX = !graphics.flipX;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) // le joueur prend des degats quand il le touche 
    {
        if (collision.transform.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.transform.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(damageOnCollision);
        }
    }
}
