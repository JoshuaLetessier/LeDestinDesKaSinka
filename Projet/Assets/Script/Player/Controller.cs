using UnityEngine;

using System.Collections;



public class Controller : MonoBehaviour
{
    public float MoveSpeed;
    public float JumpForce;

    public bool isJumping;
    public bool isGrounded;

    public Rigidbody2D rb;
    public Animator animator;
    public CapsuleCollider2D playerCollider;
    public SpriteRenderer spriteRenderer;


    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask collisionLayers;

    public Vector3 velocity = Vector3.zero;
    private float horizontalMovement;

    public static Controller instance;

    public Vector2 TirDirection = Vector2.zero;

    public bool test;

    public AudioClip jumpSound; 
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de Controller dans la scène");
            return;
        }

        instance = this;
    }

    void Start()
    {
        TirDirection = Vector2.right;
    }


    void Update()

    {
        Flip(rb.velocity.x);
        WalkAnimation(rb.velocity.x);

        if (Input.GetKey(ControlManager.GM.left)) // teste si la touche aller à gauche est presser
        {
            transform.position += Vector3.right * Time.deltaTime*MoveSpeed; // déplace le personnage dans la direction voulue
        }

        if (Input.GetKey(ControlManager.GM.right)) // teste si la touche aller à droite est presser
        {
            transform.position += Vector3.left * Time.deltaTime*MoveSpeed;// déplace le personnage dans la direction voulue
        }
        if (Input.GetKeyDown(ControlManager.GM.jump) && isGrounded) // teste si la touche aller sauter est presser
        {
            AudioManager.instance.PlayClipAt(jumpSound, transform.position);// appel au gestionnaire de l'audio pour lancer celui du saut.
            isJumping = true; //permet de bloquer le saut infini.
             Flip(rb.velocity.x); 
            
        }

        /*if(test == true)
        {
            animator.SetBool("Foudre", true);
        }

        if (test == false)
        {
            animator.SetBool("Foudre", false);
        }*/
    }


    void FixedUpdate()
    {
        MovePlayer(horizontalMovement);
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, collisionLayers);
        horizontalMovement = Input.GetAxis("Horizontal") * MoveSpeed * Time.deltaTime;
    }

    void MovePlayer(float _horizontalMovement)
    {

        Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);

        if (isJumping == true)
        {
            rb.AddForce(new Vector2(0f, JumpForce));
            isJumping = false;
        }
    }

    void WalkAnimation(float _velocity)
    {
        if(_velocity >= 0.1f || _velocity <= -0.1f)
        {
            animator.SetInteger("Speed", 1);
        }
        if (_velocity == 0)
        {
            animator.SetInteger("Speed", 0);
        }
    }

    void Flip(float _velocity)
    {
        if (_velocity > 0.1f)
        {
            spriteRenderer.flipX = false;
    
        }
        else if (_velocity < -0.1f)
        {
            spriteRenderer.flipX = true;
  
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }

}