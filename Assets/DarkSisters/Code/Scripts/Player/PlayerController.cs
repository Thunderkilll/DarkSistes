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
    public AudioSource audio;
    public GameObject prefab;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        numberOfJumpsValue = numberOfJumps;
    }

    // Update is called once per frame
    void Update()
    {
        resetPlayer();
        //MovementControlls();
        
    }

    void OnCollisionEnter(Collision collision)
    {
        //touching the ground 
        if (collision.gameObject.tag == "Ground")
        {
            numberOfJumps = numberOfJumpsValue;
            
        }
        // upper boundaries == death
        if (collision.gameObject.tag == "boundaries")
        {
            Time.timeScale = 0f;
            Debug.Log("game over for player / respawn");
           
        }
        // picking up a sword 
        if (collision.gameObject.tag == "Weapon")
        {
            Destroy(collision.gameObject); //destroy the new weapon 
            GameObject weaponHolder =  gameObject.transform.GetChild(0).gameObject ; // get the weaponholder
            Vector3 offset = new Vector3(.5f,0,-4f); //just an offset for a bug that need to be fixed 
            GameObject o = Instantiate(prefab, weaponHolder.transform.position + offset , Quaternion.identity); //initiate the new weapon in our hands 
            o.transform.SetParent(weaponHolder.transform); //set weapon holder as parent
            
        }

    }

    //reset player life 
    public void resetPlayer(){

        if (Time.timeScale == 0f)
        {
            if (Input.GetKeyDown(KeyCode.M))
            {

                gameObject.transform.position = new Vector3(0, 1, 0);
                Debug.Log(gameObject.transform.position);
                Time.timeScale = 1f;
            }

        }
        else
        {
            MovementControlls();
        }
    }


    //movement code
    public void MovementControlls()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            rb.AddForce(Vector3.forward * speed * 50 * Time.deltaTime, ForceMode.Acceleration);

        }
        if (Input.GetKey(KeyCode.Q))
        {
            rb.AddForce(Vector3.left * speed * 50 * Time.deltaTime, ForceMode.Acceleration);

        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(Vector3.back * speed * 50 * Time.deltaTime, ForceMode.Acceleration);

        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Vector3.right * speed * 50 * Time.deltaTime, ForceMode.Acceleration);

        }
        if (Input.GetKeyDown(KeyCode.Space) && (numberOfJumps != 0))
        {

            audio.Play();
            rb.AddForce(Vector3.up * jump * 50 * Time.deltaTime, ForceMode.Impulse);

            numberOfJumps--;
        }


    }
}