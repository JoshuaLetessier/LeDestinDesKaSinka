﻿using UnityEngine;

public class Checkpoint : MonoBehaviour
{


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CurrentSceneManager.instance.respawnPoint = transform.position;
           
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

}
