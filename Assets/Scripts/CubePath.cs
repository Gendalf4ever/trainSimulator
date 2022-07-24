using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubePAth : MonoBehaviour
{
    public Vector3 direction;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(direction * Time.deltaTime);
    }
}
