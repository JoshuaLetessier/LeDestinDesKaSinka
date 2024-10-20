/*Script permetant de gérer les déplacements du personnages et le lancement des attaques
la partie des dégats est géré par les appels au scripts corespondant
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiocanMove : MonoBehaviour
{
    //déplacement
    public float moveSpeed = 50; //vittesse de déplacements
    public float jumpForce; //force du saut

    private RaycastHit Hit2D; //zone dégagé devant le boss permetant de détecter le joueur

    public bool isJumping;// test de saut
    public bool isGrounded;// test de contacte avec le sol
    //fin déplacement

    //Vie
    public float ptsVie = 100; //point de vie de base
    public float stockPtsVie; //point de vie en cours
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
                print(ptsVie);
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


    /*
     * 
     * 
     * ATTAQUE
     * 
     * 
     */

    private void attackMode()
    {
        

        
        int choixAttaque; 
        int valChoixAttaque;
        choixAttaque = Random.Range(0, 50);
        valChoixAttaque = choixAttaque % 2;

        /*ataque corps à corps*/
        int chanceAttaqueCrit;
        bool lancementAnime;

        /*attaque distance*/
        int chanceAttaqueRange;
       // bool lancementAnimeRange;
        



        if(valChoixAttaque ==1)
        {
            //attaque corps à corps
            chanceAttaqueCrit = Random.Range(0, 3);
            
            if (chanceAttaqueCrit == 0)
            {   //attaque avec effet
                lancementAnime = true;
                StartCoroutine(WaitAttaqueCC(3, lancementAnime));
            }
            else
            {   //attaque sans effet
                lancementAnime = false;
                StartCoroutine(WaitAttaqueCC(3, lancementAnime));
            }

        }

        //attaque à diqtance
        if(valChoixAttaque == 0)
        {
            chanceAttaqueRange = Random.Range(0, 3);
            print(chanceAttaqueRange);
            if(chanceAttaqueRange == 0 || chanceAttaqueRange == 2)
            {
               
                StartCoroutine(WaitAttaqueRange(3));
            }
         
        }

        


        /* boss finale 4 à 5 attaque + un cou spécial
         *choix alléatoire des attaque parmis les classique
         *dégats variables en fonction de l'attaque(si attaque boule de feu type mage possibilité de dupliquer le nb de B donc + de D)
         *temps entre attaque compris entre 5 et 10s
         */
         
    }

    //public bool lancementCoutSpecial

   /* private void coutSpecial()
    {
        if(ptsVie <= stockPtsVie*0.25)
        {

        }
    }*/

    private IEnumerator WaitAttaqueCC(float second, bool test) 
    {
        if(test == true)
        {
            animator.SetInteger("AttackCCEffet", 1);
            DegatAttackCCEffet.instance.lancement();
            yield return new WaitForSeconds(second);
            animator.SetInteger("AttackCCEffet", 0);
        }
        if(test == false)
        {
            animator.SetInteger("AttackCC", 1);
            DegatAttackCC.instance.lancement();
            yield return new WaitForSeconds(second);
            animator.SetInteger("AttackCC", 0);
        }
    }




    private IEnumerator WaitAttaqueRange(float second)
    {
        
            animator.SetInteger("AttackCCEffet", 1);
            //DegatAttackRangeEffet.instance.lancement();
            yield return new WaitForSeconds(second);
            animator.SetInteger("AttackCCEffet", 0);
        

    }

   

    private void defenceMode()
    {
        /*dégat subit variabeles en fonction de l'attaque + un taux d'armure aléatoire
         * qaund ptsVie en desous de 25% bonus d'armure auto de à voir
         * ptsVie à 0, résurection all stat /2*/
         
    }
}