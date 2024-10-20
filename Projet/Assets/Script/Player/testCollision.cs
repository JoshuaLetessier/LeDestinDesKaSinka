using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testCollision : MonoBehaviour
{
    public Collider mur;
    private void OnCollisionEnter2D(Collision2D collision) // le joueur prend des degats quand il le touche 
    {
        if (collision.transform.CompareTag("Player"))
        {
            mur.isTrigger = false;
        }
    }/*zer*/
}
