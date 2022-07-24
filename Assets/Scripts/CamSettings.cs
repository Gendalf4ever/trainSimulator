using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CamSettings : MonoBehaviour
{
    Quaternion originRotation;
     float angle;
    float mouseSense = 5;
    float mouseX;
    // Start is called before the first frame update
    void Start()
    {
       originRotation = transform.rotation;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
      mouseX+= Input.GetAxis("Mouse X") * mouseSense;
       Quaternion rotationY = Quaternion.AngleAxis(mouseX,Vector3.up);
       transform.rotation = originRotation * rotationY;
    }
}
