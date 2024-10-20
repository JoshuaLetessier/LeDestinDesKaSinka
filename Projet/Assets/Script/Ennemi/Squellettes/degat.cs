using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class degat : MonoBehaviour
{
    public int damageOnCollision = 25;

    private void OnCollisionEnter2D(Collision2D collision) // degat de l'ennemi sur le joueur
    {
        if (collision.transform.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.transform.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(damageOnCollision);
        }
    }
}
