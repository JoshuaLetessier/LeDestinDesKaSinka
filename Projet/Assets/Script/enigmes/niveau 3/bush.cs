﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bush : MonoBehaviour
{
    public GameObject buisson;
    public GameObject tileMap;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("Player"))
        {
            buisson.SetActive(false);
            tileMap.SetActive(false);
        }
        else if(!collision.transform.CompareTag("Player"))
        {
            buisson.SetActive(true);
            tileMap.SetActive(true);
        }
    }
}
