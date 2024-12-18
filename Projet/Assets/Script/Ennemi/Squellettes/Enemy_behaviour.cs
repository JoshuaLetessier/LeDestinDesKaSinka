﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Enemy_behaviour : MonoBehaviour
{


    public Transform rayCast;
    public LayerMask raycastMask;
    public float rayCastLength;
    public float attackDistance; //Distance minimale pour l'attaque
    public float moveSpeed;
    public float timer; //Minuteur pour le temps de recharge entre les attaques



    private RaycastHit2D hit;
    private GameObject target;
    private Animator anim;
    private float distance; //Stocker la distance entre l'ennemi et le joueur
    private bool attackMode;
    private bool inRange; //Vérifier si le joueur est dans l'intervalle
    private bool cooling; //Vérifier si l'ennemi se refroidit après l'attaque.

    private float intTimer;



    void Awake() //lance l'animation 
    {
        intTimer = timer; //Stocker la valeur initiale dans le minuteur
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (inRange)
        { 
            hit = Physics2D.Raycast(rayCast.position, Vector2.left, rayCastLength, raycastMask); //ligne droite, contact avec le joueur
            RaycastDebugger();
        }

        //Quand le joueur est détecté
        if (hit.collider != null)
        {
            EnemyLogic();
        }
        else if (hit.collider == null)
        {
            inRange = false;
        }

        if (inRange == false)
        {
            anim.SetBool("canWalk", false);
            StopAttack();
        }
    }

    void OnTriggerEnter2D(Collider2D trig)
    {
        if (trig.gameObject.tag == "Player")
        {
            target = trig.gameObject;
            inRange = true;
        }

    }

    void EnemyLogic()
    {
        distance = Vector2.Distance(transform.position, target.transform.position); //deplacement

        if (distance > attackDistance) //attaque de l'ennemi 
        {
            Move();
            StopAttack();
        }
        else if (attackDistance >= distance && cooling == false)
        {
            Attack();
        }

        if (cooling)
        {
            Cooldown();
            anim.SetBool("Attack", false);
        }
    }

    void Move() //deplacement de l'ennemi quand le joueur rentre dans la zone
    {
        anim.SetBool("canWalk", true);

        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Enemy_attack"))
        {
            Vector2 targetPosition = new Vector2(target.transform.position.x, transform.position.y);

            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
    }

    void Attack()
    {
        timer = intTimer; //Réinitialiser la minuterie lorsque le joueur entre dans la zone d'attaque.
        attackMode = true; //Vérifier si l'ennemi peut encore attaquer ou non.

        anim.SetBool("canWalk", false);
        anim.SetBool("Attack", true);
    }

    void Cooldown()
    {
        timer -= Time.deltaTime;

        if (timer <= 0 && cooling && attackMode)
        {
            cooling = false;
            timer = intTimer;
        }
    }

    void StopAttack() 
    {
        cooling = false;
        attackMode = false;
        anim.SetBool("Attack", false);
    }

    void RaycastDebugger() //quand le joueur part du rayon de l'ennemi
    {
        if (distance > attackDistance)
        {
            Debug.DrawRay(rayCast.position, Vector2.left * rayCastLength, Color.red);
        }
        else if (attackDistance > distance)
        {
            Debug.DrawRay(rayCast.position, Vector2.left * rayCastLength, Color.green);
        }
    }

    public void TriggerCooling()
    {
        cooling = true;
    }

}
