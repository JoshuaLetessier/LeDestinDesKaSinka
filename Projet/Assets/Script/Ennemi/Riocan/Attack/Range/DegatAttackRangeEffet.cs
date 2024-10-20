using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DegatAttackRangeEffet : MonoBehaviour
{
    public GameObject box;

    public int dammage;
    public int min;
    public int max;

    public Collider2D haut;



    public static DegatAttackRangeEffet instance;
    private void Awake()
    {
        instance = this;
    }


    public void lancement()
    {
        box.SetActive(true);
        dammage = Random.Range(min, max);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            PlayerHealth.instance.TakeDamage(dammage);
        }
    }
}
