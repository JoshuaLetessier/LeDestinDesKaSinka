using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarRiocan : MonoBehaviour
{
    public static HealthBarRiocan instance;
 

    public float dammage;
    
    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("Il a plus d'une instance de HealthBarRiocan dans la scène");
            return;
        }
        instance = this;
    }


    void Update()
    {
        
        if(RiocanHealt.instance.dommageNow == true)
        {
           // firstHeath.transform.localScale.x -= dammage / taille; 
        }
    }


   
}
