using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clé : MonoBehaviour
{

    public GameObject key;
    public bool keyfalse = true;

 

    public static Clé instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de PlayerHealth dans la scène");
            return;
        }

        instance = this;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            key.SetActive(false);
            keyfalse = false;
        }
    }
}
