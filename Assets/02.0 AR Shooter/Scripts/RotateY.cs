using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateY : MonoBehaviour
{
    public GameObject GameObject;
    public float speed;

    // Update is called once per frame
    void Update()
    {

        gameObject.transform.Rotate(0.0f, speed, 0.0f);
    }
}
