using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float velocity = 2f;
    public float angularVelocity = 20f;
    public Rigidbody rb;
    float jumpForce = 200f;
    public GameObject[] Wheels;
    public Animator carAnim;

    // Start is called before the first frame update
    void Start()
    {
        Wheels = GameObject.FindGameObjectsWithTag("Wheel");
        rb = GetComponent<Rigidbody>();
        carAnim = GetComponent<Animator>();
        //StartCoroutine(Jump(2));
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * Time.deltaTime * velocity;
            carAnim.SetBool("Foward", true);
            /*foreach (var i in Wheels)
                i.transform.Rotate(-Vector3.right * 10*angularVelocity * Time.deltaTime, Space.Self);*/
        }
        else
        {
            carAnim.SetBool("Foward", false);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= transform.forward * Time.deltaTime * velocity;
            carAnim.SetBool("Backward", true);
            /*foreach (var i in Wheels)
                i.transform.Rotate(Vector3.right * 10*angularVelocity * Time.deltaTime, Space.Self);*/
        }
        else
        {
            carAnim.SetBool("Backward", false);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.rotation *= Quaternion.Euler(0f, angularVelocity * Time.deltaTime, 0f);
            carAnim.SetBool("Right", true);
        }
        else
        {
            carAnim.SetBool("Right", false);
        }
        
        if (Input.GetKey(KeyCode.A))
        {
            transform.rotation *= Quaternion.Euler(0f, -angularVelocity * Time.deltaTime, 0f);
            carAnim.SetBool("Left", true);
        }
        else
        {
            carAnim.SetBool("Left", false);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            carAnim.enabled = false;
            rb.AddForce(Vector3.up * jumpForce * 2, ForceMode.Impulse);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
           StartCoroutine(Jump(2));
        }
        
    }
    
    IEnumerator Jump(float time)
    { 
        carAnim.enabled = false;
        rb.AddForce(Vector3.up * jumpForce * 2, ForceMode.Impulse);
        yield return new WaitForSeconds(time);
        carAnim.enabled = true;
    }
}

