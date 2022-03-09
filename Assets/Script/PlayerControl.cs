using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    
    private Rigidbody rb; //private variable Rigidbody rd - attached to object to make it move 
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); //initialise rigibody
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //to catch the input of this game from the user
        //to move the ball left and right (horizontal - A,D,<,>), up and down (vertical - W,S,^,V):
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        //then create a vector to record movement:
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        //to add the movement of the ball/object:
        //to add a force vector to a rigidbody:
        rb.AddForce(movement * speed);
        //to make this force more flexible, can add one more public variable 'speed'
        //- will be shown in inspector panel since it is 'public':
    }

    //to set the pickup items as invisible once the ball hits them
    //OnTriggerEnter is the default function of Unity3D: to detect the collision between objects. 
    void OnTriggerEnter(Collider other)
    {
        //check if the object entering (the ball) is "Pick Up"
        //if it is "Pick Up", then we need to set SetActive as false and the object will become invisible
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
        }
    }
}
