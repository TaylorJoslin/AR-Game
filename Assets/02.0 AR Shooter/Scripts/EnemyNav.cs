using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;

using UnityEngine;
using UnityEngine.AI;

public class EnemyNavMesh : MonoBehaviour
{
    public NavMeshAgent Agent;
    public GameObject player;

    public LayerMask whatIsGround, whatIsPlayer;
    //public AudioClip PlayerAttacked;
   // public SpriteRenderer sr;
    public float KnockbackForce;
    //public Animator ani;

    //patrolling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //attacking
    public float timeBetweenAttacks;
    bool hasAttacked;

    //states
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
        Agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        //check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);



        if (!playerInSightRange && !playerInAttackRange)
        {
            Patroling();
           // ani.SetTrigger("idle");
        }

        if (playerInSightRange && !playerInAttackRange)
        {
            ChasePlayer();
           // ani.SetTrigger("run");
        }

        if (playerInSightRange && playerInAttackRange)
        {
            AttackPlayer();
           // ani.SetTrigger("atk");
            //ani.SetTrigger("run");
        }



    }



    private void Patroling()
    {
        if (!walkPointSet)
        {
            SearchWalkPoint();
        }

        if (walkPointSet)
        {
            Agent.SetDestination(walkPoint);
        }

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
        {
            walkPointSet = false;
        }
    }

    private void SearchWalkPoint()
    {
        //calculate random point in range to walk to
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
        {
            walkPointSet = true;
        }
    }

    private void ChasePlayer()
    {
        Agent.SetDestination(player.transform.position);
    }

    private void AttackPlayer()
    {
        Agent.SetDestination(transform.position);

        transform.LookAt(player.transform);

        if (!hasAttacked)
        {
            Debug.Log("ATTACK");
            //AudioSource.PlayClipAtPoint(PlayerAttacked, transform.position);

          

            //player.GetComponent<Health>().TakeDamage(1);
           // sr.color = Color.white;
            player.transform.position += transform.forward * Time.deltaTime * KnockbackForce;
            player.GetComponentInChildren<SpriteRenderer>().color = Color.black;
            player.GetComponentInChildren<SpriteRenderer>().color = Color.white;

            transform.Translate(-transform.forward * 4 * Time.deltaTime);

            hasAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        hasAttacked = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);



    }
}
