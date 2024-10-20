using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    public Animator porte;
    public BoxCollider2D box;
    public bool col;

    public static Door instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de AudioManager dans la scène");
            return;
        }

        instance = this;
    }


    public void Start()
    {
        porte.SetBool("StopClose", true);
    }

    public void Update()
    {


    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player")|| collision.transform.CompareTag("Caisse"))
        {
            col = true;
            StartCoroutine(GestionPorte(col));
           // print("1");




        }
       /* else
        {
            StartCoroutine(GestionFermeture(col));
        }*/

    }

    private IEnumerator GestionPorte(bool test)
    {
        if (col == true)
        {
            porte.SetBool("Open", true);
            //print("S'ouvre");
            yield return new WaitForSeconds(1f);
            porte.SetBool("Open", false);
            porte.SetBool("StopOpen", true);
            //box.isTrigger = true;
            //print("reste S'ouvre");
            //yield return new WaitUntil(() => test = !true);
            yield return new WaitForSeconds(5f);
            porte.SetBool("StopOpen", false);
            //print("test");


            porte.SetBool("StopOpen", false);
            porte.SetBool("Close", true);
            //print("Se ferme");
            yield return new WaitForSeconds(2f);
            porte.SetBool("Close", false);
            porte.SetBool("StopClose", true);
            //print("reste fermé");
            //yield return new WaitUntil(() => test = !false);
            yield return new WaitForSeconds(5f);
            porte.SetBool("StopClose", false);

        }

    }
    /*
    private IEnumerator GestionFermeture(bool test)
    {
        if (porte.GetBool("StopClose") == true)
        {
            porte.SetBool("StopClose", true);
        }
        else
        {
            porte.SetBool("StopOpen", false);
            porte.SetBool("Close", true);
            print("Se ferme");
            yield return new WaitForSeconds(2f);
            porte.SetBool("Close", false);
            porte.SetBool("StopClose", true);
            print("reste fermé");
            //yield return new WaitUntil(() => test = !false);
            yield return new WaitForSeconds(5f);
            porte.SetBool("StopClose", false);
        }
    }*/

private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Trigger!");
    }

}
