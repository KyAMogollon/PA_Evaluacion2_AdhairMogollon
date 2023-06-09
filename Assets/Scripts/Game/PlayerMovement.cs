﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
public class PlayerMovement : MonoBehaviour
{

    public KeyCode up;
    public KeyCode down;
    private Rigidbody2D myRB;
    [SerializeField]
    private float speed;
    private float limitSuperior;
    private float limitInferior;
    public int player_lives = 4;
    public int player2_lives = 4;
    Vector2 movementPlayer;
    private float velocityModifier = 10f;
    [SerializeField] AudioSource hit;
    Vector3 initialPosition;
    // Start is called before the first frame update
    void Start()
    {
        /*if (up == KeyCode.None) up = KeyCode.UpArrow;
        if (down == KeyCode.None) down = KeyCode.DownArrow;*/
        myRB = GetComponent<Rigidbody2D>();
        SetMinMax();
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        myRB.velocity = movementPlayer * velocityModifier;
        /*if (Input.GetKey(up) && transform.position.y < limitSuperior)
        {
            myRB.velocity = new Vector2(0f, speed);
        }
        else if (Input.GetKey(down) && transform.position.y > limitInferior)
        {
            myRB.velocity = new Vector2(0f, -speed);
        }
        else
        {
            myRB.velocity = Vector2.zero;
        }*/
        transform.position = new Vector2(transform.position.x, Mathf.Clamp(transform.position.y, limitInferior, limitSuperior));
    }

    void SetMinMax()
    {
        Vector3 bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        limitInferior = -bounds.y;
        limitSuperior = bounds.y;
    }
    public void OnMovement(InputAction.CallbackContext value)
    {
        Vector2 inputMovement = value.ReadValue<Vector2>();
        movementPlayer = new Vector2(0, inputMovement.y);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Candy")
        {
            CandyGenerator.instance.ManageCandy(other.gameObject.GetComponent<CandyController>(), this);
        }else if (other.gameObject.tag == "Enemy")
        {
            transform.position = initialPosition;
            player_lives = player_lives - 1;
            player2_lives = player2_lives - 1;
            Destroy(other.gameObject);
            hit.Play();
        }
    }
}
