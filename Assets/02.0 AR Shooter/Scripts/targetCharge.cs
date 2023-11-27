using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetCharged : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Charged")
            Destroy(this.gameObject);
        ScoreSystem.instance.AddPoints();
    }


}
