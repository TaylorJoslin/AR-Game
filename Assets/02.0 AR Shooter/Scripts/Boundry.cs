using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundry : MonoBehaviour
{
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("boundry"))
        {
            
            transform.rotation = Quaternion.LookRotation(transform.forward * -1);
        }
    }
}
