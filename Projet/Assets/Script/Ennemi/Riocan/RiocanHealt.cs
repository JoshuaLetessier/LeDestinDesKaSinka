using UnityEngine;
using System.Collections;


public class RiocanHealt : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

  


    public BoxCollider2D riocanCollider;

    public SpriteRenderer graphics;


    public static RiocanHealt instance;

    public bool dommageNow = false;

    public GameObject bossBocks; // hiérarchie du boss
    


    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de PlayerHealth dans la scène");
            return;
        }

        instance = this;
    }

    void Start()
    {
        currentHealth = maxHealth;
       
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            TakeDamage(20);
        }
    }

    public void HealRiocan(int amount)
    {
        if ((currentHealth + amount) > maxHealth)
        {
            currentHealth = maxHealth;
        }
        else
        {
            currentHealth += amount;
        }

      

    }

    public void TakeDamage(int damage)
    {

        currentHealth -= damage;
        dommageNow = true;



        if (currentHealth <= 0)
        {
            Destroy(bossBocks);
        }



    }


}