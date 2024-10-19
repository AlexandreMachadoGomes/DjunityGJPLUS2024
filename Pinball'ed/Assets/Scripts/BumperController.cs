using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperController : MonoBehaviour
{


    [SerializeField] private float bumpForceAmmount = 7;


    void OnCollisionEnter(Collision collision)
    {
        GameObject ball = collision.gameObject;

        
        if (ball.CompareTag("pinball"))
        {
            Rigidbody ballRB = ball.GetComponent<Rigidbody>();
            ballRB.velocity += ballRB.velocity.normalized * bumpForceAmmount;
            Debug.Log(ballRB.velocity.magnitude);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {

    }
}
