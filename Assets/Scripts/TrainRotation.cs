using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainRotation : MonoBehaviour
{
   public Transform target;
    public float rotationSpeed = 5f;
    void Update()
    {
        Vector3 direction = target.transform.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }
}
