using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterZone : MonoBehaviour
{
    public static EnterZone instance;
    public Transform transformEZ;
    public bool combat = false;//si player rentre dans zone passe à 1 et lance le script du boss
    //mettre en privé après test

     public GameObject portal;

    private void Awake()
    {
       

        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de PlayerMovement dans la scène");
            return;
        }

        instance = this;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            combat = true;
            portal.SetActive(true);
            


        }
    }

}
