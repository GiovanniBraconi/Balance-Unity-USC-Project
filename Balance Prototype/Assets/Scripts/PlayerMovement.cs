﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontalInput;
    private float speed = 20.0f;
    private float xRangePos = 11;
    private float xRangeNeg = -7;
    private GameManager gameManager;
    private bool hasPowerup;
    private GameObject[] GOs;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        hasPowerup = true;
    }

    private void OnTriggerEnter(Collider other)
    {

        gameManager.GameOver();
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (hasPowerup)
            {
                hasPowerup = false;
                GameObject[] GOs = GameObject.FindGameObjectsWithTag("Flames");
                // now all your game objects are in GOs,
                // all that remains is to getComponent of each and every script and you are good to go.
                // to disable a components
                for (var i = 0; i < GOs.Length; i++)
                {
                    // to access component - GOs[i].GetComponent.<BoxCollider>()
                    // but I do it everything in 1 line.
                    GOs[i].gameObject.SetActive(false);
                }
            }

            }
        
            // Check for left and right bounds
            if (transform.position.x < xRangeNeg)
            {
                transform.position = new Vector3(xRangeNeg, transform.position.y, transform.position.z);
            }

            if (transform.position.x > xRangePos)
            {
                transform.position = new Vector3(xRangePos, transform.position.y, transform.position.z);
            }

            // Player movement left to right
            horizontalInput = Input.GetAxis("Horizontal");
            transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);

        }
    }

