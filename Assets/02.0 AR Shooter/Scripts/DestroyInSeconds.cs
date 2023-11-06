using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyInSeconds : MonoBehaviour
{
    public GameObject bullet;
   

    private void Awake()
    {
        DestroyObjectDelayed();
    }

    public void DestroyObjectDelayed()
    {
        
        Destroy(bullet, 2);
    }
}
