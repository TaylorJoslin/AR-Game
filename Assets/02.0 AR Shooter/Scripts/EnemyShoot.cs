using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.ProBuilder;

public class EnemyShoot : MonoBehaviour
{
    public Transform player;
    
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float shootingRange = 10f;
    public float shootInterval = 2f;
    public float shootSpeed = 4f;

    private NavMeshAgent navMeshAgent;
    private float timeSinceLastShot = 0f;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        // Check if player is within shooting range
        if (Vector3.Distance(transform.position, player.position) < shootingRange)
        {
            // Update NavMesh Agent destination to follow the player
            navMeshAgent.SetDestination(player.position);

            // Look at the player
            transform.LookAt(player.position);

            // Check shooting interval
            timeSinceLastShot += Time.deltaTime;
            if (timeSinceLastShot >= shootInterval)
            {
                // Shoot at the player
                Shoot();
                timeSinceLastShot = 0f;
            }
        }
    }

    void Shoot()
    {
        // Instantiate bullet at the firePoint position and rotation
        

        GameObject newProjectile = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Vector3 shotVelocity = transform.forward.normalized * shootSpeed;
        newProjectile.GetComponent<Rigidbody>().velocity = shotVelocity;
        
    }
}
