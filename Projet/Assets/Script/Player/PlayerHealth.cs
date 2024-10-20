using UnityEngine;
using System.Collections;


public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;

    public float invincibilityTimeAfterHit = 3f;
    public float invincibilityFlashDelay = 0.2f;
    public bool isInvincible = false;

    public CapsuleCollider2D playerCollider;

    public SpriteRenderer graphics;


    public static PlayerHealth instance;

    public GameObject physicHeakthBar;
    public GameObject player;

    public AudioClip hitSound;
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
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(20);
        }
    }
    
    public void HealPlayer(int amount)
    {
        if ((currentHealth + amount) > maxHealth)
        {
            currentHealth = maxHealth;
        }
        else
        {
            currentHealth += amount;
        }

       healthBar.SetHealth(currentHealth);

    }
   

    public void TakeDamage(int damage)
    {
        AudioManager.instance.PlayClipAt(hitSound, transform.position);
        if (isInvincible == true)
        {
            damage = 0;
        }

        else
        {
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);

            //vérifier que le joueur est tjr vivant
            if (currentHealth <= 0)
            {
                Die();
                return;
            }

            isInvincible = true;


            StartCoroutine(InvincibilityFlash());
            StartCoroutine(HandleInvincibilityDelay());
        }

    }



    public void Die()
    {
        Controller.instance.enabled = false;
        //PlayerMovement.instance.animator.SetTrigger("Die");
        Controller.instance.rb.bodyType = RigidbodyType2D.Kinematic;
        Controller.instance.rb.velocity = Vector3.zero;
        Controller.instance.playerCollider.enabled = false;
        GameOverManager.instance.OnPlayerDeath();
        physicHeakthBar.SetActive(false);

    }
    
    public void Respawn()
    {
        Controller.instance.enabled = true;
        //PlayerMovement.instance.animator.SetTrigger("Respawn");
        Controller.instance.rb.bodyType = RigidbodyType2D.Dynamic;
        Controller.instance.playerCollider.enabled = true;
        currentHealth = maxHealth;
        healthBar.SetHealth(currentHealth);
        
    }
    

    public IEnumerator InvincibilityFlash()
    {
        while (isInvincible)
        {
            
            graphics.color = new Color(1f, 1f, 1f, 0f);
            yield return new WaitForSeconds(invincibilityFlashDelay);
            graphics.color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(invincibilityFlashDelay);
        }
    }

    public IEnumerator HandleInvincibilityDelay()
    {
        yield return new WaitForSeconds(invincibilityTimeAfterHit);
        isInvincible = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.position = GameObject.FindGameObjectWithTag("PlayerSpawn").transform.position;
        }
    }
}