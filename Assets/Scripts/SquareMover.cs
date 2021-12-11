using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareMover : MonoBehaviour
{
    public float speed = 1.5f;

    public static Vector3 SquarePosition;
    string intialNameEntered;
    string nameInFirebase;
    // Start is called before the first frame update
    void Start()
    {
        intialNameEntered = GameManager.intialName;
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

    }
}
