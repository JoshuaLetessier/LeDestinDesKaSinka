
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiocanMove : MonoBehaviour
{
    //déplacement
    public float moveSpeed = 50;
    public float jumpForce;

    private RaycastHit Hit2D;

    public bool isJumping;
    public bool isGrounded;
    //fin déplacement

    //Vie
    public float ptsVie = 100;
    public float stockPtsVie;
    //Fin Vie


    //Contenant
    public Rigidbody2D rbR;
    public Collider2D collider2DR;
    public SpriteRenderer spriteRendererR;
    public Animator animator;
    // Fin contenant



    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask collisionLayers;

    private Vector3 velocity = Vector3.zero;
    private float horizontalMovement;

    //Appel
    public static RiocanMove instance;
    //Fin appel

    public int test;


    public bool TPtest;


    public float XT;
    public float YT;

   
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de PlayerMovement dans la scène");
            return;
        }

        instance = this;
    }


    private void Start()
    {
        stockPtsVie = ptsVie;
    }

    private void Update()
    {
        moveSpeed = Random.Range(0,5 );
       

        if(EnterZone.instance.combat == true)
        {
            attackMode();
            if (ptsVie < stockPtsVie * 25 / 100)
            {
                defenceMode();
                //print(ptsVie);
            }
            Flip(rbR.velocity.x);
            WalkAnimation(rbR.velocity.x);
            if (TPtest == true)
            {
                StartCoroutine(WaitTP(1)); //système de tp
                TPtest = false;
            }


        }
        
       
    }

    void WalkAnimation(float _velocity)
    {
        /*if (_velocity >= 0.1f || _velocity <= -0.1f)
        {
            animator.SetBool("Speed", true);
        }
        if (_velocity == 0)
        {
            animator.SetBool("Speed", false);
        }*/
    }
    void Flip(float _velocity)
    {
        if (_velocity > 0.1f)
        {
            spriteRendererR.flipX = false;
        }
        else if (_velocity < -0.1f)
        {
            spriteRendererR.flipX = true;
        }
    }

    void FixedUpdate()
    {
        MoveRiocan(horizontalMovement);
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, collisionLayers);
        horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
    }

    void MoveRiocan(float _horizontalMovement)
    {
        Vector3 targetVelocity = new Vector2(_horizontalMovement, rbR.velocity.y);
        rbR.velocity = Vector3.SmoothDamp(rbR.velocity, targetVelocity, ref velocity, .05f);
    }


    private IEnumerator WaitTP(float second)
    {
        animator.SetInteger("TP", 1);
        yield return new WaitForSeconds(second);
        animator.SetInteger("TP", 0);
        animator.SetInteger("TPRevert", 1);
        transform.position = new Vector3(XT, YT, 0);
        yield return new WaitForSeconds(second);
        animator.SetInteger("TPRevert", 0);
    }



    private void attackMode()
    {
        SpawnPortail();

        
        int choixAttaque;
        int valChoixAttaque;
        choixAttaque = Random.Range(0, 50);
        valChoixAttaque = choixAttaque % 2;

        /*ataque corps à corps*/
        int chanceAttaqueCrit;
        bool test;

        /*attaque distance*/
        int chanceAttaqueRate;
        



        if(valChoixAttaque ==1)
        {
            chanceAttaqueCrit = Random.Range(0, 3);
            //print(chanceAttaqueCrit);
            if (chanceAttaqueCrit == 0)
            {
                test = true;
                StartCoroutine(WaitAttaqueCC(3, test));
            }
            else
            {
                test = false;
                StartCoroutine(WaitAttaqueCC(3, test));
            }

        }
        if(valChoixAttaque == 0)
        {
            chanceAttaqueRate = Random.Range(0, 3);
           // print(chanceAttaqueRate);
            if(chanceAttaqueRate == 0 || chanceAttaqueRate == 2)
            {
                
            }
            else
            {

            }
        }

        


        /* boss finale 4 à 5 attaque + un cou spécial
         *choix alléatoire des attaque parmis les classique
         *dégats variables en fonction de l'attaque(si attaque boule de feu type mage possibilité de dupliquer le nb de B donc + de D)
         *temps entre attaque compris entre 5 et 10s
         *quand ptsVie 75% coup spécial 1     50% coup spécial avec bonus de dégats   25% inflige 500(à voir) de dégats sans tenir compte de l'armure du joueur*/
         
    }

    private IEnumerator WaitAttaqueCC(float second, bool test)
    {
        if(test == true)
        {
            animator.SetInteger("AttackCCEffet", 1);
            yield return new WaitForSeconds(second);
            animator.SetInteger("AttackCCEffet", 0);
        }
        if(test == false)
        {
            animator.SetInteger("AttackCC", 1);
            yield return new WaitForSeconds(second);
            animator.SetInteger("AttackCC", 0);
        }
    }

    public void SpawnPortail()
    {
        float Xstock = EnterZone.instance.transformEZ.localScale.x;
        float Ystock = EnterZone.instance.transformEZ.localScale.y;

        


       
    }

    private void defenceMode()
    {
        /*dégat subit variabeles en fonction de l'attaque + un taux d'armure aléatoire
         * qaund ptsVie en desous de 25% bonus d'armure auto de à voir
         * ptsVie à 0, résurection all stat /2*/
         
    }
}