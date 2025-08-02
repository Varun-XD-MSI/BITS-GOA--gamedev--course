using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting;
using UnityEngine.UIElements;


public class Controls : MonoBehaviour
{
    public float rot_speed, move_speed, boost_up;
    public Transform cartransform;
    private float org_speed;



    // Update is called once per framed
    void Update()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");  //"Horizontal": A/D or Left/Right → values: -1 to 1
        float verticalMovement = Input.GetAxis("Vertical");      //"Vertical": W/S or Up/Down → values: -1 to 1  


        // Debug.Log("horizontal:" + horizontalMovement + "vertical:" + verticalMovement);
        if (Mathf.Abs(horizontalMovement) > 0.01f)
        {

            cartransform.Rotate(0f, 0f, -1 * rot_speed * horizontalMovement * Time.deltaTime);  //Rotate() rotates the car's transform around the Z-axis (since it’s 2D).
        }  //-1 * horizontalMovement: negative makes right input turn car clockwise

        if (Mathf.Abs(verticalMovement) > 0.01f)
        {
            cartransform.Translate(0f, move_speed * verticalMovement * Time.deltaTime, 0f); //Translate() moves the car along its local Y-axis (forward direction).

        }

    }



    void OnCollisionEnter2D(Collision2D collision)
    {
        // Debug.Log("oops you hit something");
        if (collision.gameObject.tag == "RedHouse")
        {
            Debug.Log("Oops!! , You hit the red house!");

        }
        if (collision.gameObject.tag == "BlueHouse")
        {
            Debug.Log("Oops!! , You hit the Blue house!");

        }



    }



    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Booster")
        {
            StartCoroutine(Speed());
            
            Destroy(other.gameObject);
        }

    }


    IEnumerator Speed()
    {
        org_speed = move_speed;
        move_speed = move_speed * boost_up;
        yield return new WaitForSeconds(0.5f);
        move_speed = org_speed;
         

    }
    
    
        
    


}
