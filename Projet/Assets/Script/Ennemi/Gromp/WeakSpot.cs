using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WeakSpot : MonoBehaviour
{
    public GameObject objectToDestroy;
    public AudioClip killSound;

    private void OnTriggerEnter2D(Collider2D collision) //quand le  joueur touche la tete de l'ennemie, l'ennemie est tué 
    {
        if (collision.CompareTag("Attaque") || collision.CompareTag("Player"))
        {
             StartCoroutine(Death());           
        }
    }

    private IEnumerator Death()
    {
        //animator.setBool("Death", 1);
        AudioManager.instance.PlayClipAt(killSound, transform.position);
        yield return new WaitForSeconds(1);
        Destroy(objectToDestroy);
    }
}
