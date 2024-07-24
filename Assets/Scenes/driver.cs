using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class driver : MonoBehaviour
{
    [SerializeField] float steerSpeed =  1f;
    [SerializeField] float moveSpeed = 0.1f;
    [SerializeField] float boostSpeed = 30f;
    [SerializeField] float slowSpeed = 15f;

    void Start()
    {
      
    }
      

    void Update()
    {
       float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
       float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime ;
       transform.Rotate(0 , 0 , -steerAmount ); //ใส่ f ดพราะว่า 0.1 เป็นfloat
       transform.Translate( 0 , moveAmount, 0);
    }
     void OnTriggerEnter2D(Collider2D other)
    { 
      if (other.tag == "speed")
      {
        moveSpeed = boostSpeed;
        Debug.Log("crazy drive");
      }
      if (other.tag == "bump")
      {
        moveSpeed = slowSpeed;
      }
    }

}
