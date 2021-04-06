using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class View : MonoBehaviour
{
    public GameObject TopviewCamera;
    public GameObject CarCamera;
    public GameObject MainCamera;
    public int CameraNumber = 2;
    public float speed;

    //public float m_FieldOfView = 60.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Camera.main.fieldOfView -= Input.GetAxis ("Mouse ScrollWheel")*Time.deltaTime*3000;
        
        /*if(Input.GetAxis("Mouse X")>0)
        {
            CarCamera.transform.position += new Vector3(Input.GetAxisRaw("Mouse X") * Time.deltaTime * speed, 0, Input.GetAxisRaw("Mouse Y") * Time.deltaTime * speed);
        }
        else if (Input.GetAxis("Mouse X") < 0)
        {
            CarCamera.transform.position+= new Vector3(Input.GetAxisRaw("Mouse X") * Time.deltaTime * speed, 0, Input.GetAxisRaw("Mouse Y") * Time.deltaTime * speed);
        }*/
        
        /*if (Input.GetMouseButtonDown(0)) 
        {
            CameraNumber += 1;
        }*/

        if (Input.GetMouseButtonDown(1))
        {
            CameraNumber += 1;
        }

        if (CameraNumber > 3)
        {
            CameraNumber = 1;
        }


        if (CameraNumber < 1)
        {
            CameraNumber = 3;
        }

        CameraViewChange(CameraNumber);

    }

    void CameraViewChange (int counter)
    {
        if (counter == 1)
        {
            TopviewCamera.SetActive(true);
            CarCamera.SetActive(false);
            MainCamera.SetActive(false);
        }
        else if (counter == 2)
        {
            TopviewCamera.SetActive(false);
            CarCamera.SetActive(true);
            MainCamera.SetActive(false);
        }
        else if (counter == 3)
        {
            TopviewCamera.SetActive(false);
            CarCamera.SetActive(false);
            MainCamera.SetActive(true);
        }
    }
}
