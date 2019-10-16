using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    public float speed;
    public float jump;
    public int numberOfJumps;
    private int numberOfJumpsValue;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        numberOfJumpsValue = numberOfJumps;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0f)
        {
           if (Input.GetKeyDown(KeyCode.M)) {
                
                gameObject.transform.position = new  Vector3(0, 1, 0);
                Debug.Log(gameObject.transform.position);
                Time.timeScale = 1f;
            }
            
        }
        if (Input.GetKey(KeyCode.Z))
        {
            rb.AddForce(Vector3.forward * speed * 50 * Time.deltaTime, ForceMode.Acceleration);
            print("Z");
        }
        if (Input.GetKey(KeyCode.Q))
        {
            rb.AddForce(Vector3.left * speed * 50 * Time.deltaTime, ForceMode.Acceleration);
            print("Q");
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(Vector3.back * speed * 50 * Time.deltaTime, ForceMode.Acceleration);
            print("S");
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Vector3.right * speed * 50 * Time.deltaTime, ForceMode.Acceleration);
            print("D");
        }
        if (Input.GetKeyDown(KeyCode.Space) && (numberOfJumps != 0))
        {
            rb.AddForce(Vector3.up * jump * 50 * Time.deltaTime, ForceMode.Impulse);
            print("Jumpe");
            numberOfJumps--;
        }


    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            numberOfJumps = numberOfJumpsValue;
            print("collided");
        }
        if (collision.gameObject.tag == "boundaries")
        {
            Time.timeScale = 0f;
            Debug.Log("game over for player / respawn");
           
        }

    }
}