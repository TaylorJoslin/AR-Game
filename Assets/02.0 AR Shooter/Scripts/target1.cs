using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class target1 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);
        
    }

    
}
