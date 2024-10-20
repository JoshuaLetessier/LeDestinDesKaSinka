using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollBouleDeFeu : MonoBehaviour
{

    void OnCollisionEnter(Collision Col)
    {
        Destroy(gameObject);
    }
}
