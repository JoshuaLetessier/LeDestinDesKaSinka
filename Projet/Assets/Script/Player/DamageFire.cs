using UnityEngine;

public class DamageFire : MonoBehaviour
{
    public GameObject objectToDestroy;
    public Animator animatorBoule;


    public static DamageFire instance;
    private void Awake()
    {
        instance = this;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ( collision.CompareTag("Monde"))
        {
            animatorBoule.SetBool("Destroy", true);
            Destroy(objectToDestroy,0.2f);
        }

     


    }
}
