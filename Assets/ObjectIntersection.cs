using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ObjectIntersection : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.rotation *= Quaternion.Euler(0,150*Time.deltaTime,0);
    }
    
    void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Barrier")
        {
           
            Instantiate(this.gameObject, new Vector3(Random.Range(-4.5f, 4.5f), 0.2f, Random.Range(-4.5f, 4.5f)),
                Quaternion.Euler(30, 0, 0));
            Destroy(this.gameObject);
        }
        
    }
}
