using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    public Rigidbody player;
    public float speed;
   

    private void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        player.velocity = transform.forward * speed;

    }

    
}
