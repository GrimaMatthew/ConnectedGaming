using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleMover : MonoBehaviour
{
    public float speed = 1.5f;

    public static Vector3 circlePosition;

    string intialNameEntered;
    string nameInFirebase;
    // Start is called before the first frame update
    void Start()
    {

        intialNameEntered = GameManager.intialNameP2;
        nameInFirebase = FirebaseController.sGameName2;

    }

    // Update is called once per frame
    void Update()
    {
  
        if (intialNameEntered == nameInFirebase)
        {
            
            circlePosition = transform.position;

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.position += Vector3.left * speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.position += Vector3.right * speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.position += Vector3.up * speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.position += Vector3.down * speed * Time.deltaTime;
            }

        }
       
    }
}
