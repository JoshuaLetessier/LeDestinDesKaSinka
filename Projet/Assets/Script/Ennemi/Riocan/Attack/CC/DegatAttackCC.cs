using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DegatAttackCC : MonoBehaviour
{

    public GameObject box;

    public int dammage;
    public int min;
    public int max;

    public Collider2D haut;
    public Collider2D bas;


    public static DegatAttackCC instance;

    private void Awake()
    {

        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de DegatAttackCCEffet dans la scène");
            return;
        }

        instance = this;
    }


    public void lancement()
    {
        box.SetActive(true);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            PlayerHealth.instance.TakeDamage(dammage);
        }
    }
}
