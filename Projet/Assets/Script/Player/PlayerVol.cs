using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVol : MonoBehaviour
{
    public GameObject potion;
    public float time;

    public Transform target;

    public static PlayerVol instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de PlayerHealth dans la scène");
            return;
        }

        instance = this;
    }

    private void Update()
    {
 
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            int i = 0;
            while(i<30)
            {
                potion.SetActive(false);
                Controller.instance.JumpForce = 1000;
                i++;
            }
            potion.SetActive(false);
            Controller.instance.JumpForce = 350;

        }

    }
}
