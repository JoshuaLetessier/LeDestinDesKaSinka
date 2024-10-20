using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnPortal : MonoBehaviour
{

    public GameObject Projectil;
    public GameObject[] ZonePortal = new GameObject[10];


    public int nbPortal;
    public int valspawn;

   

    public static SpawnPortal instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de PlayerMovement dans la scène");
            return;
        }

        instance = this;
    }


    void Update()
    {

      
        if (EnterZone.instance.combat == true)
        {
            print("val");
            while (nbPortal < 10)
            {
                

                valspawn = Random.Range(0, 10);
                
                
                ZonePortal[valspawn].SetActive(true);
            
                if(ZonePortal[valspawn])
                {
                  
                    MoveZonePoral.instance.speed = 0;
                }
                

                GameObject Portal = Instantiate(Projectil, ZonePortal[valspawn].transform.position, Quaternion.identity) as GameObject;
                nbPortal += 1;


            }


        }


    }


}
