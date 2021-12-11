using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareMover : MonoBehaviour
{
    public float speed = 1.5f;

    public static Vector3 SquarePosition;
    string intialNameEntered;
    string nameInFirebase;
    string liveSquarePos;

    
    // Start is called before the first frame update
    void Start()
    {
        intialNameEntered = GameManager.intialNameP1;
        nameInFirebase = FirebaseController.sGameName1;


    }

    // Update is called once per frame
    void Update()
    {

        if (intialNameEntered == nameInFirebase)
        {
            SquarePosition = transform.position;

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
        else
        {
            liveSquarePos = FirebaseController.player1PosLive;
            Debug.Log(liveSquarePos);
          
        }

    }

    public static Vector3 StringToVector3(string sVector)
    {
        // Remove the parentheses
        if (sVector.StartsWith("(") && sVector.EndsWith(")"))
        {
            sVector = sVector.Substring(1, sVector.Length - 2);
        }

        // split the items
        string[] sArray = sVector.Split(',');

        // store as a Vector3
        Vector3 result = new Vector3(
            float.Parse(sArray[0]),
            float.Parse(sArray[1]),
            float.Parse(sArray[2]));

        SquarePosition = new Vector3(float.Parse(sArray[0]), float.Parse(sArray[1]), float.Parse(sArray[0]) );

        return result;
    }
}
