using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    public GameObject gameOverText;
    public GameObject restartButon;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            gameOverText.SetActive(true);
            restartButon.SetActive(true);
            Time.timeScale = 0;
        }

        if (other.gameObject.tag == "EnemyBullet")
        {
            gameOverText.SetActive(true);
            Time.timeScale = 0;
        }
            
    }
}
