using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Rigidbody player;
    public float speed;
    // Update is called once per frame
    void Update()
    {
        player.velocity = transform.forward * speed;

    }

    private void OnCollisionEnter(Collision collision)
    {
        Time.timeScale = 0;
    }
}
