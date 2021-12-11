using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleMover : MonoBehaviour
{
    public float speed = 1.5f;

    public static Vector3 circlePosition;

    string intialNameEntered;
    string nameInFirebase;
    string circleLivePos;


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
        else
        {
            circleLivePos = FirebaseController.player2PosLive;
            this.transform.position = StringToVector3(circleLivePos);

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
        try
        {
            Vector3 result = new Vector3(
                    float.Parse(sArray[0]),
                    float.Parse(sArray[1]),
                    float.Parse(sArray[2]));
            return result;
        }
        catch (Exception e)
        {
            Debug.Log(e + "Error");
        }

        return Vector3.forward;



    }
}
