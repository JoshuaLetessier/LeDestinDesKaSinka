using UnityEngine;

public class DeathZone : MonoBehaviour
{
    public static DeathZone instance;

    private void Awake()
    {
        if (instance != null)
        {
            //Debug.LogWarning("Il y a plus d'une instance de DeathZone dans la scène");
            return;
        }

        instance = this;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerHealth.instance.TakeDamage(PlayerHealth.instance.maxHealth);
            //Checkpoint.instance.OnTriggerEnter2D(collision);
           
        }
    }
}
