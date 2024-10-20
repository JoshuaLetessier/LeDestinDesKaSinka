using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DeathChauffeFurrie : MonoBehaviour
{
    public GameObject objectToDestroy;
    //public AudioClip killSound;
    public bool test = true;

    private void Update()
    {
        if (test == true)
        {
            Destroy(objectToDestroy);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) //quand le  joueur touche la tete de l'ennemie, l'ennemie est tué 
    {
       
        if (collision.CompareTag("Attaque") || collision.CompareTag("Player"))
        {
            print("chauffe");
            StartCoroutine(Death());
        }

        

    
    }

    private IEnumerator Death()
    {
        //animator.setBool("Death", 1);
        // AudioManager.instance.PlayClipAt(killSound, transform.position);
        print("chauffe1");
        yield return new WaitForSeconds(1);
        Destroy(objectToDestroy);
    }
}
