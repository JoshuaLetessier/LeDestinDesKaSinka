using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ennemiePatrolRandom : MonoBehaviour
{

    private RaycastHit Hit2D;
    public int speed;
    public SpriteRenderer graphics;
    private void Start()
    {
        graphics.flipX = !graphics.flipX;
    }
    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left),out Hit2D,1))
        {
            transform.Rotate(Vector3.forward * Random.Range(90, 180));
        }
    }




















    /* public float speed;
     public Transform[] waypoints;

     public int damageOnCollision = 20;

     public SpriteRenderer graphics;
     private Transform point;
     private int destPoint = 0;
     private int nbWaiPoints;





     void Start()
     {
         graphics.flipX = !graphics.flipX;
         point = waypoints[nbWaiPoints];
     }


     void Update()
     {
         Vector3 dir = point.position - transform.position;
         transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);





         if (Vector3.Distance(transform.position, point.position) > 0.3f)
             {
                 int value;
                 value = Random.Range(0, nbWaiPoints);

                 destPoint = (value) % waypoints.Length;
                 point = waypoints[destPoint];
                 graphics.flipX = !graphics.flipX;
             }


     }*/


}